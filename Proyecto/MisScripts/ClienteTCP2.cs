using UnityEngine;
using System.Collections;
using System;
using System.Net.Sockets;
using System.Net;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Net.Security;
using System.Security.Cryptography;

public class ClienteTCP2 {
	private TcpClient socketCliente;

	//SslStream flujo;
	private NetworkStream flujo;
	private int puntuacion,intentos,tiempo,tiempoFinal,leccion;
	private bool cargar,save,recuperar,saveMandado;
	//string nombre=Social.localUser.userName;
	string nombre = "";
	private string key_string = "Clave";
	//private string nombre="nombre";
	private string nombre1,nombre2,nombre3,nombre4="";
	private int[] vectorInt=new int[13];
	
	public ClienteTCP2(){
		nombre = new string(Social.Active.localUser.userName.ToCharArray());

		//cargar=false;
		//save=false;
		Debug.Log("Start Cliente");
		//PonerDatos(1,2,3);
		// al principio abrimos la conexión:
		int puerto = 9999;
		
	}
	
	public ClienteTCP2(int lec){//para no establecer una conexion nueva, sino que solo para coger valores

		//nombre = Social.Active.localUser.userName;
		nombre = new string(Social.Active.localUser.userName.ToCharArray());

		if(lec>0){
			cargar=true;
			save=false;
			recuperar=false;
			leccion=lec;
			solicitarAlServidorOperacion();
		}
		else{//en caso de fichero borrado
			recuperar=true;
			save=false;
			cargar=true;
			solicitarAlServidorOperacion();
		}
		//System.Random r = new System.Random(DateTime.Now.Millisecond);
		//id=r.Next(100,999); //soporta 1000 usuarios, para que cada fila de la tabla identifique a un usuario distinto
	}

	private void inicializarRed(string servidor, int puerto)
	{
		//socketCliente = new TcpClient(servidor, puerto);
		socketCliente = new TcpClient("192.168.1.8", puerto);
		// obtenemos el stream para leer y escribir:
		flujo = socketCliente.GetStream();
		// Create a secure stream

		/*X509Certificate cert=new X509Certificate("Assets/Certificado/certificado.cer", "123456");
		//X509Chain chain=new X509Chain("Assets/Certificado/autoridades_certificadoras_fiables.key");

		X509CertificateCollection cCollection = new X509CertificateCollection();
		cCollection.Add(cert);

		flujo = new SslStream(socketCliente.GetStream(), false,
		   new RemoteCertificateValidationCallback(ValidateServerCertificate),null);

		Debug.Log("FLUJO");
		
		// Add a client certificate to the ssl connection, // The server name must match the name on the server certificate. 
		//flujo.AuthenticateAsClient("Servidor", null, System.Security.Authentication.SslProtocols.Ssl3, false);//, cCollection, System.Security.Authentication.SslProtocols.Default, true);
		flujo.AuthenticateAsClient("Servidor",null,System.Security.Authentication.SslProtocols.None,false);

		Debug.Log("despues de auth");*/
	}
	
	
	public void PonerDatos(int puntos,int intento, int time,int lesson, int timeF){
		//nombre=name;
		Debug.Log ("Poner Datos Cliente");
		puntuacion=puntos;
		intentos=intento;
		tiempo=time;
		leccion=lesson;
		tiempoFinal=timeF;
	}

