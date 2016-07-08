using UnityEngine; //para monobehaviour
using System.Collections; //para monobehaviour
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Ejercicios3_1 : MonoBehaviour
{
	
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	bool correcto,retry,saveActivo,repetido;
	int i;
	int puntuacion;
	GameObject palabra1,palabra2,palabra3,eleccion1,eleccion2,eleccion3,eleccion4,eleccion5,eleccion6, SCORE, Correcto, Incorrecto,
	Vocabulario, Dialogo, Escuchar, Exit, Save,Ranking, Timer,TimeOut,Intentos, reintentar, CeroIntentos,
	TimeOut2,watch,SeguirJugando,Si,No;
	Vector3 mousePos, worldPos;
	private string leaderboard = "CgkIuJ7wrLMXEAIQBg";
	float tiempo;
	int intentos;
	float reloj;
	int[] valores=new int[3];
	
	void Start(){
		if (cam == null){
			cam = Camera.main;
		}

		SCORE=GameObject.Find("SCORE");
		Timer=GameObject.Find("Timer");

		palabra1=GameObject.Find("palabra1");
		palabra2=GameObject.Find("palabra2");
		palabra3=GameObject.Find("palabra3");
		eleccion1=GameObject.Find("eleccion1");
		eleccion2=GameObject.Find("eleccion2");
		eleccion3=GameObject.Find("eleccion3");
		eleccion4=GameObject.Find("eleccion4");
		eleccion5=GameObject.Find("eleccion5");
		eleccion6=GameObject.Find("eleccion6");

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
		reintentar.SetActive(false);
		CeroIntentos.SetActive(false);
		TimeOut.SetActive(false);
		TimeOut2.SetActive(false);
		SeguirJugando.SetActive(false);
		No.SetActive(false);
		Si.SetActive(false);
		palabra2.SetActive(false);
		palabra3.SetActive(false);

		SaveLoad load = new SaveLoad();
		valores=load.Load();

		if(valores[0]==0 && valores[1]==0 && valores[2]==0){
			SaveLoad load1 = new SaveLoad();
			valores=load1.Load();
		}

		puntuacion=valores[0];
		reloj=valores[1];
		intentos=valores[2];
		repetido=false;

		if(puntuacion==50){
			i=1; // para que solo se sumen los puntos una vez al acertar primera frase
		}
		else if(puntuacion==55){
			i=2;
		}
		else if(puntuacion==60){
			i=3;
		}
		else{
			repetido=true;
			puntuacion=50;
			reloj=0;
			intentos=3;
		}

		tiempo=10;
		Timer.GetComponent<TextMesh>().text=Mathf.Round(tiempo).ToString();
		watch.GetComponent<TextMesh>().text=Mathf.Round(reloj).ToString();
		Intentos.GetComponent<TextMesh>().text=intentos.ToString();
		SCORE.GetComponent<TextMesh>().text =puntuacion.ToString();

		saveActivo=false;
		retry=false;
		correcto=false;
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
						
					case "eleccion1":
					
						eleccion1.GetComponent<TextMesh>().color = Color.gray;
						Correcto.SetActive(false);
						Incorrecto.SetActive(true);
						intentos=intentos-1;
					
						Intentos.GetComponent<TextMesh>().text=intentos.ToString();

						break;
						
					case "eleccion2":
						if(i==2){
							eleccion2.GetComponent<TextMesh>().color = Color.gray;
							correcto=true;
						}else{
							eleccion2.GetComponent<TextMesh>().color = Color.gray;
							Correcto.SetActive(false);
							Incorrecto.SetActive(true);
							intentos=intentos-1;
						
							Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						}

						break;
						
					case "eleccion3":
						if(i==1){
							eleccion3.GetComponent<TextMesh>().color = Color.gray;
							correcto=true;
						}else{
							eleccion3.GetComponent<TextMesh>().color = Color.gray;
							Correcto.SetActive(false);
							Incorrecto.SetActive(true);
							intentos=intentos-1;

							Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						}

						break;
						
					case "eleccion4":
						
						if(i==3){
							eleccion4.GetComponent<TextMesh>().color = Color.gray;
							correcto=true;
						}else{
							eleccion4.GetComponent<TextMesh>().color = Color.gray;
							Correcto.SetActive(false);
							Incorrecto.SetActive(true);
							intentos=intentos-1;
						
							Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						}
						break;

					case "eleccion5":
						eleccion5.GetComponent<TextMesh>().color = Color.gray;
						Correcto.SetActive(false);
						Incorrecto.SetActive(true);
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						break;

					case "eleccion6":
						eleccion6.GetComponent<TextMesh>().color = Color.gray;
						Correcto.SetActive(false);
						Incorrecto.SetActive(true);
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						break;

						
					case "reintentar":
						if(i==1){
							retry=false;
							reintentar.SetActive(false);
							TimeOut.SetActive(false);
							TimeOut2.SetActive(false);
							palabra1.SetActive(true);
							palabra2.SetActive(false);
							palabra3.SetActive(false);

							eleccion1.SetActive(true);
							eleccion2.SetActive(true);
							eleccion3.SetActive(true);
							eleccion4.SetActive(true);
							eleccion5.SetActive(true);
							eleccion6.SetActive(true);
							tiempo=10;
						}
						if(i==2){
							retry=false;
							reintentar.SetActive(false);
							TimeOut.SetActive(false);
							TimeOut2.SetActive(false);
							palabra1.SetActive(false);
							palabra2.SetActive(true);
							palabra3.SetActive(false);

							eleccion1.SetActive(true);
							eleccion2.SetActive(true);
							eleccion3.SetActive(true);
							eleccion4.SetActive(true);
							eleccion5.SetActive(true);
							eleccion6.SetActive(true);
							tiempo=10;
						}
						if(i==3){
							retry=false;
							reintentar.SetActive(false);
							TimeOut.SetActive(false);
							TimeOut2.SetActive(false);
							palabra1.SetActive(false);
							palabra2.SetActive(false);
							palabra3.SetActive(true);

							eleccion1.SetActive(true);
							eleccion2.SetActive(true);
							eleccion3.SetActive(true);
							eleccion4.SetActive(true);
							eleccion5.SetActive(true);
							eleccion6.SetActive(true);
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
						
							palabra1.SetActive(false);
							palabra2.SetActive(false);
							palabra3.SetActive(false);
							eleccion1.SetActive(false);
							eleccion2.SetActive(false);
							eleccion3.SetActive(false);
							eleccion4.SetActive(false);
							eleccion5.SetActive(false);
							eleccion6.SetActive(false);
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

						eleccion1.SetActive(true);
						eleccion2.SetActive(true);
						eleccion3.SetActive(true);
						eleccion4.SetActive(true);
						eleccion5.SetActive(true);
						eleccion6.SetActive(true);
				
						
						if(i==1){
							
							palabra1.SetActive(true);
							palabra2.SetActive(false);
							palabra3.SetActive(false);
							
						}
						if(i==2){
							
							palabra1.SetActive(false);
							palabra2.SetActive(true);
							palabra3.SetActive(false);
							
						}
						if(i==3){
							
							palabra1.SetActive(false);
							palabra2.SetActive(false);
							palabra3.SetActive(true);
							
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
					eleccion1.GetComponent<TextMesh>().color=Color.yellow;
					eleccion2.GetComponent<TextMesh>().color=Color.yellow;
					eleccion3.GetComponent<TextMesh>().color=Color.yellow;
					eleccion4.GetComponent<TextMesh>().color=Color.yellow;
					eleccion5.GetComponent<TextMesh>().color=Color.yellow;
					eleccion6.GetComponent<TextMesh>().color=Color.yellow;
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
						palabra1.SetActive(false);
						palabra2.SetActive(false);
						palabra3.SetActive(false);
						eleccion1.SetActive(false);
						eleccion2.SetActive(false);
						eleccion3.SetActive(false);
						eleccion4.SetActive(false);
						eleccion5.SetActive(false);
						eleccion6.SetActive(false);
						
						intentos=intentos-1;
					
						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
					}
					if(intentos==2){
						TimeOut.SetActive(true);
						reintentar.SetActive(true);
						palabra1.SetActive(false);
						palabra2.SetActive(false);
						palabra3.SetActive(false);
						eleccion1.SetActive(false);
						eleccion2.SetActive(false);
						eleccion3.SetActive(false);
						eleccion4.SetActive(false);
						eleccion5.SetActive(false);
						eleccion6.SetActive(false);
						
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						retry=true;
					}
					if(intentos==3){
						TimeOut2.SetActive(true);
						reintentar.SetActive(true);
						palabra1.SetActive(false);
						palabra2.SetActive(false);
						palabra3.SetActive(false);
						eleccion1.SetActive(false);
						eleccion2.SetActive(false);
						eleccion3.SetActive(false);
						eleccion4.SetActive(false);
						eleccion5.SetActive(false);
						eleccion6.SetActive(false);
						
						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						retry=true;
					}
				}
			}
			
			if(intentos==0){
				if(!repetido){
					SaveLoad save=new SaveLoad(40,3,0);
					save.Save();
				}
				Application.LoadLevel("Vocabulario3");
			}
		}
		if(correcto){
	
			if(i==3){

				puntuacion+=5;
				SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
				if(!repetido){
					SaveLoad save=new SaveLoad(puntuacion,intentos,Mathf.RoundToInt(reloj),3,Mathf.RoundToInt(reloj));
					save.Save();
				}
				correcto=false;
				Application.LoadLevel("Lecciones");
				
			}

			if(i==2){
				palabra1.SetActive(false);
				palabra2.SetActive(false);
				palabra3.SetActive(true);

				puntuacion+=5;
				SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
				correcto=false;

				tiempo=10;
				i=3;
			}

			if(i==1){
				palabra1.SetActive(false);
				palabra2.SetActive(true);
				palabra3.SetActive(false);
			
				puntuacion+=5;
				SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
				correcto=false;

				tiempo=10;
				i=2;
			}
		}
	}
}