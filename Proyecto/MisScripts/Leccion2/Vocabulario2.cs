using UnityEngine;
using System.Collections;

public class Vocabulario2 : MonoBehaviour
{
	GameObject Texto, Texto2, Texto3,Texto4,Texto5,Texto5_1,Texto6,Texto6_1,Ii,Ei,Yu,Yo,E,Ya,
	Play, Next,Anterior,Escuchar, Dialogo, Ejercicios, Exit,Lecciones,sitting;
	AudioSource source,source2,source3,source4,source5,source5_1,source6,source6_1;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i;//identifica cada uno de los textos
	bool next,anterior,repetir,repetir2,repetir3,repetir4,repetir5;
	
	void Start () {
	
		next=false;
		anterior=false;

		i=1; 
	
		Play=GameObject.Find("Play");
		Next=GameObject.Find("Next");
		sitting=GameObject.Find("sitting");
	
		Ii=GameObject.Find("Ii");
		Ei=GameObject.Find("Ei");
		Yu=GameObject.Find("Yu");
		Yo=GameObject.Find("Yo");
		E=GameObject.Find("E");
		Ya=GameObject.Find("Ya");
		Anterior=GameObject.Find ("Anterior");
		Dialogo=GameObject.Find("Dialogo");
		Escuchar=GameObject.Find("Escuchar");
		Ejercicios=GameObject.Find("Ejercicios");
		Lecciones=GameObject.Find("Lecciones");
		Exit=GameObject.Find("Exit");
		
		Texto=GameObject.Find("Texto");
		Texto2=GameObject.Find("Texto2");
		Texto3=GameObject.Find("Texto3");
		Texto4=GameObject.Find("Texto4");
		Texto5=GameObject.Find("Texto5");
		Texto5_1=GameObject.Find("Texto5_1");
		Texto6=GameObject.Find("Texto6");
		Texto6_1=GameObject.Find("Texto6_1");

		source=Texto.GetComponent<AudioSource>();
		source2=Texto2.GetComponent<AudioSource>();
		source3=Texto3.GetComponent<AudioSource>();
		source4=Texto4.GetComponent<AudioSource>();
		source5=Texto5.GetComponent<AudioSource>();
		source5_1=Texto5_1.GetComponent<AudioSource>();
		source6=Texto6.GetComponent<AudioSource>();
		source6_1=Texto6_1.GetComponent<AudioSource>();

		if (cam == null){
			cam = Camera.main;
		}

		Anterior.SetActive(false);
		Texto2.SetActive(false);
		Texto3.SetActive(false);
		Texto4.SetActive(false);
		Texto5.SetActive(false);
		Texto5_1.SetActive(false);
		Texto6.SetActive(false);
		Texto6_1.SetActive(false);

		Ei.SetActive(false);
		Yu.SetActive(false);
		Yo.SetActive(false);
		E.SetActive(false);
		Ya.SetActive(false);

	}
	
	
	void Update(){
		if(!sitting.GetComponent<Animation>().isPlaying){
			sitting.GetComponent<Animation>().Play();
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
							
						case "Play":
							
							if(i==1 && !source.isPlaying){
								source.Play();
							}
							if(i==2 && !source2.isPlaying){
								source2.Play();
							}
							if(i==3 && !source3.isPlaying){
								source3.Play();
							}
							if(i==4 && !source4.isPlaying){
								source4.Play();
							}
							if(i==5 && !source5.isPlaying){
								source5.Play();	
							}

							if(i==6 && !source5_1.isPlaying){
								source5_1.Play();	
							}

							if(i==7 && !source6.isPlaying){
								source6.Play();	
							}

							if(i==8 && !source6_1.isPlaying){
								source6_1.Play();	
							}
							break;
							
					
						case "Anterior":
							if(i==1){
								Anterior.SetActive(false);
								Next.SetActive(true);
							}
							if(i==2){
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source5_1.Stop();
								source6.Stop();
								source6_1.Stop();

								Anterior.SetActive(false);
								Next.SetActive(true);
								Next.SetActive(true);
								Texto.SetActive(true);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto5_1.SetActive(false);
								Texto6.SetActive(false);
								Texto6_1.SetActive(false);
								Ii.SetActive(true);
								Ei.SetActive(false);
								Yu.SetActive(false);
								Yo.SetActive(false);
								E.SetActive(false);
								Ya.SetActive(false);

								i=1;
							}

							if(i==3){
								source.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source5_1.Stop();
								source6.Stop();
								source6_1.Stop();

								Anterior.SetActive(true);
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto5_1.SetActive(false);
								Texto6.SetActive(false);
								Texto6_1.SetActive(false);

								Ii.SetActive(false);
								Ei.SetActive(true);
								Yu.SetActive(false);
								Yo.SetActive(false);
								E.SetActive(false);
								Ya.SetActive(false);

								i=2;
							}

							if(i==4){
								source.Stop();
								source2.Stop();
								source4.Stop();
								source5.Stop();
								source5_1.Stop();
								source6.Stop();
								source6_1.Stop();

								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto5_1.SetActive(false);
								Texto6.SetActive(false);
								Texto6_1.SetActive(false);
			
								Ii.SetActive(false);
								Ei.SetActive(false);
								Yu.SetActive(true);
								Yo.SetActive(false);
								E.SetActive(false);
								Ya.SetActive(false);

								i=3;
							}

							if(i==5){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source5_1.Stop();
								source6.Stop();
								source6_1.Stop();

								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								Texto5_1.SetActive(false);
								Texto6.SetActive(false);
								Texto6_1.SetActive(false);

								Ii.SetActive(false);
								Ei.SetActive(false);
								Yu.SetActive(false);
								Yo.SetActive(true);
								E.SetActive(false);
								Ya.SetActive(false);
								
								i=4;
							}

							if(i==6){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5_1.Stop();
								source6.Stop();
								source6_1.Stop();

								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(true);
								Texto5_1.SetActive(false);
								Texto6.SetActive(false);
								Texto6_1.SetActive(false);

								Ii.SetActive(false);
								Ei.SetActive(false);
								Yu.SetActive(false);
								Yo.SetActive(false);
								E.SetActive(true);
								Ya.SetActive(false);

								i=5;
							}
							if(i==7){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source6_1.Stop();

								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto5_1.SetActive(true);
								Texto6.SetActive(false);
								Texto6_1.SetActive(false);

								Ii.SetActive(false);
								Ei.SetActive(false);
								Yu.SetActive(false);
								Yo.SetActive(false);
								E.SetActive(true);
								Ya.SetActive(false);
								
								i=6;
							}
							if(i==8){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source5_1.Stop();
								source6_1.Stop();

								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto5_1.SetActive(false);
								Texto6.SetActive(true);
								Texto6_1.SetActive(false);
								Ii.SetActive(false);
								Ei.SetActive(false);
								Yu.SetActive(false);
								Yo.SetActive(false);
								E.SetActive(false);
								Ya.SetActive(true);
								Next.SetActive(true);

								i=7;
							}

								break;
								
						case "Next":

							if(i==8){
								Next.SetActive(false);
							}

							if(i==7){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source5_1.Stop();
								source6.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto5_1.SetActive(false);
								Texto6.SetActive(false);
								Texto6_1.SetActive(true);
								
								Ii.SetActive(false);
								Ei.SetActive(false);
								Yu.SetActive(false);
								Yo.SetActive(false);
								E.SetActive(false);
								Ya.SetActive(true);
								Next.SetActive(false);
								
								i=8;
							}

							if(i==6){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source5_1.Stop();
								source6_1.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto5_1.SetActive(false);
								Texto6.SetActive(true);
								Texto6_1.SetActive(false);

								Ii.SetActive(false);
								Ei.SetActive(false);
								Yu.SetActive(false);
								Yo.SetActive(false);
								E.SetActive(false);
								Ya.SetActive(true);
								
								i=7;
							}

							if(i==5){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source6_1.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto5_1.SetActive(true);
								Texto6.SetActive(false);
								Texto6_1.SetActive(false);
								
								Ii.SetActive(false);
								Ei.SetActive(false);
								Yu.SetActive(false);
								Yo.SetActive(false);
								E.SetActive(true);
								Ya.SetActive(false);
								
								i=6;
							}

							if(i==4){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5_1.Stop();
								source6.Stop();
								source6_1.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(true);
								Texto5_1.SetActive(false);
								Texto6.SetActive(false);
								Texto6_1.SetActive(false);
								
								Ii.SetActive(false);
								Ei.SetActive(false);
								Yu.SetActive(false);
								Yo.SetActive(false);
								E.SetActive(true);
								Ya.SetActive(false);

								i=5;
							}

							if(i==3){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source5_1.Stop();
								source6.Stop();
								source6_1.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								Texto5_1.SetActive(false);
								Texto6.SetActive(false);
								Texto6_1.SetActive(false);
								
								Ii.SetActive(false);
								Ei.SetActive(false);
								Yu.SetActive(false);
								Yo.SetActive(true);
								E.SetActive(false);
								Ya.SetActive(false);

								i=4;
							}

							if(i==2){
								source.Stop();
								source2.Stop();
								source4.Stop();
								source5.Stop();
								source5_1.Stop();
								source6.Stop();
								source6_1.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto5_1.SetActive(false);
								Texto6.SetActive(false);
								Texto6_1.SetActive(false);
								
								Ii.SetActive(false);
								Ei.SetActive(false);
								Yu.SetActive(true);
								Yo.SetActive(false);
								E.SetActive(false);
								Ya.SetActive(false);
								
								i=3;
							}

							if(i==1){
								source.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source5_1.Stop();
								source6.Stop();
								source6_1.Stop();
								
								Anterior.SetActive(true);
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto5_1.SetActive(false);
								Texto6.SetActive(false);
								Texto6_1.SetActive(false);
								
								Ii.SetActive(false);
								Ei.SetActive(true);
								Yu.SetActive(false);
								Yo.SetActive(false);
								E.SetActive(false);
								Ya.SetActive(false);
								
								i=2;
							}

							break;
							
						case "Escuchar":
							Application.LoadLevel("Escuchar2");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo2");
							
							break;
							
						case "Ejercicios":
							Application.LoadLevel("Ejercicios2");
							
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
