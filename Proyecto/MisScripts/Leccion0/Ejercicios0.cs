using UnityEngine; //para monobehaviour
using System.Collections; //para monobehaviour
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Ejercicios0: MonoBehaviour
{
	
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	bool correcto,retry,saveActivo;
	int j,m;
	int puntuacion;
	GameObject modelo2,modelo1,opcion1, opcion2, opcion1_2,opcion1_3, SCORE, Correcto, Incorrecto,
	Vocabulario, Dialogo, Escuchar, Exit, Save,Ranking, Timer,TimeOut,Intentos, reintentar, CeroIntentos,
	TimeOut2,watch,SeguirJugando,Si,No,PlayGlobal,Vpered,Nazad,PausaGlobal,p,dev,mal;

	Vector3 mousePos, worldPos;
	private string leaderboard = "CgkIuJ7wrLMXEAIQBg";
	float tiempo;
	int intentos;
	float reloj;
	int[] valores=new int[4];
	float Pitch;

	void Start(){
		if (cam == null){
			cam = Camera.main;
		}
		p=GameObject.Find("p");
		SCORE=GameObject.Find("SCORE");
		Timer=GameObject.Find("Timer");

		dev=GameObject.Find("dev");
		mal=GameObject.Find("mal");

		Dialogo=GameObject.Find("Dialogo");
		Exit=GameObject.Find("Exit");
		Save=GameObject.Find("Save");
		TimeOut2=GameObject.Find("TimeOut2");
		Intentos=GameObject.Find("Intentos");
		reintentar=GameObject.Find("reintentar");
		watch=GameObject.Find("watch");
		SeguirJugando=GameObject.Find("SeguirJugando");
		Si=GameObject.Find("Si");
		No=GameObject.Find("No");

		PlayGlobal=GameObject.Find("PlayGlobal");
		Vpered=GameObject.Find("Vpered");
		Nazad=GameObject.Find("Nazad");
		PausaGlobal=GameObject.Find("PausaGlobal");

		reintentar.SetActive(false);
		TimeOut2.SetActive(false);
		SeguirJugando.SetActive(false);
		No.SetActive(false);
		Si.SetActive(false);
		p.SetActive(false);

		j=0;
		tiempo=10;
		intentos=3;
		reloj=0;
		puntuacion=30;
		Timer.GetComponent<TextMesh>().text=Mathf.Round(tiempo).ToString();
		watch.GetComponent<TextMesh>().text=Mathf.Round(reloj).ToString();
		SCORE.GetComponent<TextMesh>().text =puntuacion.ToString();
		Intentos.GetComponent<TextMesh>().text=intentos.ToString();

		saveActivo=false;

		retry=false;
	}

	void Update(){

		if(!saveActivo && !retry){
			reloj=reloj+Time.deltaTime;
		}

		watch.GetComponent<TextMesh>().text=Mathf.RoundToInt(reloj).ToString();
		Timer.GetComponent<TextMesh>().text=Mathf.Round(tiempo).ToString();
		watch.GetComponent<TextMesh>().text=Mathf.Round(reloj).ToString();
		SCORE.GetComponent<TextMesh>().text =puntuacion.ToString();
		Intentos.GetComponent<TextMesh>().text=intentos.ToString();

		if (Input.touchCount > 0)
		{
			Touch theTouch = Input.GetTouch(0);
			
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit))
			{
				if (theTouch.phase == TouchPhase.Began)
				{
					switch(hit.transform.name){
						
					case "Dialogo":
						
						Application.LoadLevel("Dialogo0");
						break;
						
					case "PlayGlobal":
						
						if(!PlayGlobal.GetComponent<AudioSource>().isPlaying){
							PlayGlobal.GetComponent<AudioSource>().Play();
							Pitch=PlayGlobal.GetComponent<AudioSource>().pitch;
						}
					break;

					case "PausaGlobal":
						if(PlayGlobal.GetComponent<AudioSource>().isPlaying){
							PlayGlobal.GetComponent<AudioSource>().Pause();
						}
					
					break;
					}
				}

				if(theTouch.phase == TouchPhase.Stationary){
					switch(hit.transform.name){
					case "Vpered":
						
						if(PlayGlobal.GetComponent<AudioSource>().isPlaying){
							PlayGlobal.GetComponent<AudioSource>().pitch=Pitch*3;
						}
						
						break;
						
					case "Nazad":
						
						if(PlayGlobal.GetComponent<AudioSource>().isPlaying){
							j=j+1;
							PlayGlobal.GetComponent<AudioSource>().pitch=(Pitch-j)/2;
						}
					break;
					}
				}
				if (theTouch.phase == TouchPhase.Ended)
				{
					j=0;
					PlayGlobal.GetComponent<AudioSource>().pitch=Pitch;
				}
			}
		}

		if(Mathf.RoundToInt(reloj)>36){
			
			SeguirJugando.SetActive(false);
			No.SetActive(false);
			Si.SetActive(false);

		}

		if(Mathf.RoundToInt(reloj)>25 && Mathf.RoundToInt(reloj)<36){
			p.SetActive(true);
			SeguirJugando.SetActive(true);
			Si.SetActive(true);
			No.SetActive(true);

			TimeOut2.SetActive(false);
			reintentar.SetActive(false);
			
		}

		if(Mathf.RoundToInt(reloj)>10 && Mathf.RoundToInt(reloj)<25){

			SeguirJugando.SetActive(false);
			No.SetActive(false);
			Si.SetActive(false);
			dev.SetActive(false);
			mal.SetActive(false);
		}

		if(Mathf.RoundToInt(reloj)>6 && Mathf.RoundToInt(reloj)<10){

			SeguirJugando.SetActive(false);
			No.SetActive(false);
			Si.SetActive(false);
			
		}

		if(Mathf.RoundToInt(reloj)>2 && Mathf.RoundToInt(reloj)<6){
	
			SeguirJugando.SetActive(false);
			No.SetActive(false);
			Si.SetActive(false);

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
					if(intentos==3){
						TimeOut2.SetActive(true);
						reintentar.SetActive(true);
						
						intentos=intentos-1;
					
						Intentos.GetComponent<TextMesh>().text=intentos.ToString();

					}
				}
			}
		}
	}
}


	
