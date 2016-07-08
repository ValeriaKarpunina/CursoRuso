using UnityEngine;
using System.Collections;

public class Dialogo0 : MonoBehaviour
{
	GameObject texto, texto2,Play, Play2, Pausa, Pausa2, Repeat, 
	traduccion,traduccion2,Vocabulario, Escuchar, Ejercicios, Exit,Lecciones,Anna2,Boy,PlayGlobal,Vpered,Nazad,PausaGlobal;
	AudioSource source,source2,source3,source4;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int j,k,primero,segundo;
	bool pausado,pausado2,pausado3,pausado4,repeticion;
	Animation boy,girl;
	float Pitch;

	void Start () {
		
		pausado=false;
		pausado2=false;
		repeticion=false;
		k=0;
		j=0;
		primero=0;
		segundo=0;
		
		Play=GameObject.Find("Play");
		Play2=GameObject.Find("Play2");
		Pausa=GameObject.Find("Pausa");
		Pausa2=GameObject.Find("Pausa2");
		Repeat=GameObject.Find("Repeat");

		PlayGlobal=GameObject.Find("PlayGlobal");
		Vpered=GameObject.Find("Vpered");
		Nazad=GameObject.Find("Nazad");
		PausaGlobal=GameObject.Find("PausaGlobal");

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
		
		/*texto.SetActive(false);
		texto2.SetActive(false);

		traduccion.SetActive(false);
		traduccion2.SetActive(false);*/
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
							//solo sonara si el texto es visible en la escena
							texto.SetActive(true);
							texto2.SetActive(false);
		
							source.Play();
							boy.Play ();
							primero=1;
						
						}
						break;
						
					case "Play2":
						if(!repeticion){
							texto.SetActive(false);
							texto2.SetActive(true);
				
							source2.Play();
							girl.Play();
							segundo=1;
						
						}

						break;
						
					case "Pausa":
						
						if(primero==1){
							source.Play();
							boy.Play ();
						}

						
						break;
						
					case "Pausa2":
						if(segundo==1){
							source2.Play();
							girl.Play();
						}

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


					case "Repeat": // estando en repeat y pulsando pause del source, aparece el texto2
						source.Stop ();
						
						//texto.SetActive(true);
						//texto2.SetActive(false);
						k=0;
						//source.Play ();
						repeticion=true;
						break;
						
					case "Vocabulario":
						Application.LoadLevel("Vocabulario0");
						
						break;
						
					case "Ejercicios":

						Application.LoadLevel("Ejercicios0");
						
						break;

					case "Lecciones":
						Application.LoadLevel("Lecciones");
						
						break;

					case "Exit":
						Application.Quit();
						
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
				/*if (theTouch.phase == TouchPhase.Ended){
					traduccion.SetActive(false);
					traduccion2.SetActive(false);
				}*/
			}
		}
		
		if(repeticion & !pausado){
			if(!source.isPlaying & k==0){
				source2.Stop();
				texto.SetActive(true);
				texto2.SetActive(false);

				source.Play ();
				boy.Play ();
				k=1;
				
			}
			
			
			if(!source.isPlaying & k==1){

				texto.SetActive(false);
				texto2.SetActive(true);

				source2.Play ();
				girl.Play();
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
