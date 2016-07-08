using UnityEngine;
using System.Collections;

public class Vocabulario0 : MonoBehaviour
{
	GameObject Texto, Texto2, Texto3,Texto4,Texto5,Texto6,Texto7,Vpered,Nazad,PausaGlobal,
	Play,PlayGlobal, Next,Anterior,Escuchar, Dialogo, Ejercicios, Exit,Lecciones,p,p1,p2,p3,p4,p5,pGlobal,Guardar,m2,m4,m5,m6;
	AudioSource source,source2,source3,source4,source5,source6,source7,source8,source9;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i,j;
	bool next,anterior;
	float Pitch;
	
	void Start () {

		//SaveLoad save=new SaveLoad(0,1,2,3,4);
		//save.Save();

		next=false;
		anterior=false;

		i=1; 
		j=0;

		Vpered=GameObject.Find("Vpered");
		Nazad=GameObject.Find("Nazad");
		PausaGlobal=GameObject.Find("PausaGlobal");
		PlayGlobal=GameObject.Find("PlayGlobal");

		Play=GameObject.Find("Play");
		Next=GameObject.Find("Next");
		m2=GameObject.Find("m2");
		m4=GameObject.Find("m4");
		m5=GameObject.Find("m5");
		m6=GameObject.Find("m6");

		Anterior=GameObject.Find ("Anterior");
		Dialogo=GameObject.Find("Dialogo");
		Escuchar=GameObject.Find("Escuchar");
		Ejercicios=GameObject.Find("Ejercicios");
		Exit=GameObject.Find("Exit");
		Lecciones=GameObject.Find("Lecciones");
		Guardar=GameObject.Find("Guardar");

		Texto=GameObject.Find("Texto");
		Texto2=GameObject.Find("Texto2");
		Texto3=GameObject.Find("Texto3");
		Texto4=GameObject.Find("Texto4");
		Texto5=GameObject.Find("Texto5");
		Texto6=GameObject.Find("Texto6");
		Texto7=GameObject.Find("Texto7");

		p=GameObject.Find("p");
		p1=GameObject.Find("p1");
		p2=GameObject.Find("p2");
		p3=GameObject.Find("p3");
		p4=GameObject.Find("p4");
		p5=GameObject.Find("p5");
		pGlobal=GameObject.Find("pGlobal");
		pGlobal.GetComponent<Animation>().Play();

		source=Texto.GetComponent<AudioSource>();
		source2=Texto2.GetComponent<AudioSource>();
		source3=Texto3.GetComponent<AudioSource>();
		source4=Texto4.GetComponent<AudioSource>();
		source5=Texto5.GetComponent<AudioSource>();
		source6=Texto6.GetComponent<AudioSource>();
		source7=Texto7.GetComponent<AudioSource>();

		if (cam == null){
			cam = Camera.main;
		}

		Anterior.SetActive(false);
		Texto2.SetActive(false);
		Texto3.SetActive(false);
		Texto4.SetActive(false);
		Texto5.SetActive(false);
		Texto6.SetActive(false);
		Texto7.SetActive(false);
		Guardar.SetActive(false);
		p1.SetActive(false);
		p2.SetActive(false);
		p3.SetActive(false);
		p4.SetActive(false);
		p5.SetActive(false);
		m2.SetActive(false);
		m4.SetActive(false);
		m5.SetActive(false);
		m6.SetActive(false);

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

						case "PlayGlobal":

						if(!PlayGlobal.GetComponent<AudioSource>().isPlaying){
							PlayGlobal.GetComponent<AudioSource>().Play();
							pGlobal.SetActive(false);
							Pitch=PlayGlobal.GetComponent<AudioSource>().pitch;
						}
						break;

						case "PausaGlobal":
							//if(PlayGlobal.GetComponent<AudioSource>().isPlaying){
								PlayGlobal.GetComponent<AudioSource>().Pause();
							//}
						break;

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
							if(i==6 && !source6.isPlaying){
								source6.Play();	
							}
							if(i==7 && !source7.isPlaying){
								source7.Play();	
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
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								p.SetActive(true);	
								p1.SetActive(false);
								p2.SetActive(false);
								p3.SetActive(false);
								p4.SetActive(false);
								p5.SetActive(false);
								m2.SetActive(false);
								m4.SetActive(false);
								m5.SetActive(false);
								m6.SetActive(false);
							}
							if(i==2){
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();

								Texto.SetActive(true);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);

								p.SetActive(true);	
								p1.SetActive(false);
								p2.SetActive(false);
								p3.SetActive(false);
								p4.SetActive(false);
								p5.SetActive(false);
								m2.SetActive(false);
								m4.SetActive(false);
								m5.SetActive(false);
								m6.SetActive(false);
								i=1;
							}

							if(i==3){
								
								source.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();

								Anterior.SetActive(true);
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);

