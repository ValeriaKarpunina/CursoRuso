using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Lecciones : MonoBehaviour
{
	GameObject Autenticado,Entrar,Exit,LeccionesPDF,Leccion0,Leccion1,Leccion2,Leccion3,Leccion4,Leccion5,Leccion6,
	Leccion7,Leccion8,Leccion9,Leccion10,Leccion11,Leccion12,Leccion13,Leccion14,Leccion15,Leccion16,Leccion17,Leccion18,Load,Ranking;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int puntuacion;
	int[] valores;

	public void Start () {
		
		PlayGamesPlatform.Activate();
	
		Leccion0=GameObject.Find("Leccion0");
		Leccion1=GameObject.Find("Leccion1");
		Leccion2=GameObject.Find("Leccion2");
		Leccion3=GameObject.Find("Leccion3");
		Leccion4=GameObject.Find("Leccion4");
		Leccion5=GameObject.Find("Leccion5");
		Leccion6=GameObject.Find("Leccion6");
		Leccion7=GameObject.Find("Leccion7");
		Leccion8=GameObject.Find("Leccion8");
		Leccion9=GameObject.Find("Leccion9");
		Leccion10=GameObject.Find("Leccion10");
		Leccion11=GameObject.Find("Leccion11");
		Leccion12=GameObject.Find("Leccion12");
		Leccion13=GameObject.Find("Leccion13");
		Leccion14=GameObject.Find("Leccion14");
		Leccion15=GameObject.Find("Leccion15");
		Leccion16=GameObject.Find("Leccion16");
		Leccion17=GameObject.Find("Leccion17");
		Leccion18=GameObject.Find("Leccion18");
		LeccionesPDF=GameObject.Find("LeccionesPDF");
		Exit=GameObject.Find("Exit");
		Autenticado=GameObject.Find("Autenticado");
		Load=GameObject.Find("Load");
		Ranking=GameObject.Find("Ranking");

		Leccion0.SetActive(false);
		Leccion1.SetActive(false);
		Leccion2.SetActive(false);
		Leccion3.SetActive(false);
		Leccion4.SetActive(false);
		Leccion5.SetActive(false);
		Leccion6.SetActive(false);
		Leccion7.SetActive(false);
		Leccion8.SetActive(false);
		Leccion9.SetActive(false);
		Leccion10.SetActive(false);
		Leccion11.SetActive(false);
		Leccion12.SetActive(false);
		Leccion13.SetActive(false);
		Leccion14.SetActive(false);
		Leccion15.SetActive(false);
		Leccion16.SetActive(false);
		Leccion17.SetActive(false);
		Leccion18.SetActive(false);

		//if(!Social.localUser.authenticated){
			Social.localUser.Authenticate((bool success) =>
			                              
			                              {
				if(success){
					valores=new int[3];
					SaveLoad load = new SaveLoad();
					valores=load.Load();
					
					if(valores[0]==0 && valores[1]==0 && valores[2]==0){
						SaveLoad load1 = new SaveLoad();
						valores=load1.Load();
					}
					
					puntuacion=valores[0];		
				}
			});

		//}



		if (cam == null){
			cam = Camera.main;
		}
	}
	
	void Update(){

		if (Input.touchCount > 0)
		{
			Touch theTouch = Input.GetTouch(0);
			
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (theTouch.phase == TouchPhase.Began)
				{
					switch(hit.transform.name){
				
					case "Exit":
						Application.Quit ();
						
						break;
					}
				}

			}
		}
		

		if(Social.localUser.authenticated){

			Autenticado.SetActive(false);
			ConectarGoogle(puntuacion);
			if (Input.touchCount > 0)
			{
				Touch theTouch = Input.GetTouch(0);
				
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);
				
				if (Physics.Raycast(ray, out hit))
				{
					if (theTouch.phase == TouchPhase.Began)
					{
						switch(hit.transform.name){

						case "LeccionesPDF":
							Application.OpenURL("https://github.com/ValeriaKarpunina/CursoRuso/tree/Lecciones/CursoRuso");
							break;

						case "Load":
							Load.GetComponent<TextMesh>().color = Color.gray;

							SaveLoad load = new SaveLoad();
							valores=load.Load();
								
							if(valores[0]==0 && valores[1]==0 && valores[2]==0){
								SaveLoad load1 = new SaveLoad();
								valores=load1.Load();
							}
								puntuacion=valores[0];
						
								Cargar(puntuacion);
						
							break;

						case "Leccion0":
							Application.LoadLevel("Vocabulario0");
							
							break;

						case "Leccion1":
							Application.LoadLevel("Vocabulario1");

							break;

						case "Leccion2":

							Application.LoadLevel("Vocabulario2");
						
							break;

						case "Leccion3":
							
							Application.LoadLevel("Vocabulario3");
							
							break;

						case "Leccion4":
							
							Application.LoadLevel("Vocabulario4");
							
							break;
						case "Leccion5":
							
							Application.LoadLevel("Vocabulario5");
							
							break;
						case "Leccion6":
							
							Application.LoadLevel("Vocabulario6");
							
							break;
						case "Leccion7":
							
							Application.LoadLevel("Vocabulario7");
							
							break;
						case "Leccion8":
							
							Application.LoadLevel("Vocabulario8");
							
							break;
						case "Leccion9":
							
							Application.LoadLevel("Vocabulario9");
							
							break;
						case "Leccion10":
							
							Application.LoadLevel("Vocabulario10");
							
							break;
						case "Leccion11":
							
							Application.LoadLevel("Vocabulario11");
							
							break;
						case "Leccion12":
							
							Application.LoadLevel("Vocabulario12");
							
							break;
						case "Leccion13":
							
							Application.LoadLevel("Vocabulario13");
							
							break;
						case "Leccion14":
							
							Application.LoadLevel("Vocabulario14");
							
							break;
						case "Leccion15":
							
							Application.LoadLevel("Vocabulario15");
							
							break;
						case "Leccion16":
							
							Application.LoadLevel("Vocabulario16");
							
							break;
						case "Leccion17":
							
							Application.LoadLevel("Vocabulario17");
							
							break;

						case "Leccion18":
							
							Application.LoadLevel("Vocabulario18");
							
							break;

						case "Ranking":
							Ranking.GetComponent<TextMesh>().color = Color.gray;
							Application.LoadLevel("Ranking");
							break;
						}
					}
				}
			}
		}else{
			Leccion0.SetActive(false);
			Leccion1.SetActive(false);
			Leccion2.SetActive(false);
			Leccion3.SetActive(false);
			Leccion4.SetActive(false);
			Leccion5.SetActive(false);
			Leccion6.SetActive(false);
			Leccion7.SetActive(false);
			Leccion8.SetActive(false);
			Leccion9.SetActive(false);
			Leccion10.SetActive(false);
			Leccion11.SetActive(false);
			Leccion12.SetActive(false);
			Leccion13.SetActive(false);
			Leccion14.SetActive(false);
			Leccion15.SetActive(false);
			Leccion16.SetActive(false);
			Leccion17.SetActive(false);
			Leccion18.SetActive(false);
		}
	}

	public void Cargar(int puntos){
		if(puntos>=0 && puntos<=5){
			Application.LoadLevel("Ejercicios1");
		}
		if(puntos>=10 && puntos<=15){
			Application.LoadLevel("Ejercicios1_2");
		}
		if(puntos>=20 && puntos<=25){
			Application.LoadLevel("Ejercicios2");
		}
		if(puntos>=30 && puntos<=35){
			Application.LoadLevel("Ejercicios2_1");
		}
		if(puntos>=40 && puntos<=45){
			Application.LoadLevel("Ejercicios3");
		}
		if(puntos>=50 && puntos<=60){
			Application.LoadLevel("Ejercicios3_1");
		}
		if(puntos>=65 && puntos<=70){
			Application.LoadLevel("Ejercicios4");
		}
		if(puntos>=75 && puntos<=80){
			Application.LoadLevel("Ejercicios4_1");
		}
		if(puntos>=100 && puntos<=105){
			Application.LoadLevel("Ejercicios5");
		}
		if(puntos>=110 && puntos<=120){
			Application.LoadLevel("Ejercicios5_1");
		}
		if(puntos>=125 && puntos<=130){
			Application.LoadLevel("Ejercicios6");
		}
		if(puntos>=135 && puntos<=145){
			Application.LoadLevel("Ejercicios6_1");
		}
		if(puntos>=150 && puntos<=160){
			Application.LoadLevel("Ejercicios7");
		}
		if(puntos>=165 && puntos<=170){
			Application.LoadLevel("Ejercicios7_2");
		}
		if(puntos>=175 && puntos<=180){
			Application.LoadLevel("Ejercicios8");
		}
		if(puntos>=185 && puntos<=190){
			Application.LoadLevel("Ejercicios8_2");
		}
		if(puntos>=195 && puntos<=200){
			Application.LoadLevel("Ejercicios9");
		}
		if(puntos>=205 && puntos<=225){
			Application.LoadLevel("Ejercicios9_2");
		}
		if(puntos>=230 && puntos<=240){
			Application.LoadLevel("Ejercicios10");
		}
		if(puntos>=245 && puntos<=265){
			Application.LoadLevel("Ejercicios11");
		}
		if(puntos>=270 && puntos<=275){
			Application.LoadLevel("Ejercicios11_1");
		}
		if(puntos>=280 && puntos<=290){
			Application.LoadLevel("Ejercicios12");
		}
		if(puntos>=295 && puntos<=305){
			Application.LoadLevel("Ejercicios12_1");
		}
		if(puntos>=310 && puntos<=315){
			Application.LoadLevel("Ejercicios13");
		}
		if(puntos>=320 && puntos<=340){
			Application.LoadLevel("Ejercicios13_1");
		}
		if(puntos>=345 && puntos<=360){
			Application.LoadLevel("Ejercicios14");
		}
		if(puntos>=365 && puntos<=370){
			Application.LoadLevel("Ejercicios15");
		}
		if(puntos>=375 && puntos<=395){
			Application.LoadLevel("Ejercicios16");
		}
		if(puntos>=400 && puntos<=410){
			Application.LoadLevel("Ejercicios17");
		}
		if(puntos>=415 && puntos<=420){
			Application.LoadLevel("Ejercicios18");
		}
	}


	public void ConectarGoogle(int puntos){
		if(Social.localUser.authenticated){
				if(puntos>=0 && puntos<20){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
				}

				if(puntos>=20 && puntos<40){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
				}

				if(puntos>=40 && puntos<65){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
				}
			
				if(puntos>=65 && puntos<100){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
			
				}
			
				if(puntos>=100 && puntos<125){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
				}
			
				if(puntos>=125 && puntos<150){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
				}

				if(puntos>=150 && puntos<175){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
				}
			
				if(puntos>=175 && puntos<195){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
					Leccion8.SetActive(true);
				}
			
				if(puntos>=195 && puntos<230){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
					Leccion8.SetActive(true);
					Leccion9.SetActive(true);
				}
			
				if(puntos>=230 && puntos<245){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
					Leccion8.SetActive(true);
					Leccion9.SetActive(true);
					Leccion10.SetActive(true);
				}
				if(puntos>=245 && puntos<280){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
					Leccion8.SetActive(true);
					Leccion9.SetActive(true);
					Leccion10.SetActive(true);
					Leccion11.SetActive(true);
				}

				if(puntos>=280 && puntos<310){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
					Leccion8.SetActive(true);
					Leccion9.SetActive(true);
					Leccion10.SetActive(true);
					Leccion11.SetActive(true);
					Leccion12.SetActive(true);
				}
	
				if(puntos>=310 && puntos<345){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
					Leccion8.SetActive(true);
					Leccion9.SetActive(true);
					Leccion10.SetActive(true);
					Leccion11.SetActive(true);
					Leccion12.SetActive(true);
					Leccion13.SetActive(true);
				}

				if(puntos>=345 && puntos<365){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
					Leccion8.SetActive(true);
					Leccion9.SetActive(true);
					Leccion10.SetActive(true);
					Leccion11.SetActive(true);
					Leccion12.SetActive(true);
					Leccion13.SetActive(true);
					Leccion14.SetActive(true);
				}
				if(puntos>=365 && puntos<375){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
					Leccion8.SetActive(true);
					Leccion9.SetActive(true);
					Leccion10.SetActive(true);
					Leccion11.SetActive(true);
					Leccion12.SetActive(true);
					Leccion13.SetActive(true);
					Leccion14.SetActive(true);
					Leccion15.SetActive(true);
				}
				if(puntos>=375 && puntos<400){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
					Leccion8.SetActive(true);
					Leccion9.SetActive(true);
					Leccion10.SetActive(true);
					Leccion11.SetActive(true);
					Leccion12.SetActive(true);
					Leccion13.SetActive(true);
					Leccion14.SetActive(true);
					Leccion15.SetActive(true);
					Leccion16.SetActive(true);

				}
				if(puntos>=400 && puntos<415){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
					Leccion8.SetActive(true);
					Leccion9.SetActive(true);
					Leccion10.SetActive(true);
					Leccion11.SetActive(true);
					Leccion12.SetActive(true);
					Leccion13.SetActive(true);
					Leccion14.SetActive(true);
					Leccion15.SetActive(true);
					Leccion16.SetActive(true);
					Leccion17.SetActive(true);

				}
				if(puntos>=415){
					Leccion0.SetActive(true);
					Leccion1.SetActive(true);
					Leccion2.SetActive(true);
					Leccion3.SetActive(true);
					Leccion4.SetActive(true);
					Leccion5.SetActive(true);
					Leccion6.SetActive(true);
					Leccion7.SetActive(true);
					Leccion8.SetActive(true);
					Leccion9.SetActive(true);
					Leccion10.SetActive(true);
					Leccion11.SetActive(true);
					Leccion12.SetActive(true);
					Leccion13.SetActive(true);
					Leccion14.SetActive(true);
					Leccion15.SetActive(true);
					Leccion16.SetActive(true);
					Leccion17.SetActive(true);
					Leccion18.SetActive(true);
				}
		}
	}
}
	
