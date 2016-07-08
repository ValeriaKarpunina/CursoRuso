using UnityEngine;
using System.Collections;

public class Dialogo10 : MonoBehaviour
{
	GameObject texto, texto2,Play, Play2, Pausa, Pausa2, Repeat, 
	traduccion,traduccion2,Vocabulario, Escuchar, Ejercicios, Exit,Lecciones,Anna2,Boy;
	AudioSource source,source2,source3,source4;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i,j,k,primero,segundo;
	bool pausado,pausado2,pausado3,pausado4,repeticion;
	Animation boy,girl;


	void Start () {
		
		pausado=false;
		pausado2=false;
		repeticion=false;
		i=1; 
		j=0;
		k=0;
		primero=0;
		segundo=0;
		
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

		girl=Anna2.GetComponent<Animation>();
		boy=Boy.GetComponent<Animation>();
		
		texto=GameObject.Find("texto");
		texto2=GameObject.Find("texto2");
		
		traduccion=GameObject.Find("traduccion");
		traduccion2=GameObject.Find("traduccion2");
		
		source=texto.GetComponent<AudioSource>();
		source2=texto2.GetComponent<AudioSource>();
		
		if (cam == null){
			cam = Camera.main;
		}
		
		texto.SetActive(false);
		texto2.SetActive(false);

		traduccion.SetActive(false);
		traduccion2.SetActive(false);
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

						
					case "Play":
						
						if(!repeticion){

							texto.SetActive(true);
							texto2.SetActive(false);
		
							source.Play();
							girl.Play();
							primero=1;

						}
						break;
						
					case "Play2":
						if(!repeticion){
							texto.SetActive(false);
							texto2.SetActive(true);
				
							source2.Play();
							boy.Play ();
							segundo=2;
						
						}

						break;
						
					case "Pausa":

						if(primero==1){
							texto.SetActive(true);
							texto2.SetActive(false);
							source.Play();
							girl.Play();
						}

						
						break;
						
					case "Pausa2":
						if(segundo==1){
							texto.SetActive(false);
							texto2.SetActive(true);
							source2.Play();
							boy.Play ();
						}

						break;
						
						
					case "Repeat": 
						source.Stop ();
						

						k=0;
					
						repeticion=true;
						break;
						
					case "Vocabulario":
						Application.LoadLevel("Vocabulario10");
						
						break;
						
					case "Escuchar":
						Application.LoadLevel("Escuchar10");
						
						break;
						
					case "Ejercicios":
					
						Application.LoadLevel("Ejercicios10");
						
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
				}
			}
		}
		
		if(repeticion & !pausado){
			if(!source.isPlaying & k==0){
				source2.Stop();
				texto.SetActive(true);
				texto2.SetActive(false);

				source.Play ();
				girl.Play();
				k=1;
				
			}
			
			
			if(!source.isPlaying & k==1){

				texto.SetActive(false);
				texto2.SetActive(true);

				source2.Play ();
				boy.Play ();
				k=2;
		
			}
			if(!source2.isPlaying & k==2){
				repeticion=false;
				texto.SetActive(false);
				texto2.SetActive(false);
			}
		}
	}
}
