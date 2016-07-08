using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Ejercicios8 : MonoBehaviour
{
	
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	bool correcto,retry,saveActivo,repetido;
	int i,j;
	int intentos;
	float tiempo;
	float reloj;
	public int puntuacion;
	GameObject Frase1,Frase2,Opcion1_1,Opcion1_2, Opcion2_1,Opcion2_2,SCORE, Correcto, Incorrecto,
	Anterior, Vocabulario, Dialogo, Escuchar, Exit, Save,Ranking,Timer,TimeOut,Intentos, reintentar,
	CeroIntentos,TimeOut2,watch,SeguirJugando,Si,No;
	Vector3 mousePos, worldPos;
	private string leaderboard = "CgkIuJ7wrLMXEAIQBg";
	int[] valores=new int[3];

	void Start(){
		if (cam == null){
			cam = Camera.main;
		}

		SCORE=GameObject.Find("SCORE");
	
		Frase1=GameObject.Find("Frase1");
		Frase2=GameObject.Find("Frase2");
		Opcion1_1=GameObject.Find("Opcion1_1");
		Opcion1_2=GameObject.Find("Opcion1_2");
		Opcion2_1=GameObject.Find("Opcion2_1");
		Opcion2_2=GameObject.Find("Opcion2_2");

		Incorrecto=GameObject.Find("Incorrecto");
		Correcto=GameObject.Find("Correcto");
		Vocabulario=GameObject.Find("Vocabulario");
		Dialogo=GameObject.Find("Dialogo");
		Escuchar=GameObject.Find("Escuchar");
		Exit=GameObject.Find("Exit");
		Save=GameObject.Find("Save");
		Ranking=GameObject.Find("Ranking");
		SeguirJugando=GameObject.Find("SeguirJugando");
		Si=GameObject.Find("Si");
		No=GameObject.Find("No");

		reintentar=GameObject.Find("reintentar");
		Timer=GameObject.Find("Timer");
		TimeOut=GameObject.Find("TimeOut");
		TimeOut2=GameObject.Find("TimeOut2");
		Intentos=GameObject.Find("Intentos");
		CeroIntentos=GameObject.Find("CeroIntentos");
		watch=GameObject.Find("watch");

		Frase2.SetActive(false);
		Opcion2_1.SetActive(false);
		Opcion2_2.SetActive(false);
		
		Incorrecto.SetActive(false);
		Correcto.SetActive(false);
		reintentar.SetActive(false);
		CeroIntentos.SetActive(false);
		TimeOut.SetActive(false);
		TimeOut2.SetActive(false);
		SeguirJugando.SetActive(false);
		No.SetActive(false);
		Si.SetActive(false);

		SaveLoad load = new SaveLoad();
		valores=load.Load();
		if(valores[0]==0 && valores[1]==0 && valores[2]==0){
			SaveLoad load1 = new SaveLoad();
			valores=load1.Load();
		}
		puntuacion=valores[0];

		repetido=false;

		if(puntuacion==175){
			i=0;
			j=0;
			reloj=0;
			intentos=3;
		}
		
		else if(puntuacion==180){
			configuracion();
			intentos=valores[1];
			reloj=valores[2];
		}
		else{
			repetido=true;
			puntuacion=175;
			reloj=0;
			intentos=3;
			i=0;
			j=0;
		}

		tiempo=10;

		correcto=false;
		retry=false;
		saveActivo=false;
	
		SCORE.GetComponent<TextMesh>().text =puntuacion.ToString();
		Timer.GetComponent<TextMesh>().text=Mathf.Round(tiempo).ToString();
		watch.GetComponent<TextMesh>().text=Mathf.RoundToInt(reloj).ToString();
		Intentos.GetComponent<TextMesh>().text=intentos.ToString();
	}
	
	void Update(){

		if(!saveActivo && !retry){
			reloj=reloj+Time.deltaTime;
		}
		watch.GetComponent<TextMesh>().text=Mathf.RoundToInt(reloj).ToString();

		if (Input.touchCount > 0)
		{
			Touch theTouch = Input.GetTouch(0);
			
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit))
			{
				if (theTouch.phase == TouchPhase.Began)
				{
					switch(hit.transform.name){

						
					case "Opcion1_1":
						Opcion1_1.GetComponent<TextMesh>().color = Color.gray;
						Correcto.SetActive(false);
						Incorrecto.SetActive(true);
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();

						break;

					case "Opcion1_2":
						Opcion1_2.GetComponent<TextMesh>().color = Color.gray;
						Correcto.SetActive(true);
						correcto=true;
						break;

					case "Opcion2_1":
						Opcion2_1.GetComponent<TextMesh>().color = Color.gray;
						Correcto.SetActive(true);
						correcto=true;
						j=1;
						break;

					case "Opcion2_2":
						Opcion2_2.GetComponent<TextMesh>().color = Color.gray;
						Correcto.SetActive(false);
						Incorrecto.SetActive(true);
						intentos=intentos-1;
			
						Intentos.GetComponent<TextMesh>().text=intentos.ToString();

						break;

					case "reintentar":
						if(i==0){
							retry=false;
							reintentar.SetActive(false);
							TimeOut.SetActive(false);
							TimeOut2.SetActive(false);
							Frase1.SetActive(true);
							Opcion1_1.SetActive(true);
							Opcion1_2.SetActive(true);
							Frase2.SetActive(false);
							Opcion2_1.SetActive(false);
							Opcion2_2.SetActive(false);
							tiempo=10;
						}
						if(i==1){
							retry=false;
							reintentar.SetActive(false);
							TimeOut.SetActive(false);
							TimeOut2.SetActive(false);
							Frase1.SetActive(false);
							Opcion1_1.SetActive(false);
							Opcion1_2.SetActive(false);
							Frase2.SetActive(true);
							Opcion2_1.SetActive(true);
							Opcion2_2.SetActive(true);
							tiempo=10;
						}
						break;

					case "Exit":
						Application.Quit();
						
						break;
						
					case "Save":
						if(!repetido){
							Save.GetComponent<TextMesh>().color = Color.gray;
							saveActivo=true;

							Frase1.SetActive(false);
							Opcion1_1.SetActive(false);
							Opcion1_2.SetActive(false);
							Frase2.SetActive(false);
							Opcion2_1.SetActive(false);
							Opcion2_2.SetActive(false);

							SaveLoad save=new SaveLoad(puntuacion,intentos,Mathf.RoundToInt(reloj));
							save.Save();

							SeguirJugando.SetActive(true);
							No.SetActive(true);
							Si.SetActive(true);
						}
						break;

					case "Si":
						SeguirJugando.SetActive(false);
						No.SetActive(false);
						Si.SetActive(false);
						saveActivo=false;
						
						if(i==0){

							Frase1.SetActive(true);
							Opcion1_1.SetActive(true);
							Opcion1_2.SetActive(true);
							Frase2.SetActive(false);
							Opcion2_1.SetActive(false);
							Opcion2_2.SetActive(false);
							tiempo=10;
						}
						if(i==1){
						
							Frase1.SetActive(false);
							Opcion1_1.SetActive(false);
							Opcion1_2.SetActive(false);
							Frase2.SetActive(true);
							Opcion2_1.SetActive(true);
							Opcion2_2.SetActive(true);
							tiempo=10;
						}
						break;

					}
				}
					if (theTouch.phase == TouchPhase.Ended)
					{
						Correcto.SetActive(false);
						Incorrecto.SetActive(false);
						Save.GetComponent<TextMesh>().color = Color.red;
						Ranking.GetComponent<TextMesh>().color = Color.red;
						Opcion1_1.GetComponent<TextMesh>().color = Color.red;
						Opcion1_2.GetComponent<TextMesh>().color = Color.red;
						Opcion2_1.GetComponent<TextMesh>().color = Color.red;
						Opcion2_2.GetComponent<TextMesh>().color = Color.red;
					}
			}
		}
		if(!saveActivo && !retry){
			if(intentos>0){
				if(tiempo>0){
					tiempo=tiempo-Time.deltaTime;
					Timer.GetComponent<TextMesh>().text=Mathf.Round(tiempo).ToString();
					Timer.GetComponent<TextMesh>().color=Color.black;
					
					if(tiempo<3.5){
						Timer.GetComponent<TextMesh>().color=Color.red;
					}
				}
				
				if(Mathf.Round(tiempo)==0 && !retry)
				{
					if(intentos==1){

						CeroIntentos.SetActive(true);
						Frase1.SetActive(false);
						Opcion1_1.SetActive(false);
						Opcion1_2.SetActive(false);
						Frase2.SetActive(false);
						Opcion2_1.SetActive(false);
						Opcion2_2.SetActive(false);
						
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
					}
					if(intentos==2){
						retry=true;
						TimeOut.SetActive(true);
						reintentar.SetActive(true);
						Frase1.SetActive(false);
						Opcion1_1.SetActive(false);
						Opcion1_2.SetActive(false);
						Frase2.SetActive(false);
						Opcion2_1.SetActive(false);
						Opcion2_2.SetActive(false);
						
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
					}
					if(intentos==3){
						retry=true;
						TimeOut2.SetActive(true);
						reintentar.SetActive(true);
						Frase1.SetActive(false);
						Opcion1_1.SetActive(false);
						Opcion1_2.SetActive(false);
						Frase2.SetActive(false);
						Opcion2_1.SetActive(false);
						Opcion2_2.SetActive(false);

						intentos=intentos-1;
					
						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
					}
				}
			}
			
			if(intentos==0){
				if(!repetido){
					SaveLoad save=new SaveLoad(175,3,0);
					save.Save();
				}
				Application.LoadLevel("Vocabulario8");
			}
		}
			if(correcto){
				
				if(i==0){
					puntuacion+=5;
					SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
					correcto=false;
					configuracion();
				}
				
				if(j==1){
					puntuacion+=5;
					SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
					if(!repetido){
						SaveLoad save=new SaveLoad(puntuacion,intentos,Mathf.RoundToInt(reloj));
						save.Save();
					}

					Application.LoadLevel("Ejercicios8_2");
					correcto=false;
					j=2;
				}
			}
	}
	void configuracion(){
		Correcto.SetActive(false);
		Incorrecto.SetActive(false);
		Frase1.SetActive(false);
		Opcion1_1.SetActive(false);
		Opcion1_2.SetActive(false);
		Frase2.SetActive(true);
		Opcion2_1.SetActive(true);
		Opcion2_2.SetActive(true);
		tiempo=10;
		i=1;
	}
}



