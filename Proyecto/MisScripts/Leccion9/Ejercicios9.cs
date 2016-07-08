using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Ejercicios9 : MonoBehaviour
{
	
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	bool correcto;
	int i,j,m;
	public int puntuacion;
	GameObject modelo2,modelo1,opcion1, opcion2, opcion1_2,opcion1_3, SCORE, Correcto, Incorrecto,
	Anterior,Vocabulario, Dialogo, Escuchar, Exit,Save,Ranking,CeroIntentos,Timer,TimeOut,TimeOut2,watch,reintentar,Intentos,SeguirJugando,Si,No;
	Vector3 mousePos, worldPos;
	private string leaderboard = "CgkIuJ7wrLMXEAIQBg";
	float tiempo;
	int intentos;
	float reloj;
	bool retry,saveActivo,repetido;
	int[] valores=new int[3];

	void Start(){
		if (cam == null){
			cam = Camera.main;
		}

		SCORE=GameObject.Find("SCORE");
		modelo1=GameObject.Find("modelo1");
		modelo2=GameObject.Find("modelo2");
		opcion2=GameObject.Find("opcion2");
		opcion1_3=GameObject.Find("opcion1_3");
		opcion1=GameObject.Find("opcion1");
		opcion1_2=GameObject.Find("opcion1_2");
		
		Incorrecto=GameObject.Find("Incorrecto");
		Correcto=GameObject.Find("Correcto");
		Vocabulario=GameObject.Find("Vocabulario");
		Dialogo=GameObject.Find("Dialogo");
		Escuchar=GameObject.Find("Escuchar");
		Exit=GameObject.Find("Exit");
		Save=GameObject.Find("Save");
		Ranking=GameObject.Find("Ranking");
		
		Timer=GameObject.Find("Timer");
		TimeOut=GameObject.Find("TimeOut");
		TimeOut2=GameObject.Find("TimeOut2");
		Intentos=GameObject.Find("Intentos");
		reintentar=GameObject.Find("reintentar");
		CeroIntentos=GameObject.Find("CeroIntentos");
		watch=GameObject.Find("watch");
		SeguirJugando=GameObject.Find("SeguirJugando");
		Si=GameObject.Find("Si");
		No=GameObject.Find("No");

		Incorrecto.SetActive(false);
		Correcto.SetActive(false);
		opcion2.SetActive(false);
		modelo2.SetActive(false);
		reintentar.SetActive(false);
		CeroIntentos.SetActive(false);
		TimeOut.SetActive(false);
		TimeOut2.SetActive(false);
		SeguirJugando.SetActive(false);
		No.SetActive(false);
		Si.SetActive(false);


		opcion1.GetComponent<TextMesh>().color = Color.magenta;
		opcion1_2.GetComponent<TextMesh>().color = Color.magenta;
		opcion1_3.GetComponent<TextMesh>().color = Color.magenta;
		opcion1_3.GetComponent<TextMesh>().color = Color.magenta;

		SaveLoad load = new SaveLoad();
		valores=load.Load();
		if(valores[0]==0 && valores[1]==0 && valores[2]==0){
			SaveLoad load1 = new SaveLoad();
			valores=load1.Load();
		}

		puntuacion=valores[0];

		repetido=false;

		if(puntuacion==195){
			i=0;
			j=0;
			reloj=0;
			intentos=3;
		}

		else if(puntuacion==200){
			configuracion();
			intentos=valores[1];
			reloj=valores[2];
		}
		else{
			repetido=true;
			i=0;
			j=0;
			puntuacion=195;
			reloj=0;
			intentos=3;
		}
		correcto=false;
		retry=false;
		saveActivo=false;
		tiempo=10;

		watch.GetComponent<TextMesh>().text=Mathf.Round(reloj).ToString();
		Intentos.GetComponent<TextMesh>().text=intentos.ToString();
		Timer.GetComponent<TextMesh>().text=Mathf.RoundToInt(tiempo).ToString();
		SCORE.GetComponent<TextMesh>().text=puntuacion.ToString();
		
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
						
					case "opcion1":
					
						opcion1.GetComponent<TextMesh>().color = Color.gray;
						correcto=true;
						i=1;

						break;
						
					case "opcion1_2":
						Correcto.SetActive(false);
						Incorrecto.SetActive(true);
						intentos=intentos-1;
					
						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						
						break;
						
					case "opcion2":

						opcion2.GetComponent<TextMesh>().color = Color.gray;
						correcto=true;

						break;
						
					case "opcion1_3":
						
						Correcto.SetActive(false);
						Incorrecto.SetActive(true);
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						break;
					
						
					case "Exit":
						Application.Quit ();
						
						break;
						
					case "Save":
						if(!repetido){
							Save.GetComponent<TextMesh>().color = Color.gray;

							SaveLoad save=new SaveLoad(puntuacion,intentos,Mathf.RoundToInt(reloj));
							save.Save();

							modelo1.SetActive(false);
							modelo2.SetActive(false);
							opcion2.SetActive(false);
							opcion1_3.SetActive(false);
							opcion1.SetActive(false);
							opcion1_2.SetActive(false);
							SeguirJugando.SetActive(true);
							No.SetActive(true);
							Si.SetActive(true);
							saveActivo=true;
						}
						break;

					case "Si":
						SeguirJugando.SetActive(false);
						No.SetActive(false);
						Si.SetActive(false);
						saveActivo=false;
					
						if(i==0){
							modelo1.SetActive(true);
							modelo2.SetActive(false);
							opcion2.SetActive(false);
							opcion1_3.SetActive(true);
							opcion1.SetActive(true);
							opcion1_2.SetActive(true);
							
						}
						if(i==1){
							modelo1.SetActive(false);
							modelo2.SetActive(true);
							opcion1.SetActive(false);
							opcion1_2.SetActive(true);
							opcion1_3.SetActive(true);
							opcion2.SetActive(true);
							
						}
						break;
						
					case "No":
						Application.Quit();
						
						break;
			

					case "reintentar":
						if(i==0){
							retry=false;
							reintentar.SetActive(false);
							TimeOut.SetActive(false);
							TimeOut2.SetActive(false);
							opcion1.SetActive(true);
							opcion1_2.SetActive(true);
							opcion1_3.SetActive(true);
							opcion2.SetActive(false);
							tiempo=10;
						}
						if(i==2){
							retry=false;
							reintentar.SetActive(false);
							TimeOut.SetActive(false);
							TimeOut2.SetActive(false);
							opcion1.SetActive(false);
							opcion1_2.SetActive(true);
							opcion1_3.SetActive(true);
							opcion2.SetActive(true);
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
					opcion2.GetComponent<TextMesh>().color = Color.magenta;
					opcion1_2.GetComponent<TextMesh>().color = Color.magenta;
					opcion1_3.GetComponent<TextMesh>().color = Color.magenta;
				}
			}
		}

		if(!saveActivo){
			if(intentos>0){
				if(tiempo>0){
					tiempo=tiempo-Time.deltaTime;
					Timer.GetComponent<TextMesh>().text=Mathf.RoundToInt(tiempo).ToString();
					Timer.GetComponent<TextMesh>().color=Color.black;
					
					if(tiempo<3.5){
						Timer.GetComponent<TextMesh>().color=Color.red;
					}
				}
				
				if(Mathf.RoundToInt(tiempo)==0 && !retry)
				{
					if(intentos==1){

						CeroIntentos.SetActive(true);
						opcion1.SetActive(false);
						opcion1_2.SetActive(false);
						opcion1_3.SetActive(false);
						opcion2.SetActive(false);
						
						intentos=intentos-1;
					
						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
					}
					if(intentos==2){
						TimeOut.SetActive(true);
						reintentar.SetActive(true);
						opcion1.SetActive(false);
						opcion1_2.SetActive(false);
						opcion1_3.SetActive(false);
						opcion2.SetActive(false);
						
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						retry=true;
					}
					if(intentos==3){
						TimeOut2.SetActive(true);
						reintentar.SetActive(true);
						opcion1.SetActive(false);
						opcion1_2.SetActive(false);
						opcion1_3.SetActive(false);
						opcion2.SetActive(false);
						
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						retry=true;
					}
				}
			}
			
			if(intentos==0){
				if(!repetido){
					SaveLoad save=new SaveLoad(195,3,0);
					save.Save();
				}
				Application.LoadLevel("Vocabulario9");
			}
		}

		if(correcto){
			if(i==2){

				puntuacion+=5;
				SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
				if(!repetido){
					SaveLoad save=new SaveLoad(puntuacion,intentos,Mathf.RoundToInt(reloj));
					save.Save();
				}
			
				Application.LoadLevel("Ejercicios9_2");
				correcto=false;
			}
			if(i==1){

				puntuacion+=5;
				SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
				correcto=false;
				configuracion();

				i=2;
			}
		}
	}

	void configuracion(){
		Incorrecto.SetActive(false);
		opcion1.SetActive(false);
		opcion1_2.SetActive(true);
		opcion2.SetActive(true);
		opcion1_3.SetActive(true);
		modelo1.SetActive(false);
		modelo2.SetActive(true);
		tiempo=10;
		i=2;
	}
}



