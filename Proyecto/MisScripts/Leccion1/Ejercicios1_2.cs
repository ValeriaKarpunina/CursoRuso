using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Ejercicios1_2 : MonoBehaviour
{

	private int i,k;

	private Touch tocar;
	private Camera cam;
	private RaycastHit hit;
	private Ray ray;
	private bool correcto;
	private int puntuacion;
	private int intentos;
	private float tiempo;
	private float reloj;
	private GameObject Ya, Student,Est,Byt, Nada, Score,Menya, Nombre,zovut,tebya, imya, Corregir,
	Correcto, Incorrecto, SCORE, Vocabulario, Dialogo, Escuchar, Exit, Save,TimeOut,Intentos,reintentar,watch, 
	CeroIntentos,TimeOut2,Timer,SeguirJugando,Si,No;
	private Vector3 mousePos, worldPos;
	private Vector2 posZovut, posNada;
	private bool retry,saveActivo,repetido;
	private string leaderboard = "CgkIuJ7wrLMXEAIQBg";
	private int[] valores=new int[3];
	
	void Start(){
		if (cam == null){
			cam = Camera.main;
		}

		SCORE=GameObject.Find("SCORE");

		Menya=GameObject.Find("Menya");
		Nombre=GameObject.Find("Nombre");
		zovut=GameObject.Find("zovut");
		tebya=GameObject.Find("tebya");
		imya=GameObject.Find("imya");

		Ya=GameObject.Find("Ya");
		Student=GameObject.Find("Student");
		Est=GameObject.Find("Est");
		Byt=GameObject.Find("Byt");
		Nada=GameObject.Find("Nada");

		Incorrecto=GameObject.Find("Incorrecto");
		Correcto=GameObject.Find("Correcto");
		Corregir=GameObject.Find("Corregir");

		Vocabulario=GameObject.Find("Vocabulario");
		Dialogo=GameObject.Find("Dialogo");
		Escuchar=GameObject.Find("Escuchar");
		Exit=GameObject.Find("Exit");
		Save=GameObject.Find("Save");

		reintentar=GameObject.Find("reintentar");
		Timer=GameObject.Find("Timer");
		TimeOut=GameObject.Find("TimeOut");
		TimeOut2=GameObject.Find("TimeOut2");
		Intentos=GameObject.Find("Intentos");
		CeroIntentos=GameObject.Find("CeroIntentos");
		watch=GameObject.Find("watch");
		SeguirJugando=GameObject.Find("SeguirJugando");
		Si=GameObject.Find("Si");
		No=GameObject.Find("No");

		Incorrecto.SetActive(false);
		Correcto.SetActive(false);
		Nada.SetActive(false);
		Est.SetActive(false);
		Byt.SetActive(false);
		Ya.SetActive(false);
		Student.SetActive(false);
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
		reloj=(float) valores[2];

		watch.GetComponent<TextMesh>().text=Mathf.RoundToInt(reloj).ToString();
		tiempo=10;
		retry=false;
		Timer.GetComponent<TextMesh>().text=Mathf.Round(tiempo).ToString();
		Intentos.GetComponent<TextMesh>().text=intentos.ToString();

		repetido=false;

		if(puntuacion==10){
			i=1;
		}
		else if(puntuacion==15){
			configuracion();
			i=2;
		}
		else{
			repetido=true;
			puntuacion=10;
			reloj=0;
			intentos=3;
			i=1;
		}


		SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();
	
		correcto=false;

		reintentar.SetActive(false);
		CeroIntentos.SetActive(false);
		TimeOut.SetActive(false);
		TimeOut2.SetActive(false);
		saveActivo=false;
	}

	void Update(){

		if(!retry && !saveActivo){
			reloj=reloj+Time.deltaTime;
			watch.GetComponent<TextMesh>().text=Mathf.RoundToInt(reloj).ToString();
		}

		if (Input.touchCount > 0)
		{
			Touch theTouch = Input.GetTouch(0);
			
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit))
			{
					if (theTouch.phase == TouchPhase.Began)
					{
						switch(hit.transform.name){
							case "Corregir":

							if(i==1){
							//Una vez se ponga en correcto, siempre se pone en correcto
							//if(zovut.transform.position.y >= Menya.transform.position.y){
							if(zovut.transform.position.x < 500){
									Correcto.SetActive(true);
									Incorrecto.SetActive(false);
									correcto=true;
									
								}
								else{
									Correcto.SetActive(false);
									Incorrecto.SetActive(true);
									intentos=intentos-1;

									Intentos.GetComponent<TextMesh>().text=intentos.ToString();
								}
							}

							if(i==2){
								//Una vez se ponga en correcto, siempre se pone en correcto
							//if(Nada.transform.position.y >= Ya.transform.position.y){
							if(Nada.transform.position.x < 500){
									Correcto.SetActive(true);
									Incorrecto.SetActive(false);
									correcto=true;
									
								}
								else{
									Correcto.SetActive(false);
									Incorrecto.SetActive(true);
									intentos=intentos-1;
				
									Intentos.GetComponent<TextMesh>().text=intentos.ToString();
								}
							}

							break;

						case "reintentar":
							if(i==1){
								retry=false;
								reintentar.SetActive(false);
								TimeOut.SetActive(false);
								TimeOut2.SetActive(false);
								Corregir.SetActive(true);
								imya.SetActive(true);
								tebya.SetActive(true);
								zovut.SetActive(true);
								Nada.SetActive(false);
								Est.SetActive(false);
								Byt.SetActive(false);
								tiempo=10;
							}
							if(i==2){
								retry=false;
								reintentar.SetActive(false);
								TimeOut.SetActive(false);
								TimeOut2.SetActive(false);
								Corregir.SetActive(true);
								zovut.SetActive(false);
								Nada.SetActive(true);
								Est.SetActive(true);
								Byt.SetActive(true);
								imya.SetActive(false);
								tebya.SetActive(false);
								tiempo=10;
							}
							break;

				
						case "Save":
							if(!repetido){
								Save.GetComponent<TextMesh>().color = Color.gray;
								
								SaveLoad save=new SaveLoad(puntuacion,intentos,Mathf.RoundToInt(reloj));
								save.Save();

								imya.SetActive(false);
								tebya.SetActive(false);
								Nada.SetActive(false);
								zovut.SetActive(false);
								Est.SetActive(false);
								Byt.SetActive(false);
								Corregir.SetActive(false);
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
						
						if(i==1){
							
							imya.SetActive(true);
							tebya.SetActive(true);
							zovut.SetActive(true);
							Nada.SetActive(false);
							Est.SetActive(false);
							Byt.SetActive(false);
						}
						if(i==2){
							
							zovut.SetActive(false);
							imya.SetActive(false);
							tebya.SetActive(false);
							Nada.SetActive(true);
							Est.SetActive(true);
							Byt.SetActive(true);
						}
						break;
						
					case "No":
						Application.Quit();
						
						break;	

							
					case "Exit":
						Application.Quit ();
							
						break;
						
					}
					}
					if (theTouch.phase == TouchPhase.Moved)
					{
						if(i==1){

							switch(hit.transform.name){

								case "zovut":
								    zovut.GetComponent<TextMesh>().color = Color.gray;
									Incorrecto.SetActive(false);
									Correcto.SetActive(false);
									mousePos = Input.mousePosition;
									mousePos.z=844;
									worldPos = cam.ScreenToWorldPoint(mousePos);
									hit.transform.position = worldPos;
								
									break;

								case "tebya":
									tebya.GetComponent<TextMesh>().color = Color.gray;
									Incorrecto.SetActive(false);
									Correcto.SetActive(false);
									mousePos = Input.mousePosition;
									mousePos.z=844;
									worldPos = cam.ScreenToWorldPoint(mousePos);
									hit.transform.position = worldPos;
								

									break;

								case "imya":
								    imya.GetComponent<TextMesh>().color = Color.gray;
									Incorrecto.SetActive(false);
									Correcto.SetActive(false);
									mousePos = Input.mousePosition;
									mousePos.z=844;
									worldPos = cam.ScreenToWorldPoint(mousePos);
									hit.transform.position = worldPos;
								
									break;
								}
							}

							if(i==2){
								switch(hit.transform.name){

									case "Nada":
										Nada.GetComponent<TextMesh>().color = Color.gray;
										Incorrecto.SetActive(false);
										Correcto.SetActive(false);
										mousePos = Input.mousePosition;
										mousePos.z=844;
										worldPos = cam.ScreenToWorldPoint(mousePos);
										posNada.x=worldPos.x;
										hit.transform.position = worldPos;
										
									break;
									
									case "Est":
										Est.GetComponent<TextMesh>().color = Color.gray;
										Incorrecto.SetActive(false);
										Correcto.SetActive(false);
										mousePos = Input.mousePosition;
										mousePos.z=844;
										worldPos = cam.ScreenToWorldPoint(mousePos);
										hit.transform.position = worldPos;
									
									break;
									
									case "Byt":
										Byt.GetComponent<TextMesh>().color = Color.gray;
										Incorrecto.SetActive(false);
										Correcto.SetActive(false);
										mousePos = Input.mousePosition;
										mousePos.z=844;
										worldPos = cam.ScreenToWorldPoint(mousePos);
										hit.transform.position = worldPos;
									
									break;
								}
							}
					    }

					if (theTouch.phase == TouchPhase.Ended)
					{
						Correcto.SetActive(false);
						Incorrecto.SetActive(false);
						Byt.GetComponent<TextMesh>().color = Color.black;
						Est.GetComponent<TextMesh>().color = Color.black;
						Nada.GetComponent<TextMesh>().color = Color.black;
						imya.GetComponent<TextMesh>().color = Color.black;
						tebya.GetComponent<TextMesh>().color = Color.black;
						zovut.GetComponent<TextMesh>().color = Color.black;
						Save.GetComponent<TextMesh>().color = Color.red;
					}
				
			}
		}

		if(i==1){
			if(correcto){

				puntuacion+=5;
				SCORE.GetComponent<TextMesh>().text =puntuacion.ToString();

				configuracion();
				correcto=false;
				i=2;
			}
		}
	
		if(i==2){
			if(correcto){
	
				puntuacion+=5;
				SCORE.GetComponent<TextMesh>().text = puntuacion.ToString();

				if(!repetido){
					SaveLoad save=new SaveLoad(puntuacion,intentos,Mathf.RoundToInt(reloj),1,Mathf.RoundToInt(reloj));
					save.Save();
				}

				Application.LoadLevel("Lecciones");

				correcto=false;
				i=3;
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

						Nada.SetActive(false);
						zovut.SetActive(false);
						tebya.SetActive(false);
						imya.SetActive(false);
						Corregir.SetActive(false);
						CeroIntentos.SetActive(true);
						Correcto.SetActive(false);
						Incorrecto.SetActive(false);

						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();

					}
					if(intentos==2){
						TimeOut.SetActive(true);
						reintentar.SetActive(true);
						Nada.SetActive(false);
						zovut.SetActive(false);
						tebya.SetActive(false);
						imya.SetActive(false);
						Corregir.SetActive(false);
						Correcto.SetActive(false);
						Incorrecto.SetActive(false);

						intentos=intentos-1;

						Intentos.GetComponent<TextMesh>().text=intentos.ToString();
						retry=true;
					}
					if(intentos==3){
						TimeOut2.SetActive(true);
						reintentar.SetActive(true);
						Corregir.SetActive(false);
						Nada.SetActive(false);
						zovut.SetActive(false);
						tebya.SetActive(false);
						imya.SetActive(false);
						Correcto.SetActive(false);
						Incorrecto.SetActive(false);

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
	}

	void configuracion(){
		Nombre.SetActive(false);
		Menya.SetActive(false);
		zovut.SetActive(false);
		imya.SetActive(false);
		tebya.SetActive(false);
		
		Nada.SetActive(true);
		Est.SetActive(true);
		Byt.SetActive(true);
		Ya.SetActive(true);
		Student.SetActive(true);

		tiempo=10;
	}
}


	
