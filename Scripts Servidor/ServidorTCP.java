/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package server;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.crypto.Mac;
import javax.crypto.spec.SecretKeySpec;

public class ServidorTCP {

    int k = 1;
    String key = "Clave";
    MatrizBD1[] base = new MatrizBD1[20];

    public static void main(String[] args) throws IOException {
        try {
            new ServidorTCP(9999);
        } catch (NoSuchAlgorithmException ex) {
            Logger.getLogger(ServidorTCP.class.getName()).log(Level.SEVERE, null, ex);
        } catch (InvalidKeyException ex) {
            Logger.getLogger(ServidorTCP.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @SuppressWarnings("empty-statement")
    private ServidorTCP(int puerto) throws IOException, NoSuchAlgorithmException, InvalidKeyException {

        try {
            if (k == 1) {
                for (int i = 0; i < 19; i++) {
                    k = 2;
                    base[i] = new MatrizBD1();
                }
            }

            Map<String, Integer> mapa = new HashMap<String, Integer>();
            Map<String, Integer> mapaNonce = new HashMap<String, Integer>();
            Map<String, Boolean> mapaAuth = new HashMap<String, Boolean>();

            // get an hmac_sha1 Mac instance and initialize with the signing key
            SecretKeySpec signingKey = new SecretKeySpec(key.getBytes(), "HmacSHA1");
            Mac mac = Mac.getInstance("HmacSHA1");
            mac.init(signingKey);

            boolean salir = false, cerrarConexion = false;
            ServerSocket server = new ServerSocket(puerto);

            do {

                Socket socketServicio = server.accept();
                cerrarConexion = false;
                long currentTime = 0;
                long timeout = System.currentTimeMillis() + 5000;
                System.out.println("Socket establecido ");
                InputStream flujoEntrada = socketServicio.getInputStream();
                OutputStream flujoSalida = socketServicio.getOutputStream();
                byte[] mensaje = new byte[512];
                boolean autenticado = false;

                do {
                    currentTime = System.currentTimeMillis();
                    if (currentTime < timeout) {

                        if (flujoEntrada.available() > 0) {
                            int n = flujoEntrada.read(mensaje, 0, 512);
                            System.out.println("Leemos " + n);

                            if (mensaje[0] == 0x30) {
                                System.out.println("0x30");
                                Random rnd = new Random();
                                int nonce = rnd.nextInt(250);
                                System.out.println("nonce generado " + nonce);
                                if (nonce < 0) {
                                    nonce = nonce * (-1);
                                }

                                String nombre = "";

                                int i = 0;

                                do {
                                    nombre += (char) mensaje[i + 1];
                                    i++;
                                } while ((i + 1) != n - 1);
                                System.out.println(nombre);
                                mapaNonce.put(nombre, nonce);

                                mensaje[0] = (byte) 0x31;
                                mensaje[1] = (byte) nonce;
                                System.out.println("nonce en bytes " + (byte) nonce);
                                flujoSalida.write(mensaje, 0, 2);
                                flujoSalida.flush();
                                System.out.println("0x31 enviado");
                            }

                            if (mensaje[0] == 0x33) {
                                System.out.println("0x33");

                                System.out.println("cnonce recibido " + (byte) mensaje[1]);
                                String nombre = "";
                                byte[] name = new byte[n - 22];
                                byte[] vClient = new byte[20];
                                byte[] array = new byte[name.length + 3];
                                int i = 0;

                                do {
                                    nombre += (char) mensaje[i + 2];
                                    name[i] = mensaje[i + 2];
                                    i++;
                                } while ((i + 2) != n - 20);
                                System.out.println("antes del nonce");
                                int nonce = mapaNonce.get(nombre);
                                System.out.println("nonce del mapa " + (byte) nonce);
                                for (int j = 0; j < 20; j++) {
                                    vClient[j] = mensaje[j + 2 + name.length];
                                }

                                array[0] = (byte) nonce;
                                array[1] = mensaje[1];

                                for (int k = 0; k < name.length; k++) {
                                    array[k + 2] = name[k];
                                }

                                array[name.length + 2] = (byte) 13;

                                byte[] vServer = mac.doFinal(array);

                                if (Arrays.equals(vServer, vClient)) {
                                    mensaje[0] = (byte) 0x34;
                                    mapaAuth.put(nombre, true);
                                    System.out.println("hash igual");
                                } else {
                                    System.out.println("hash diferente");
                                    mensaje[0] = (byte) 0x35;
                                }
                                flujoSalida.write(mensaje, 0, 1);
                                flujoSalida.flush();
                            }

                           
                                //Save
                                if (mensaje[0] == 0x01) {
                                    System.out.println("0x01");
                                    int pts = (int) mensaje[1];
                                    int intentos = (int) mensaje[2];
                                    int tiempo = (int) mensaje[3];
                                    int leccion = (int) mensaje[4];
                                    int tiempoFinal = (int) mensaje[5];
                                    String nombre = "";

                                    int i = 0;

                                    do {
                                        nombre += (char) mensaje[i + 6];
                                        i++;
                                    } while ((i + 6) != n);
                                    if (mapaAuth.get(nombre) == true) {
                                        mapa.put(nombre, leccion);

                                        base[leccion - 1].PonerDatos1(nombre, pts, intentos, tiempoFinal);
                                        base[leccion - 1].PonerDatos1("-", 0, 0, 100);
                                        base[leccion - 1].PonerDatos1("-", 0, 0, 100);
                                        base[leccion - 1].PonerDatos1("-", 0, 0, 100);

                                        base[leccion - 1].result();

                                        mensaje[0] = (byte) 0x05;

                                        flujoSalida.write(mensaje, 0, 1);
                                        flujoSalida.flush();

                                        cerrarConexion = true;
                                }
                            }
                            if (mensaje[0] == 0x06) {
                                int z = 0;
                                System.out.println("0x06");
                                String Nombre = "";
                                do {
                                    Nombre += (char) mensaje[z + 1];
                                    z++;
                                } while ((z + 1) != n);

                                int lec = 0;

                                if (mapa.get(Nombre) != null) {
                                    lec = mapa.get(Nombre);
                                }

                                mensaje[0] = (byte) 0x12;
                                mensaje[1] = (byte) lec;
                                flujoSalida.write(mensaje, 0, 2);
                                flujoSalida.flush();

                                System.out.println("0x12");
                            }

                            //Load
                            if (mensaje[0] == 0x02) { 
                                System.out.println("Peticion Load");
                                int[][] matrizResultInt = new int[3][3];
                                int[] matrizResultIntUser = new int[4];

                                String nombre = "";
                                int m = 0;
                                do {
                                    nombre += (char) mensaje[m + 2];
                                    m++;
                                } while ((m + 2) != n);

                                int leccion = (int) mensaje[1];
                                int valor = 0;

                                matrizResultInt = base[leccion - 1].LoadIntPrimerosTres(); // 9Bytes
                                matrizResultIntUser = base[leccion - 1].LoadInt4(nombre);
                                mensaje[0] = (byte) 0x10;
                                mensaje[1] = (byte) 13;
                                int k = 2;
                                for (int i = 0; i < 3; i++) {
                                    for (int j = 0; j < 3; j++) {
                                        valor = matrizResultInt[i][j];
                                        mensaje[k] = (byte) valor;
                                        k++;
                                    }
                                }
                                mensaje[k] = (byte) matrizResultIntUser[0];
                                mensaje[k + 1] = (byte) matrizResultIntUser[1];
                                mensaje[k + 2] = (byte) matrizResultIntUser[2];
                                mensaje[k + 3] = (byte) matrizResultIntUser[3];

                                mensaje[k + 4] = (byte) 0x29;

                                // enviamos el mensaje:
                                flujoSalida.write(mensaje, 0, 16);
                                flujoSalida.flush();
                                System.out.println("Enviado Load con Enteros");
                                //}
                            }
                            if (mensaje[0] == 0x03) {
                                String[][] matrizS = new String[4][1];

                                int longit = 0;
                                int contador = 0;
                                String nombre = "";
                                int m = 0;

                                do {
                                    nombre += (char) mensaje[m + 2];
                                    m++;
                                } while ((m + 2) != n);

                                int leccion = (int) mensaje[1];
                                boolean out = false;
                                matrizS = base[leccion - 1].LoadStr(nombre);

                                mensaje[0] = (byte) 0x11;

                                while (!out) {
                                    longit++;
                                    mensaje[longit] = (byte) (matrizS[contador][0].getBytes()).length;

                                    int k = 0;

                                    for (int j = longit; j < longit + (matrizS[contador][0].getBytes()).length; j++) {
                                        mensaje[j + 1] = (matrizS[contador][0].getBytes())[k];
                                        k++;
                                    }
                                    if (contador > 0) {
                                        int suma = 0;
                                        for (int i = 0; i <= contador; i++) {
                                            suma = suma + (matrizS[i][0].getBytes()).length;
                                        }
                                        longit = 2 + contador * 2 + suma;
                                    } else {
                                        longit = k + 2;
                                    }

                                    mensaje[longit] = (byte) 0x2A; //* 42

                                    contador++;

                                    if (contador > 3) {
                                        out = true;
                                        System.out.println("dentro de out=true");
                                    }
                                }

                                mensaje[longit + 1] = (byte) 0x29;

                                flujoSalida.write(mensaje, 0, longit + 2);
                                flujoSalida.flush();
                                System.out.println("Enviado Load Nombre");

                            }

                            if (n == 1 && mensaje[0] == 0x04) {
                                cerrarConexion = true;
                                System.out.println("0x04");
                            }
                        } else {
                            cerrarConexion = false;
                        }

                    } else {
                        System.out.println("mando 0x23 server");
                        autenticado = false;
                        cerrarConexion = true;
                        mensaje[0] = (byte) 0x23;
                        flujoSalida.write(mensaje, 0, 1);
                        flujoSalida.flush();
                    }

                } while (!cerrarConexion);
                // cerramos los flujos...
                flujoEntrada.close();
                flujoSalida.close();
                socketServicio.close();

            } while (!salir);

        } catch (IOException ex) {
            Logger.getLogger(ServidorTCP.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
