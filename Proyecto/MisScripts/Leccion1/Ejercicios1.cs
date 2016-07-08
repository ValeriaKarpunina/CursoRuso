using UnityEngine; //para monobehaviour
using System.Collections; //para monobehaviour
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Ejercicios1 : MonoBehaviour
{
	
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	bool correcto,retry,saveActivo,repetido;
	int i,j,m;
	int puntuacion;
	GameObject modelo2,modelo1,opcion1, opcion2, opcion1_2,opcion1_3, SCORE, Correcto, Incorrecto,
	Vocabulario, Dialogo, Escuchar, Exit, Save,Ranking, Timer,TimeOut,Intentos, reintentar, CeroIntentos,
	TimeOut2,watch,SeguirJugando,Si,No;

	Vector3 mousePos, worldPos;
	private string leaderboard = "CgkIuJ7wrLMXEAIQBg";
	float tiempo;
	int intentos;
	float reloj;
	int[] valores=new int[4];

	void Start(){
		if (cam == null){
			cam = Camera.main;
		}

		SCORE=GameObject.Find("SCORE");
		Timer=GameObject.Find("Timer");
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
		TimeOut=GameObject.Find("TimeOut");
		TimeOut2=GameObject.Find("TimeOut2");
		Intentos=GameObject.Find("Intentos");
		Ranking=GameObject.Find("Ranking");
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

		SaveLoad load = new SaveLoad();
		valores=load.Load();

		if(valores[0]==0 && valores[1]==0 && valores[2]==0){
			SaveLoad load1 = new SaveLoad();
			valores=load1.Load();
		}

	    puntuacion=valores[0];

		repetido=false;

		if(puntuacion>5){
			repetido=true;
			puntuacion=0;
			i=0; 
			j=0;
			reloj=0;
			intentos=3;
		}

		if(puntuacion==0){
			i=0; 
			j=0;
			reloj=0;
			intentos=3;
		}

		if(puntuacion==5){
			configuracion();
			reloj=valores[2];
			intentos=valores[1];
		}
		correcto=false;

		tiempo=10;
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
							j=1;
							break;

						case "opcion1_3":
							
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

						case "Exit":
							Application.Quit ();
							
							break;

						case "Save":
							if(!repetido){
								Save.GetComponent<TextMesh>().color = Color.gray;
								
								SaveLoad save=new SaveLoad(puntuacion,intentos,Mathf.RoundToInt(reloj));
								save.Save();

								opcion1.SetActive(false);
								opcion1_2.SetActive(false);
								opcion1_3.SetActive(false);
								opcion2.SetActive(false);
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

								opcion1.SetActive(true);
								opcion1_2.SetActive(true);
								opcion1_3.SetActive(true);
								opcion2.SetActive(false);

							}
							if(i==2){

								opcion1.SetActive(false);
								opcion1_2.SetActive(true);
								opcion1_3.SetActive(true);
								opcion2.SetActive(true);

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
					SaveLoad save=new SaveLoad(0,3,0);
					save.Save();
				}
					Application.LoadLevel("Vocabulario1");
			}
		}
		if(correcto){
			
			if(i==1){

				puntuacion+=5;
				SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
				correcto=false;
				configuracion();

				i=2;
			}

			if(j==1){

				puntuacion+=5;
				SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
				if(!repetido){
					SaveLoad save=new SaveLoad(puntuacion,intentos,Mathf.RoundToInt(reloj));
					save.Save();
				}
				Application.LoadLevel("Ejercicios1_2");
			
				correcto=false;
				j=2;
			}
		}
	}

	void configuracion(){
		opcion1.SetActive(false);
		opcion2.SetActive(true);
		modelo1.SetActive(false);
		modelo2.SetActive(true);
		tiempo=10;
	}
}


	
