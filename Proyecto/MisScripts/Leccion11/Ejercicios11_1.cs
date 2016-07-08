using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Ejercicios11_1 : MonoBehaviour
{
	
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	bool correcto,retry,saveActivo,repetido;
	int i,j,m;
	int intentos;
	float tiempo;
	float reloj;
	public int puntuacion;
	GameObject modelo1,modelo2,modelo3,modelo4,palabra1,palabra2, SCORE, Correcto, Incorrecto,
	Anterior, Vocabulario, Dialogo, Escuchar, Exit, Save,Ranking,Timer,TimeOut,Intentos, reintentar,
	CeroIntentos,TimeOut2,watch,SeguirJugando,Si,No;
	Vector3 mousePos, worldPos;
	int[] valores=new int[3];
	private string leaderboard = "CgkIuJ7wrLMXEAIQBg";

	void Start(){
		if (cam == null){
			cam = Camera.main;
		}

		SCORE=GameObject.Find("SCORE");
		modelo1=GameObject.Find("modelo1");
		modelo2=GameObject.Find("modelo2");
		modelo3=GameObject.Find("modelo3");
		modelo4=GameObject.Find("modelo4");
		palabra1=GameObject.Find("palabra1");
		palabra2=GameObject.Find("palabra2");
	
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

		reintentar.SetActive(false);
		CeroIntentos.SetActive(false);
		TimeOut.SetActive(false);
		TimeOut2.SetActive(false);
		
		Incorrecto.SetActive(false);
		Correcto.SetActive(false);
		palabra2.SetActive(false);
		modelo4.SetActive(false);
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
		intentos=valores[1];
		reloj=valores[2];

		repetido=false;

		if(puntuacion==270){
			i=0; // para que solo se sumen los puntos una vez al acertar primera frase
			j=0;// para que solo se sumen los puntos una vez al acertar segunda frase	
		}
		else if(puntuacion==275){
			configuracion();
		}
		else{
			repetido=true;
			i=0;
			j=0;
			puntuacion=270;
			reloj=0;
			intentos=3;
		}
		correcto=false;
		retry=false;

		tiempo=10;
		
		Timer.GetComponent<TextMesh>().text=Mathf.Round(tiempo).ToString();
		Intentos.GetComponent<TextMesh>().text=intentos.ToString();
		watch.GetComponent<TextMesh>().text=Mathf.RoundToInt(reloj).ToString();
		SCORE.GetComponent<TextMesh>().text =puntuacion.ToString();
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
						
					case "modelo1":

						correcto=true;
						i=1;
					
						break;
						
					case "modelo2":
						Correcto.SetActive(false);
						Incorrecto.SetActive(true);
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();

						break;
						
					case "modelo3":
					
						Correcto.SetActive(false);
						Incorrecto.SetActive(true);
						intentos=intentos-1;
					
						Intentos.GetComponent<TextMesh>().text=intentos.ToString();

						break;
						
					case "modelo4":
						
						correcto=true;
						j=1;
						break;

					case "reintentar":
						if(i==0){
							retry=false;
							reintentar.SetActive(false);
							TimeOut.SetActive(false);
							TimeOut2.SetActive(false);
							modelo1.SetActive(true);
							modelo2.SetActive(true);
							modelo3.SetActive(true);
							modelo4.SetActive(false);
							tiempo=10;
						}
						if(i==1){
							retry=false;
							reintentar.SetActive(false);
							TimeOut.SetActive(false);
							TimeOut2.SetActive(false);
							modelo1.SetActive(false);
							modelo2.SetActive(true);
							modelo3.SetActive(true);
							modelo4.SetActive(true);
							tiempo=10;
						}
						break;


						
					case "Exit":
						Application.Quit ();
						
						break;
						
					case "Save":
						if(!repetido){
							Save.GetComponent<TextMesh>().color = Color.gray;
							SaveLoad save=new SaveLoad(puntuacion,intentos,Mathf.RoundToInt(reloj));
							save.Save();

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
							modelo2.SetActive(true);
							modelo3.SetActive(true);
							modelo4.SetActive(false);
							tiempo=10;
						}
						if(i==1){
							modelo1.SetActive(false);
							modelo2.SetActive(true);
							modelo3.SetActive(true);
							modelo4.SetActive(true);
							tiempo=10;
						}
						break;
						
					case "No":
						Application.Quit();
						
						break;
				
					}
				}
					if (theTouch.phase == TouchPhase.Ended)
					{
						Correcto.SetActive(false);
						Incorrecto.SetActive(false);
						Save.GetComponent<TextMesh>().color = Color.red;
						Ranking.GetComponent<TextMesh>().color = Color.red;

					}
			}
		}

		if(!saveActivo){
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
						modelo1.SetActive(false);
						modelo2.SetActive(false);
						modelo3.SetActive(false);
						modelo4.SetActive(false);
						
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();

					}
					if(intentos==2){
						TimeOut.SetActive(true);
						reintentar.SetActive(true);
						modelo1.SetActive(false);
						modelo2.SetActive(false);
						modelo3.SetActive(false);
						modelo4.SetActive(false);
						
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						retry=true;
					}
					if(intentos==3){
						TimeOut2.SetActive(true);
						reintentar.SetActive(true);
						modelo1.SetActive(false);
						modelo2.SetActive(false);
						modelo3.SetActive(false);
						modelo4.SetActive(false);
						
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						retry=true;
					}
				}
			}
			
			if(intentos==0){
				if(!repetido){
					SaveLoad save=new SaveLoad(245,3,0);
					save.Save();
				}
				Application.LoadLevel("Vocabulario11");
			}
		}
			if(correcto){
				
				if(i==1){
					puntuacion+=5;
					SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
					correcto=false;
					configuracion();
				}
				
				if(j==1){
					puntuacion+=5;
					SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
					if(!repetido){
						SaveLoad save=new SaveLoad(puntuacion,intentos,Mathf.RoundToInt(reloj),11,Mathf.RoundToInt(reloj));
						save.Save();
					}
					Application.LoadLevel("Lecciones");
					correcto=false;
					j=2;
				}
			}
	}
	void configuracion(){
		Correcto.SetActive(false);
		Incorrecto.SetActive(false);
		modelo1.SetActive(false);
		modelo4.SetActive(true);
		palabra1.SetActive(false);
		palabra2.SetActive(true);
		tiempo=10;
		i=2;
	}
}



