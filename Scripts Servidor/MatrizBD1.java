/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package server;

import java.util.Random;

public class MatrizBD1 {

    private int matrizInt[][] = new int[100][3]; //"Pts", "Intentos", "Tiempo"
    private String matrizStr[][] = new String[100][1]; //"nombre"
    private int pts, intentos, tiempo, usuarios = 0;
    private String nombre;

    public void PonerDatos1(String name, int puntos, int inten, int time) {
        nombre = name;
        pts = puntos;
        intentos = inten;
        tiempo = time;
        usuarios++;
        AniadirDatos();
    }

    private void AniadirDatos() {

        matrizInt[usuarios - 1][0] = pts;
        matrizInt[usuarios - 1][1] = intentos;
        matrizInt[usuarios - 1][2] = tiempo;

        matrizStr[usuarios - 1][0] = nombre;

        Ordenar();
    }

    private void Ordenar() {

        String auxNombre;
        int[] filaInt = new int[3];
        boolean salir = false;

        int cambios;

        while (!salir) {
            cambios = 0;
            for (int i = 0; i < usuarios-1; i++) { 
                if (matrizInt[i][2] > matrizInt[i + 1][2]) {

                    for (int j = 0; j < 3; j++) {
                        filaInt[j] = matrizInt[i + 1][j]; //se guarda la fila del minimo
                    }
                    auxNombre = matrizStr[i + 1][0];

                    for (int z = 0; z < 3; z++) {
                        matrizInt[i + 1][z] = matrizInt[i][z];
                        matrizInt[i][z] = filaInt[z];
                    }
                    matrizStr[i + 1][0] = matrizStr[i][0];
                    matrizStr[i][0] = auxNombre;
                    cambios++;
                }
            }
            if (cambios == 0) {
                salir = true;
            }
        }
    }

    // devuelve primeras tres posiciones de la matriz, y la posición del usuario que solicita lel Ranking 
    public int[][] LoadIntPrimerosTres() {
        int[][] matrizResult = new int[3][3];  //"pts" "Intentos", "Tiempo" (puntos siempre son los mismo) 

        for (int i = 0; i < 3; i++) { //los primeros tres
            for (int j = 0; j < 3; j++) {
                matrizResult[i][j] = matrizInt[i][j];
            }
        }
        return matrizResult;
    }

    public int[] LoadInt4(String nombre) {
        int[] matrizResult = new int[4];
        boolean salir = false;
        int l = 0;
        int pos = 4;
        while (!salir && l <= usuarios-1) { // se buscan los datos del solicitante 

            if (matrizStr[l][0].equals(nombre)) {
                pos = l+1;//l+1 porque se trata de posiciones que van desde 1
                salir = true;
            } else {
                l++;
            }
        }
      
        if (pos > 3) { // si el usuario ya se encuentra entre las primeras tres posiciones, se manda el usuario 4
            matrizResult[0] = pos;
        } else {
            pos=4;
            matrizResult[0] = pos;
            
        }
        
        for (int k = 1; k < 4; k++) {
            matrizResult[k] = matrizInt[pos-1][k - 1]; 
        }

        return matrizResult;
        
            /* for(int l=0; l < usuarios;l++) { // se buscan los datos del solicitante 

         if (matrizStr[l][0] == nombre.toString()) {
         pos = l;
         l=usuarios;
         System.out.println("Esta entre los tres primeros IntLoad4 "+pos);
         }
         }*/
        
    }

    public String[][] LoadStr(String nombre) {
        String[][] matrizS = new String[4][1];
        int i = 0;
        for (int k = 0; k < 3; k++) {
            if (matrizStr[k][0].equals(nombre)) {
                i = 1;
                //System.out.println("Esta entre los tres primeros LoadStr");
            }
            matrizS[k][0] = matrizStr[k][0];
        }

        if (i == 1)//el nombre está entre los tres primeros
        {
            matrizS[3][0] = matrizStr[3][0];
        } else {
            matrizS[3][0] = nombre.toString();
        }

        return matrizS;
    }

    public void result() {
        System.out.println("Tiempo1: " + matrizInt[0][2]);
        System.out.println("Nombre1: " + matrizStr[0][0]);
        System.out.println("Tiempo2: " + matrizInt[1][2]);
        System.out.println("Nombre2: " + matrizStr[1][0]);
        System.out.println("Tiempo3: " + matrizInt[2][2]);
        System.out.println("Nombre3: " + matrizStr[2][0]);
        System.out.println("Tiempo4: " + matrizInt[3][2]);
        System.out.println("Nombre4: " + matrizStr[3][0]);
    }
}
