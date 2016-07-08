using UnityEngine;
using System.Collections;

public class Dialogo6 : MonoBehaviour
{
	private GameObject texto, texto2, texto1_2, texto2_2,Play, Play2, Pausa, Pausa2, Next, Repeat, Anterior,
	traduccion,traduccion2,traduccion1_2,traduccion2_2,Vocabulario, Escuchar, Ejercicios, Exit,Lecciones,Car,Boy,Anna2;
	private AudioSource source,source2,source3,source4;
	private Touch tocar;
	private Camera cam;
	private RaycastHit hit;
	private Ray ray;
	private int k,primero,segundo;
	private bool pausado,pausado2,pausado3,pausado4,next,anterior, repeticion;
	private Animation boy,girl2;

	void Start () {
		
		pausado=false;
		pausado2=false;
		next=false;
		anterior=false;
		repeticion=false; 
		k=0;
		primero=2;
		segundo=2;
		
		Play=GameObject.Find("Play");
		Play2=GameObject.Find("Play2");
		Next=GameObject.Find("Next");
		Anterior=GameObject.Find ("Anterior");
		Pausa=GameObject.Find("Pausa");
		Pausa2=GameObject.Find("Pausa2");
		Repeat=GameObject.Find("Repeat");

		Vocabulario=GameObject.Find("Vocabulario");
		Escuchar=GameObject.Find("Escuchar");
		Ejercicios=GameObject.Find("Ejercicios");
		Lecciones=GameObject.Find("Lecciones");
		Exit=GameObject.Find("Exit");
		
		Boy=GameObject.Find("Boy");
		Anna2=GameObject.Find("Anna2");
		Car=GameObject.Find("Car");

		boy=Boy.GetComponent<Animation>();
		girl2=Anna2.GetComponent<Animation>();

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

		Next.SetActive(false);
		Anterior.SetActive(false);
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
								primero=2;
								source3.Play();
								boy.Play("boy2");
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

								segundo=1;
							}

							else{
								if(!repeticion){
									texto.SetActive(false);
									texto2.SetActive(false);
									texto1_2.SetActive(false);
									texto2_2.SetActive(true);
									source4.Play();
									segundo=2;
									girl2.Play("Anna2_2");
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



						case "Repeat": // estando en repeat y pulsando pause del source, aparece el texto2
							source.Stop ();

							texto.SetActive(true);
							texto2.SetActive(false);
							texto1_2.SetActive(false);
							texto2_2.SetActive(false);

							boy.Play("boy1");
							source.Play ();
							repeticion=true;
							break;
							
						/*case "Anterior":
					
							if(i==2){
								texto.SetActive(false);
								texto2.SetActive(false);
							}

							//mejor con load Dialogo1
							break;
							
						case "Next":
							
							Debug.Log ("Se pasa a siguiente audio");
							if(i==1){
								i=2;
								texto.SetActive(false); //poner a false otros textos tmbn
								texto2.SetActive(false); //poner a false 
							}

							//mejor con load Dialogo1_2
							break;*/
							
						case "Vocabulario":
							Application.LoadLevel("Vocabulario6");
							
							break;
							
						case "Escuchar":
							Application.LoadLevel("Escuchar6");
							
							break;
							
						case "Ejercicios":
							//Ejercicios1 ej1=new Ejercicios1(1);
							//ej1.PutK(1);
							Application.LoadLevel("Ejercicios6");
							
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
				k=2;
			
			}

			
			if(!source3.isPlaying & k==2){
				source4.Stop();
				texto.SetActive(false);
				texto2.SetActive(false);
				texto1_2.SetActive(false);
				texto2_2.SetActive(true);
			
				k=3;
				source4.Play ();
				girl2.Play("Anna2_2");

			}
			if(!source4.isPlaying & k==3){

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
