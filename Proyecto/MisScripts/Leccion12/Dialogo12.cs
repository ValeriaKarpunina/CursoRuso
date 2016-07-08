using UnityEngine;
using System.Collections;

public class Dialogo12 : MonoBehaviour
{
	GameObject texto, texto2, texto1_2, texto2_2,Play, Play2, Pausa, Pausa2, Repeat, 
	traduccion,traduccion2,traduccion1_2,traduccion2_2,Vocabulario, Escuchar, Ejercicios, Exit,Lecciones,Anna2,Boy,
	Model,Model2;
	AudioSource source,source2,source3,source4;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int k,primero,segundo;
	bool pausado,pausado2,pausado3,pausado4,repeticion;
	Animation boy,girl2,brat,anim2;

	void Start () {
		
		pausado=false;
		pausado2=false;
		repeticion=false;
		k=0;
		primero=2;
		segundo=2;
		
		Play=GameObject.Find("Play");
		Play2=GameObject.Find("Play2");
		Pausa=GameObject.Find("Pausa");
		Pausa2=GameObject.Find("Pausa2");
		Repeat=GameObject.Find("Repeat");
		
		Vocabulario=GameObject.Find("Vocabulario");
		Escuchar=GameObject.Find("Escuchar");
		Ejercicios=GameObject.Find("Ejercicios");
		Lecciones=GameObject.Find("Lecciones");
		Exit=GameObject.Find("Exit");

		Anna2=GameObject.Find("Anna2");
		Boy=GameObject.Find("Boy");
		Model=GameObject.Find("Model");
		Model2=GameObject.Find("Model2");
		girl2=Anna2.GetComponent<Animation>();
		boy=Boy.GetComponent<Animation>();
		brat=Model.GetComponent<Animation>();
		anim2=Model2.GetComponent<Animation>();

		texto=GameObject.Find("texto");
		texto2=GameObject.Find("texto2");
		texto1_2=GameObject.Find("texto1_2");
		texto2_2=GameObject.Find("texto2_2");
		
		traduccion=GameObject.Find("traduccion");
		traduccion2=GameObject.Find("traduccion2");
		traduccion1_2=GameObject.Find("traduccion1_2");
		traduccion2_2=GameObject.Find("traduccion2_2");
		
		source=texto.GetComponent<AudioSource>();
		source2=texto2.GetComponent<AudioSource>();
		source3=texto1_2.GetComponent<AudioSource>();
		source4=texto2_2.GetComponent<AudioSource>();
		
		if (cam == null){
			cam = Camera.main;
		}
		
		texto.SetActive(false);
		texto2.SetActive(false);
		texto1_2.SetActive(false);
		texto2_2.SetActive(false);
		traduccion.SetActive(false);
		traduccion2.SetActive(false);
		traduccion1_2.SetActive(false);
		traduccion2_2.SetActive(false);
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
						
					case "texto":
						traduccion.SetActive(true);
						
						break;
						
					case "texto2":
						traduccion2.SetActive(true);
						
						break;
						
					case "texto1_2":
						traduccion1_2.SetActive(true);
						
						break;
						
					case "texto2_2":
						traduccion2_2.SetActive(true);
						
						break;
						
					case "Play":
						
						if(!repeticion && primero==2){

							texto.SetActive(true);
							texto2.SetActive(false);
							texto1_2.SetActive(false);
							texto2_2.SetActive(false);
							source.Play();
							boy.Play("boy1");
							primero=1;
						
						}
						
						else{
							if(!repeticion){
								texto.SetActive(false);
								texto2.SetActive(false);
								texto1_2.SetActive(true);
								texto2_2.SetActive(false);
								source3.Play();
								boy.Play("boy2");
								anim2.Play();
								primero=2;
							}
						}
						
						break;
						
					case "Play2":
						
						if(!repeticion && segundo==2){
							texto.SetActive(false);
							texto2.SetActive(true);
							texto1_2.SetActive(false);
							texto2_2.SetActive(false);
							source2.Play();
							girl2.Play("Anna2_1");
							brat.Play();
							segundo=1;
						}
						
						else{
							if(!repeticion){
								texto.SetActive(false);
								texto2.SetActive(false);
								texto1_2.SetActive(false);
								texto2_2.SetActive(true);
								source4.Play();
								girl2.Play("Anna2_2");
								segundo=2;
							}
						}
						
						
						break;
						
						
					case "Pausa":
						
						if(primero==1){
							texto.SetActive(true);
							texto2.SetActive(false);
							texto1_2.SetActive(false);
							texto2_2.SetActive(false);
							source.Play();
							boy.Play("boy1");
						}
						
						if(primero==2){
							texto.SetActive(false);
							texto2.SetActive(false);
							texto1_2.SetActive(true);
							texto2_2.SetActive(false);
							source3.Play();
							boy.Play("boy2");
						}
						
						break;
						
					case "Pausa2":
						if(segundo==1){
							texto.SetActive(false);
							texto2.SetActive(true);
							texto1_2.SetActive(false);
							texto2_2.SetActive(false);
							source2.Play();
							girl2.Play("Anna2_1");
						}
						
						if(segundo==2){
							texto.SetActive(false);
							texto2.SetActive(false);
							texto1_2.SetActive(false);
							texto2_2.SetActive(true);
							source4.Play();
							girl2.Play("Anna2_2");
						}
						break;
						
						
					case "Repeat": 
						source.Stop ();
						
						texto.SetActive(true);
						texto2.SetActive(false);
						texto1_2.SetActive(false);
						texto2_2.SetActive(false);
						source.Play ();
						boy.Play("boy1");
						repeticion=true;
						break;
						
					case "Vocabulario":
						Application.LoadLevel("Vocabulario12");
						
						break;
						
					case "Escuchar":
						Application.LoadLevel("Escuchar12");
						
						break;
						
					case "Ejercicios":

						Application.LoadLevel("Ejercicios12");
						
						break;

					case "Lecciones":
						Application.LoadLevel("Lecciones");
						
						break;

					case "Exit":
						Application.Quit();
						
						break;
						
					}
				}	
				if (theTouch.phase == TouchPhase.Ended){
					traduccion.SetActive(false);
					traduccion2.SetActive(false);
					traduccion1_2.SetActive(false);
					traduccion2_2.SetActive(false);
				}
			}
		}
		
		if(repeticion & !pausado){
			if(!source.isPlaying & k==0){
				source2.Stop();
				texto.SetActive(false);
				texto2.SetActive(true);
				texto1_2.SetActive(false);
				texto2_2.SetActive(false);
				source2.Play ();
				girl2.Play("Anna2_1");
				brat.Play();
				k=1;
				
			}
			
			
			if(!source2.isPlaying & k==1){
				source3.Stop();
				texto.SetActive(false);
				texto2.SetActive(false);
				texto1_2.SetActive(true);
				texto2_2.SetActive(false);
				source3.Play ();
				boy.Play("boy2");
				anim2.Play();
				k=2;
				
			}
			
			
			if(!source3.isPlaying & k==2){
				source4.Stop();
				texto.SetActive(false);
				texto2.SetActive(false);
				texto1_2.SetActive(false);
				texto2_2.SetActive(true);
				source4.Play ();
				girl2.Play ("Anna2_2");
				k=3;
			}
			
			if(!source4.isPlaying & k==3){
				source4.Stop();
				texto.SetActive(false);
				texto2.SetActive(false);
				texto1_2.SetActive(false);
				texto2_2.SetActive(false);
				k=0;
				repeticion=false;	
			}
		}
	}
}
