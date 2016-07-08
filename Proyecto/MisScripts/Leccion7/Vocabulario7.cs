using UnityEngine;
using System.Collections;

public class Vocabulario7 : MonoBehaviour
{
	GameObject Texto, Texto2, Texto3,Texto4,Texto5,Odin,Dva,Tri,Chetyre,Pyat,
	Play, Next,Anterior,Escuchar, Dialogo, Ejercicios, Exit,Lecciones,Model;
	AudioSource source,source2,source3,source4,source5;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i;//identifica cada uno de los textos
	bool next,anterior;
	Animation boy;

	void Start () {
	
		next=false;
		anterior=false;

		i=1; 
	
		Play=GameObject.Find("Play");
		Next=GameObject.Find("Next");
	
		Odin=GameObject.Find("Odin");
		Dva=GameObject.Find("Dva");
		Tri=GameObject.Find("Tri");
		Chetyre=GameObject.Find("Chetyre");
		Pyat=GameObject.Find("Pyat");
		Model=GameObject.Find("Model");
		boy=Model.GetComponent<Animation>();

		//Repeat=GameObject.Find("Repeat");
		Anterior=GameObject.Find ("Anterior");
		//Vocabulario=GameObject.Find("Vocabulario");
		Dialogo=GameObject.Find("Dialogo");
		Escuchar=GameObject.Find("Escuchar");
		Ejercicios=GameObject.Find("Ejercicios");
		Exit=GameObject.Find("Exit");
		Lecciones=GameObject.Find("Lecciones");
		
		Texto=GameObject.Find("Texto");
		Texto2=GameObject.Find("Texto2");
		Texto3=GameObject.Find("Texto3");
		Texto4=GameObject.Find("Texto4");
		Texto5=GameObject.Find("Texto5");

		source=Texto.GetComponent<AudioSource>();
		source2=Texto2.GetComponent<AudioSource>();
		source3=Texto3.GetComponent<AudioSource>();
		source4=Texto4.GetComponent<AudioSource>();
		source5=Texto5.GetComponent<AudioSource>();


		if (cam == null){
			cam = Camera.main;
		}

		Anterior.SetActive(false);
		Texto2.SetActive(false);
		Texto3.SetActive(false);
		Texto4.SetActive(false);
		Texto5.SetActive(false);

		Odin.SetActive(true);
		Dva.SetActive(false);
		Tri.SetActive(false);
		Chetyre.SetActive(false);
		Pyat.SetActive(false);
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
							
						case "Play":
							
							if(i==1 && !source.isPlaying){
								source.Play();
								boy.Play("shest");
							}
							if(i==2 && !source2.isPlaying){
								source2.Play();
								boy.Play("sem");
							}
							if(i==3 && !source3.isPlaying){
								source3.Play();
								boy.Play("vosem");
							}
							if(i==4 && !source4.isPlaying){
								source4.Play();
								boy.Play("devyat");
							}
							if(i==5 && !source5.isPlaying){
								source5.Play();	
								boy.Play("desyat");
							}
							
							break;
							
					
						case "Anterior":
							if(i==1){
								Anterior.SetActive(false);
								Next.SetActive(true);
								Texto.SetActive(true);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);

								Odin.SetActive(true);
								Dva.SetActive(false);
								Tri.SetActive(false);
								Chetyre.SetActive(false);
								Pyat.SetActive(false);
							}
							if(i==2){
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();


								Texto.SetActive(true);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);

								Odin.SetActive(true);
								Dva.SetActive(false);
								Tri.SetActive(false);
								Chetyre.SetActive(false);
								Pyat.SetActive(false);
								i=1;
							}

							if(i==3){
								
								source.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
						

								Anterior.SetActive(true);
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);


								Odin.SetActive(false);
								Dva.SetActive(true);
								Tri.SetActive(false);
								Chetyre.SetActive(false);
								Pyat.SetActive(false);
								
								Next.SetActive(true);
								
								i=2;
							}

							if(i==4){
								source.Stop();
								source2.Stop();
								source4.Stop();
								source5.Stop();
								
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);

					
								Odin.SetActive(false);
								Dva.SetActive(false);
								Tri.SetActive(true);
								Chetyre.SetActive(false);
								Pyat.SetActive(false);
								i=3;
							}

							if(i==5){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
						
			
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								
				
								Odin.SetActive(false);
								Dva.SetActive(false);
								Tri.SetActive(false);
								Chetyre.SetActive(true);
								Pyat.SetActive(false);
								i=4;
							}
							
							break;
							
						case "Next":

							if(i==4){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();

						
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(true);
								
						
								Odin.SetActive(false);
								Dva.SetActive(false);
								Tri.SetActive(false);
								Chetyre.SetActive(false);
								Pyat.SetActive(true);
								Next.SetActive(false);
								i=5;
							}

							if(i==3){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
														
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								

								Odin.SetActive(false);
								Dva.SetActive(false);
								Tri.SetActive(false);
								Chetyre.SetActive(true);
								Pyat.SetActive(false);
								Next.SetActive(true);
								i=4;
							}

							if(i==2){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();

								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);


								Odin.SetActive(false);
								Dva.SetActive(false);
								Tri.SetActive(true);
								Chetyre.SetActive(false);
								Pyat.SetActive(false);
								Next.SetActive(true);
								i=3;
							}

							if(i==1){
							    Anterior.SetActive(true);
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
						
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								
								Odin.SetActive(false);
								Dva.SetActive(true);
								Tri.SetActive(false);
								Chetyre.SetActive(false);
								Pyat.SetActive(false);
								Next.SetActive(true);
								i=2;
							}

							break;
							
						case "Escuchar":
							Application.LoadLevel("Escuchar7");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo7");
							
							break;
							
						case "Ejercicios":
							//Ejercicios1 ej1=new Ejercicios1(1);
							//ej1.PutK(1);
							Application.LoadLevel("Ejercicios7");
							
							break;

						case "Lecciones":
							Application.LoadLevel("Lecciones");
						
							break;

						case "Exit":
							Application.Quit();
							
							break;
							
						}
					}
			}
		}
	}
}