								p.SetActive(false);	
								p1.SetActive(true);
								p2.SetActive(false);
								p3.SetActive(false);
								p4.SetActive(false);
								p5.SetActive(false);
								Next.SetActive(true);
								m2.SetActive(true);
								m4.SetActive(false);
								m5.SetActive(false);
								m6.SetActive(false);
								i=2;
							}

							if(i==4){
								source.Stop();
								source2.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								
								p.SetActive(false);	
								p1.SetActive(false);
								p2.SetActive(true);
								p3.SetActive(false);
								p4.SetActive(false);
								p5.SetActive(false);
								m2.SetActive(false);
								m4.SetActive(false);
								m5.SetActive(false);
								m6.SetActive(false);
								i=3;
							}

							if(i==5){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
			
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
				
								p.SetActive(false);	
								p1.SetActive(false);
								p2.SetActive(false);
								p3.SetActive(true);
								p4.SetActive(false);
								p5.SetActive(false);
								m2.SetActive(false);
								m4.SetActive(true);
								m5.SetActive(false);
								m6.SetActive(false);
								i=4;
							}
							if(i==6){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
						
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(true);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
						
								p.SetActive(false);	
								p1.SetActive(false);
								p2.SetActive(false);
								p3.SetActive(false);
								p4.SetActive(true);
								p5.SetActive(false);
								m2.SetActive(false);
								m4.SetActive(false);
								m5.SetActive(true);
								m6.SetActive(false);
								i=5;
							}
							if(i==7){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
						
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(true);
								Texto7.SetActive(false);
								
								p.SetActive(false);	
								p1.SetActive(false);
								p2.SetActive(false);
								p3.SetActive(false);
								p4.SetActive(false);
								p5.SetActive(true);
								Anterior.SetActive(true);
								m2.SetActive(false);
								m4.SetActive(false);
								m5.SetActive(false);
								m6.SetActive(true);
								i=6;
							}
							
							break;
							
						case "Next":

							if(i==6){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(true);
								Guardar.SetActive(true);
								Lecciones.SetActive(false);
								p.SetActive(false);	
								p1.SetActive(false);
								p2.SetActive(false);
								p3.SetActive(false);
								p4.SetActive(true);
								p5.SetActive(false);
								Anterior.SetActive(true);
								Next.SetActive(false);
								m2.SetActive(false);
								m4.SetActive(false);
								m5.SetActive(false);
								m6.SetActive(false);
								i=7;
							}
							if(i==5){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
						
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(true);
								Texto7.SetActive(false);
								Guardar.SetActive(false);
								Lecciones.SetActive(true);
								p.SetActive(false);	
								p1.SetActive(false);
								p2.SetActive(false);
								p3.SetActive(false);
								p4.SetActive(false);
								p5.SetActive(true);
								Next.SetActive(true);
								m2.SetActive(false);
								m4.SetActive(false);
								m5.SetActive(false);
								m6.SetActive(true);
								i=6;
							}
							if(i==4){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
						
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(true);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								p.SetActive(false);	
								p1.SetActive(false);
								p2.SetActive(false);
								p3.SetActive(false);
								p4.SetActive(true);
								p5.SetActive(false);
								Next.SetActive(true);
								m2.SetActive(false);
								m4.SetActive(false);
								m5.SetActive(true);
								m6.SetActive(false);
								i=5;
							}

							if(i==3){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);

								p.SetActive(false);	
								p1.SetActive(false);
								p2.SetActive(false);
								p3.SetActive(true);
								p4.SetActive(false);
								p5.SetActive(false);
								Next.SetActive(true);
								m2.SetActive(false);
								m4.SetActive(true);
								m5.SetActive(false);
								m6.SetActive(false);
								i=4;
							}

							if(i==2){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								
								p.SetActive(false);	
								p1.SetActive(false);
								p2.SetActive(true);
								p3.SetActive(false);
								p4.SetActive(false);
								p5.SetActive(false);
								Next.SetActive(true);
								m2.SetActive(false);
								m4.SetActive(false);
								m5.SetActive(false);
								m6.SetActive(false);
								i=3;
							}

							if(i==1){
							    Anterior.SetActive(true);
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
						
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
									
								p.SetActive(false);	
								p1.SetActive(true);
								p2.SetActive(false);
								p3.SetActive(false);
								p4.SetActive(false);
								p5.SetActive(false);
								Next.SetActive(true);
								m2.SetActive(true);
								m4.SetActive(false);
								m5.SetActive(false);
								m6.SetActive(false);
								i=2;
							}

							break;
							
						case "Escuchar":
							Application.LoadLevel("Escuchar0");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo0");
							
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
						
						//if(PlayGlobal.GetComponent<AudioSource>().isPlaying){
								PlayGlobal.GetComponent<AudioSource>().pitch=Pitch*3;
						//}
					
						break;
						
						case "Nazad":
						
						//if(PlayGlobal.GetComponent<AudioSource>().isPlaying){
								j=j+1;
								PlayGlobal.GetComponent<AudioSource>().pitch=(Pitch-j)/2;
						//}
					    break;
					}
				}
				if (theTouch.phase == TouchPhase.Ended)
				{
					j=0;
					PlayGlobal.GetComponent<AudioSource>().pitch=Pitch;
				}
			}
		}
	}
}
