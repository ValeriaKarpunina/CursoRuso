using UnityEngine;
using System.Collections;

public class Dialogo14 : MonoBehaviour
{
	GameObject texto,texto1_2,texto2,Play, Play2, Pausa, Pausa2, Repeat, 
	traduccion,traduccion2,traduccion1_2,Vocabulario, Escuchar, Ejercicios, Exit,Lecciones,B1,B2,replay,replay2;
	AudioSource source,source2,source1_2;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i,j,k,primero,segundo;
	bool repeticion;
	Animation Boy1,Boy2;

	void Start () {
	
		repeticion=false;
		k=0;
		primero=2;
		segundo=2;

		Play=GameObject.Find("Play");
		Play2=GameObject.Find("Play2");
		Pausa=GameObject.Find("Pausa");
		Pausa2=GameObject.Find("Pausa2");
		Repeat=GameObject.Find("Repeat");

		replay=GameObject.Find("Pausa");
		replay2=GameObject.Find("Pausa2");

		B1=GameObject.Find("Boy1");
		B2=GameObject.Find("Boy2");
		
		Boy1=B1.GetComponent<Animation>();
		Boy2=B2.GetComponent<Animation>();

		Vocabulario=GameObject.Find("Vocabulario");
		Escuchar=GameObject.Find("Escuchar");
		Ejercicios=GameObject.Find("Ejercicios");
		Lecciones=GameObject.Find("Lecciones");
		Exit=GameObject.Find("Exit");
		
		
		texto=GameObject.Find("texto");
		texto2=GameObject.Find("texto2");
		texto1_2=GameObject.Find("texto1_2");

		traduccion=GameObject.Find("traduccion");
		traduccion2=GameObject.Find("traduccion2");
		traduccion1_2=GameObject.Find("traduccion1_2");

		source=texto.GetComponent<AudioSource>();
		source2=texto2.GetComponent<AudioSource>();
		source1_2=texto1_2.GetComponent<AudioSource>();

		if (cam == null){
			cam = Camera.main;
		}
		
		texto.SetActive(false);
		texto2.SetActive(false);
		texto1_2.SetActive(false);

		traduccion.SetActive(false);
		traduccion2.SetActive(false);
		traduccion1_2.SetActive(false);
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

					case "Play":
						if(!repeticion && primero==2){
						
							texto.SetActive(true);
							texto2.SetActive(false);
							texto1_2.SetActive(false);
							primero=1;
							source.Play();
							Boy1.Play("boy1_1");
						}
						
						else{

							texto.SetActive(false);
							texto2.SetActive(false);
							texto1_2.SetActive(true);
							primero=2;
							source1_2.Play();
							Boy1.Play("boy1_2");
						}

						break;
						
					case "Play2":
						if(!repeticion){
							texto.SetActive(false);
							texto1_2.SetActive(false);
							texto2.SetActive(true);
							segundo=1;
							source2.Play();
							Boy2.Play();
						}

						break;

				
					case "replay":
						
						if(primero==1){
							texto.SetActive(true);
							texto2.SetActive(false);
							texto1_2.SetActive(false);
							source.Play();
							Boy1.Play("boy1_1");
						}
						
						if(primero==2){
							texto.SetActive(false);
							texto2.SetActive(false);
							texto1_2.SetActive(true);
							source1_2.Play();
							Boy1.Play("boy1_2");
						}
						
						break;
						
					case "replay2":
						if(segundo==1){
							texto.SetActive(false);
							texto1_2.SetActive(false);
							texto2.SetActive(true);
							source2.Play();
							Boy2.Play();
						}
				
						break;

					case "Repeat": 
						source.Stop ();
						source2.Stop();
						source1_2.Stop();
						segundo=2;
						k=0;

						repeticion=true;
						break;
						
					case "Vocabulario":
						Application.LoadLevel("Vocabulario14");
						
						break;
						
					case "Escuchar":
						Application.LoadLevel("Escuchar14");
						
						break;
						
					case "Ejercicios":

						Application.LoadLevel("Ejercicios14");
						
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
				}
			}
		}
		
		if(repeticion){
			if(k==0){

				texto.SetActive(true);
				texto2.SetActive(false);
				texto1_2.SetActive(false);

				source.Play ();
				Boy1.Play("boy1_1");
				k=1;
				
			}
			
			
			if(!source.isPlaying & k==1){

				texto.SetActive(false);
				texto2.SetActive(true);
				texto1_2.SetActive(false);

				source2.Play ();
				Boy2.Play();
				k=2;
		
			}
			if(!source2.isPlaying & k==2){
				
				texto.SetActive(false);
				texto2.SetActive(false);
				texto1_2.SetActive(true);

				source1_2.Play ();
				Boy1.Play("boy1_2");
				k=3;
			}
			if(!source1_2.isPlaying & k==3){
				texto1_2.SetActive(false);
				repeticion=false;
			}
		}
	}
}
