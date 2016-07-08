using UnityEngine;
using System.Collections;

public class Dialogo1 : MonoBehaviour
{
	private GameObject texto, texto2, texto1_2, texto2_2,Play, Play2, Pausa, Pausa2, Repeat, 
	traduccion,traduccion2,traduccion1_2,traduccion2_2,Vocabulario, Escuchar, Ejercicios, Exit,Lecciones,Anna, Boy;
	private AudioSource source,source2,source3,source4;
	private Touch tocar;
	private Camera cam;
	private RaycastHit hit;
	private Ray ray;
	private int i,j,k,primero,segundo;
	private bool pausado,pausado2,pausado3,pausado4,repeticion;
	private Animation boy,girl;

	void Start(){
	
		if (cam == null){
			cam = Camera.main;
		}

		repeticion=false;
		primero=2;
		segundo=2;
		k=0;

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
		Anna=GameObject.Find("Anna");
		Boy=GameObject.Find("Boy");

		girl=Anna.GetComponent<Animation>();
		boy=Boy.GetComponent<Animation>();

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
	
		texto.SetActive(false);
		texto2.SetActive(false);
		texto1_2.SetActive(false);
		texto2_2.SetActive(false);
		traduccion.SetActive(false);
		traduccion2.SetActive(false);
		traduccion1_2.SetActive(false);
		traduccion2_2.SetActive(false);
		Debug.Log("final start");
	}
	
	
	void Update(){

		girl.Play("Girl1");
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
						
						if(primero==2){
							//solo sonara si el texto es visible en la escena
							texto.SetActive(true);
							texto2.SetActive(false);
							texto1_2.SetActive(false);
							texto2_2.SetActive(false);
							source.Play();
							boy.Play("Boy1");
							primero=1;
						}
						else{
							texto.SetActive(false);
							texto2.SetActive(false);
							texto1_2.SetActive(true);
							texto2_2.SetActive(false);
							source3.Play();
							boy.Play("Boy2");
							primero=2;
						}
						
						break;
						
					case "Play2":
						
						if(segundo==2){
							texto.SetActive(false);
							texto2.SetActive(true);
							texto1_2.SetActive(false);
							texto2_2.SetActive(false);
							source2.Play();
							girl.Play("Girl1");

							segundo=1;
						}
						else{
							texto.SetActive(false);
							texto2.SetActive(false);
							texto1_2.SetActive(false);
							texto2_2.SetActive(true);
							source4.Play();
							girl.Play("Girl2");
							segundo=2;
						}
						
						
						break;
						
					case "Pausa":
						
						if(primero==1){
							texto.SetActive(true);
							texto2.SetActive(false);
							texto1_2.SetActive(false);
							texto2_2.SetActive(false);
							source.Play();
							boy.Play("Boy1");
						}
						
						if(primero==2){
							texto.SetActive(false);
							texto2.SetActive(false);
							texto1_2.SetActive(true);
							texto2_2.SetActive(false);
							source3.Play();
							boy.Play("Boy2");
						}
						
						break;
						
					case "Pausa2":
						if(segundo==1){
							texto.SetActive(false);
							texto2.SetActive(true);
							texto1_2.SetActive(false);
							texto2_2.SetActive(false);
							source2.Play();
							girl.Play("Girl1");
						}
						
						if(segundo==2){
							texto.SetActive(false);
							texto2.SetActive(false);
							texto1_2.SetActive(false);
							texto2_2.SetActive(true);
							source4.Play();
							girl.Play("Girl2");
						}
						break;
						
						
					case "Repeat":
						source.Stop ();
						source2.Stop ();
						source3.Stop ();
						source4.Stop ();
						texto.SetActive(true);
						texto2.SetActive(false);
						texto1_2.SetActive(false);
						texto2_2.SetActive(false);
						source.Play ();
						boy.Play("Boy1");
						k=0;
						repeticion=true;
						break;
						
					case "Vocabulario":
						Application.LoadLevel("Vocabulario1");
						
						break;
						
					case "Escuchar":
						Application.LoadLevel("Escuchar1");
						
						break;
						
					case "Ejercicios":
						Application.LoadLevel("Ejercicios1");
						
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
				source3.Stop();
				source4.Stop();
				texto.SetActive(false);
				texto2.SetActive(true);
				texto1_2.SetActive(false);
				texto2_2.SetActive(false);
				source2.Play ();
				girl.Play("Girl1");
				k=1;
				
			}
			
			
			if(!source2.isPlaying & k==1){
				source.Stop();
				source3.Stop();
				source4.Stop();
				texto.SetActive(false);
				texto2.SetActive(false);
				texto1_2.SetActive(true);
				texto2_2.SetActive(false);
				source3.Play ();
				boy.Play("Boy2");
				k=2;
				
			}
			
			
			if(!source3.isPlaying & k==2){
				source.Stop();
				source2.Stop();
				source4.Stop();
				texto.SetActive(false);
				texto2.SetActive(false);
				texto1_2.SetActive(false);
				texto2_2.SetActive(true);
				source4.Play ();
				girl.Play("Girl2");
				k=3;
			}
			if(!source4.isPlaying & k==3){

				texto.SetActive(false);
				texto2.SetActive(false);
				texto1_2.SetActive(false);
				texto2_2.SetActive(false);

				repeticion=false;	
			}
		}
	}
}