	public void Mandar(){
	
		Debug.Log("PonerSave save");
		save=true;
		cargar=false;
		recuperar=false;
		solicitarAlServidorOperacion();
	}

	
	private void solicitarAlServidorOperacion()
	{
		int i,j;

		if(recuperar){

			bool Salir=false;
			while(!Salir){
				inicializarRed("localhost",9999);
				Debug.Log("Dentro recuperar");
				byte[] mensaje=new byte[256];
				mensaje[0] = (byte)0x06;

				byte[] nme=System.Text.Encoding.UTF8.GetBytes(nombre);

				i=0;
				for (int k = 0; k < nme.Length; k++){
					mensaje[k+1] = (byte)nme[k];
					i++;
				}
				
				Debug.Log("total "+(i+1));
				flujo.Write(mensaje, 0, i+1);
				flujo.Flush();
				bool recibido=false;
				long timeout = (long) (DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds + 10000; 

				while(!recibido && (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds<timeout){
					if(flujo.DataAvailable){
					// Recibimos la respuesta:
						byte[] mensaje23=new byte[2];

						// Read can return anything from 0 to numBytesToRead. 
						// This method blocks until at least one byte is read.
						int total = flujo.Read(mensaje23,0, 2);
						Debug.Log("total "+total);
						Debug.Log("leo mensaje respuesta del servidor");
						
						if(mensaje23[0]==0x12){//
							Salir=true;
							//recuperar=false;
							cargar=true;
							save=false;
							leccion=mensaje23[1];//
							if(leccion==0){
								cargar=false;
								mensaje23[0]=0x04;
								flujo.Write(mensaje23, 0, 1);
								flujo.Flush();
								flujo.Close();
							}
							Debug.Log("0x12 leccion: "+leccion);
							recibido=true;

							//flujo.Close();
						}

						if(mensaje23[0]==0x23){//
							Debug.Log("0x23");
							Salir=false;
							recibido=true;
							flujo.Close();
						}
					}
				}
			}
		}
		//Save
		if(save){

			// create a byte array containing the key
			byte[] key_bytes = System.Text.Encoding.UTF8.GetBytes(key_string);
			
			// create an instance of the HMAC-SHA-1 keyed algorithm
			KeyedHashAlgorithm hash_alg = KeyedHashAlgorithm.Create("HMACSHA1");
			
			// set the secret key for the hashing algorithm
			hash_alg.Key = key_bytes;

			bool salir = false;
			bool autenticado = false;

			while(!autenticado){
				saveMandado=false;
				inicializarRed("localhost",9999);
				byte[] mensaje=new byte[256];
				mensaje[0] = (byte) 0x30;
				byte[] nme=System.Text.Encoding.UTF8.GetBytes(nombre);
				i=0;
				for (int k = 0; k < nme.Length; k++){
					mensaje[k+1] = (byte)nme[k];
					i++;
				}
				Debug.Log("nme.Length "+nme.Length);
				flujo.Write(mensaje, 0, 2+i);
				flujo.Flush();
				Debug.Log("longitud mensaje getnonce "+(2+i));
		
				bool recibido=false;
				long timeout = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds + 6000;
				
				while(!recibido && (DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds<timeout){
					if(flujo.DataAvailable){
						int total = flujo.Read(mensaje,0,2);
						if(mensaje[0]==(byte)0x31){
							Debug.Log ("0x31");
							int nonce = (int) mensaje[1];
							//Debug.Log ("nonce "+nonce);
							System.Random rnd = new System.Random();
							int cnonce = rnd.Next();
							Debug.Log("cnonce "+cnonce);
							mensaje[0] = (byte) 0x33;
							mensaje[1] = (byte) cnonce;
						
							i=0;
							for (int k = 0; k < nme.Length; k++){
								mensaje[k+2] = (byte)nme[k];
								i++;
							}

							//byte[] array = new byte[]{(byte)nonce, (byte)cnonce, (byte[])nme, (byte)13};
							byte[] array = new byte[nme.Length+3];
							array[0] = (byte)nonce;
							array[1] = (byte)cnonce;
							Debug.Log("nonce en bytes "+array[0]);
							Debug.Log("cnonce en bytes "+array[1]);
							for(int m=0;m<nme.Length;m++){
								array[m+2]=nme[m];
							}
							array[nme.Length+2]=(byte)13;

							byte[] hash_code = hash_alg.ComputeHash(array);
							
							for (int k=0;k<20;k++){
								mensaje[2+i+k]=hash_code[k];
								Debug.Log("hash: "+mensaje[2+i+k]);
							}

							flujo.Write(mensaje, 0, 22+i);
							flujo.Flush();
							Debug.Log("Mando hash");
							Debug.Log("longitud mensaje mandado "+(i+22));

							bool recibido2=false;
							long timeout2 = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds + 6000;
							
							while(!recibido2 && (DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds<timeout2){
								if(flujo.DataAvailable){
									int total2 = flujo.Read(mensaje,0,1);
									if(mensaje[0]==(byte)0x34){
										Debug.Log ("0x34");
	
											Debug.Log("Dentro Save");

											mensaje[0] = (byte)0x01;
											mensaje[1] = (byte)puntuacion;
											mensaje[2] = (byte)intentos;
											mensaje[3] = (byte)tiempo;
											mensaje[4] = (byte)leccion;
											mensaje[5] = (byte)tiempoFinal;
											
											byte[] nme2=System.Text.Encoding.UTF8.GetBytes(nombre);
											i=0;
											for (int k = 0; k < nme.Length; k++){
												mensaje[k+6] = (byte)nme2[k];
												i++;
											}
											
											flujo.Write(mensaje, 0, 6+i);
											flujo.Flush();
											saveMandado=true;
											Debug.Log("Mandado save");
											Debug.Log("longitud mensaje "+(6+i));
											recibido2=true;
									}else{
										Debug.Log("no 0x34");
										autenticado=false;
										recibido=true;
										recibido2=true;
										flujo.Close();
									}
								}
							}

							if(saveMandado==true){
								bool recibido3=false;
								long timeout3 = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds + 6000;
								while(!recibido3 && (DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds<timeout3){
									
									if(flujo.DataAvailable){
										Byte[] mensaje23 = new Byte[1];
										int total3 = flujo.Read(mensaje23,0, 1);
										
										Debug.Log("total "+total3);
										Debug.Log("leo mensaje respuesta del servidor");
										
										if(mensaje23[0]==(byte)0x05){
											salir=true;
											autenticado=true;
											recibido3=true;
											recibido=true;
											save=false;
											flujo.Close();
											Debug.Log("0x05");
										}
										
										if(mensaje23[0]==(byte)0x23){
											Debug.Log ("0x23");
											salir=false;
											autenticado=false;
											recibido3=true;
											flujo.Close();
										}
									}
								}
							}


						}else{
							Debug.Log("No 0x31");
							autenticado=false;
							recibido=true;
							flujo.Close();
						}
					}
				}
			}
		}
		//Load
		if(cargar){
			Debug.Log("En cargar");
			bool salir=false;
			bool aux=false;
			bool correcto=false;

			while(!salir){

				if(!recuperar || aux){
					aux=false;
					inicializarRed("localhost",9999);
				}else
					recuperar=false;

				byte[] mensaje = new Byte[256];
				mensaje[0] = 0x02;
				mensaje[1]=(byte) leccion;

				byte[] nme=System.Text.Encoding.UTF8.GetBytes(nombre);
				i=0;
				for (int k = 0; k < nme.Length; k++){
					mensaje[k+2] = (byte)nme[k];
					i++;
				}
				/*byte[] array=new byte[2];
				array[0]=mensaje[0];
				array[1]=mensaje[1];

				// obtain the hash code from the HashAlgorithm by 
				// using the ComputeHash method
				byte[] hash_code = hash_alg.ComputeHash(array);

				/*for(int n=0;n<20;n++){
					mensaje[2+n]=hash_code[n];
				}*/

				//mensaje[2]=(byte) 1; //random
				Debug.Log("LECCION: "+leccion);
				flujo.Write(mensaje, 0, 2+i);
				flujo.Flush();
				bool recibido=false;
				aux=false;
				long timeout = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds + 10000;
				Debug.Log("En load antes de flujo ");

				while(!recibido && (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds<timeout){
					if(flujo.DataAvailable){
						Byte[] mensaje23 = new Byte[512];
						// Recibimos la respuesta:
						int total = flujo.Read(mensaje23,0, 16); //sumarle 20 por certificado digital
						int p=0;
						// Si el mensaje de vuelta es del tipo correcto, generamos la respuesta:
						if (mensaje23[0] == 0x10) //todos int
						{
							Debug.Log("0x10");
							while(mensaje23[p]!=(byte)0x29 && p<(int)mensaje23[1]){
								
								vectorInt[p]=(int) mensaje23[p+2];
								Debug.Log ("Lo que me llega: para p="+p+" "+vectorInt[p]);
								p++;
							}
							salir=true;
							recibido=true;
							//Autenticacion servidor
						
							
							//byte[] hash_codeVerify = hash_alg.ComputeHash(array2); //Cliente hace el hash con la clave que tiene
							//byte[] verify=new byte[20];
							//byte[] signature=new byte[20];
							/*for(int l=0;l<20;l++){
								verify[l]=mensaje[16+l]; // ) esta enn la posicion 15
							}*/
							/*for(int l=0;l<20;l++){
								signature[l]=mensaje[16+l]; // ) esta enn la posicion 15
							}*/
							//if(verify.Equals(hash_codeVerify)){
							/*if(verificarFirma(array2,signature)){
								salir=true;
								while(mensaje[k]!=(byte)0x29 && k<(int)mensaje[1]){
									
									vectorInt[k]=(int) mensaje[k+2];
									k++;
								}
							}*/

							correcto=true;
						}

						if(mensaje23[0]==(byte)0x23){
							Debug.Log("0x23");
							aux=true;
							salir=false;
							recibido=true;
							flujo.Close();
						}
					}
				}
			}

			bool salir2=false;
			
			while(!salir2){
				if(!correcto)
					inicializarRed("localhost",9999);
				correcto=false;
				byte[] mensaje1 = new Byte[256];
				mensaje1[0] = 0x03;
				mensaje1[1] = (byte) leccion;
				byte[] nme=System.Text.Encoding.UTF8.GetBytes(nombre);
				i=0;
				for (int k = 0; k < nme.Length; k++){
					mensaje1[k+2] = (byte)nme[k];
					i++;
				}
				/*byte[] array=new byte[2];
				array[0]=mensaje1[0];
				array[1]=(byte)0x00;

				// obtain the hash code from the HashAlgorithm by 
				// using the ComputeHash method
				byte[] hash_code2 = hash_alg.ComputeHash(array);
				
				for(int m=0;m<20;m++){
					mensaje1[1+m]=hash_code2[m];
				}*/
				

				flujo.Write(mensaje1, 0, i+2);
				flujo.Flush();
				bool recibido2=false;
				long timeout = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds + 10000;

				while(!recibido2 && (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds<timeout){
					if(flujo.DataAvailable){
						Byte[] mensaje23 = new Byte[512]; //Antes mensaje=new Byte[512]
						// Recibimos la respuesta:
						int total = flujo.Read(mensaje23,0,512);
						Debug.Log("Total2: "+total);

						if (mensaje23[0]==0x11){//Nombres
							int k=1;
						
							Debug.Log("0x11");

							int contador=0;
						
							while(mensaje23[k]!=(byte)0x29){
							//while(!salir){
								int m=0;
								byte[] msg=new byte[mensaje23[k]];
								Debug.Log(mensaje23[k]);

								contador++;
								k++;
								Debug.Log("mensaje[4]:"+mensaje23[4]);
								while(mensaje23[k]!=(byte)0x2A){
								
									msg[m]=mensaje23[k];
									Debug.Log("k: "+(k+1)+" m: "+m);
									Debug.Log("mensaje[k]: "+mensaje23[k+1]+" msg[m]: "+msg[m]);
									k++;
									m++;

								}
								k++;
								Debug.Log(k);
								if(contador==1){
									nombre1=System.Text.Encoding.UTF8.GetString(msg);
									if(nombre1.Equals(nombre))
										nombre1="Я";
									Debug.Log("nombre1: "+nombre1);
								}
								if(contador==2){
									nombre2=System.Text.Encoding.UTF8.GetString(msg);
									if(nombre2.Equals(nombre))
										nombre2="Я";
									Debug.Log("nombre2: "+nombre2);
								}
								if(contador==3){
									nombre3=System.Text.Encoding.UTF8.GetString(msg);
									if(nombre3.Equals(nombre))
										nombre3="Я";
									Debug.Log("nombre3: "+nombre3);

								}
								if(contador==4){
									nombre4=System.Text.Encoding.UTF8.GetString(msg);
									if(String.Compare(nombre4,nombre)==0)
									//if(nombre4.CompareTo(nombre)==0)
										nombre4="Я";
									Debug.Log("nombre4: "+nombre4);
								}
							}
							correcto=true;
							recibido2=true;
							salir2=true;
						}

						if(mensaje23[0]==(byte)0x23){
							Debug.Log ("0x23");
							flujo.Close();
							salir2=false;
							recibido2=true;
							correcto=false;
						}
					}
			}
				//Autenticacion servidor

				/*byte[] array3=new byte[2];
				array3[0]=mensaje1[0];
				array3[1]=mensaje1[1];
				
				// obtain the hash code from the HashAlgorithm by 
				// using the ComputeHash method
				byte[] hash_code = hash_alg.ComputeHash(array3);
			
				byte[] verify=new byte[20];
				
				for(int l=0;l<20;l++){
					verify[l]=mensaje1[k+l];
				}
				
				if(verify.Equals(hash_code)){
					salir2=true;
				}*/
			}

			byte[] mensaje4 = new Byte[1];
			mensaje4[0] = 0x04;
			
			
			/*byte[] array4=new byte[2];
			array4[0]=mensaje4[0];
			array4[1]=(byte)0x00;
			// obtain the hash code from the HashAlgorithm by 
			// using the ComputeHash method
			byte[] hash_code4 = hash_alg.ComputeHash(array4);

			for(int m=0;m<20;m++){
				mensaje4[1+m]=hash_code4[m];
			}*/


			flujo.Write(mensaje4, 0, 1);
			flujo.Flush();
			long timeout2 = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds + 10000;
			//Espera un cierto tiempo hasta cerrar la conexion, para que en caso de la perdida del mensaje,
			//el servidor pueda mandar 0x23 y cerrar la conexion en su lado.
			while((DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds<timeout2){}
			Debug.Log ("despues de while");
			flujo.Close();
		}
	}
	

	public int[] MisDatos(){
		int[] datos=new int[3];
		if(leccion>0){
			if(nombre1.Equals("Я")){
				Debug.Log("Opcion 1");
				datos[0]=vectorInt[0];
				datos[1]=vectorInt[1];
				datos[2]=vectorInt[2];
			}

			if(nombre2.Equals("Я")){
				Debug.Log("Opcion 2");
				datos[0]=vectorInt[3];
				datos[1]=vectorInt[4];
				datos[2]=vectorInt[5];
			}

			if(nombre3.Equals("Я")){
				Debug.Log("Opcion 3");
				datos[0]=vectorInt[6];
				datos[1]=vectorInt[7];
				datos[2]=vectorInt[8];
			}

			if(nombre4.Equals("Я")){
				Debug.Log("Opcion 4");
				datos[0]=vectorInt[10];
				datos[1]=vectorInt[11];
				datos[2]=vectorInt[12];
			}
		}
		else{
			datos[0]=0;
			datos[1]=3;
			datos[2]=0;
		}
		return datos;
	}


	public int[] GetInt(){
		Debug.Log("Get3Int");
		for(int i=0;i<vectorInt.Length;i++)
		{
			Debug.Log("valor i="+i+" valor del vector: "+vectorInt[i]);
		}
		return vectorInt;
	}

	public string GetName1(){
		Debug.Log("GetName1");
		return nombre1;
	}
	public string GetName2(){
		Debug.Log("GetName2");
		return nombre2;
	}
	public string GetName3(){
		Debug.Log("GetName3");
		return nombre3;
	}
	public string GetName4(){
		Debug.Log("GetName4");
		return nombre4;
	}
}

