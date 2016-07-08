using UnityEngine;
using System.Collections;

public class Vocabulario5 : MonoBehaviour
{
	GameObject Texto, Texto2, Texto3,Texto4,Texto5,Texto6,Texto7,Texto8,Texto9,Z,C,G,K,Zh,Sh,
	Play, Next,Anterior,Escuchar, Dialogo, Ejercicios, Exit,Lecciones, Airplane3,Knife8,Snow5,Car9,Cat6;
	AudioSource source,source2,source3,source4,source5,source6,source7,source8,source9;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i;//identifica cada uno de los textos
	bool next,anterior;
	
	void Start () {
	
		next=false;
		anterior=false;

		i=1; 
	
		Play=GameObject.Find("Play");
		Next=GameObject.Find("Next");
		//Pause=GameObject.Find("Pause");
		Z=GameObject.Find("Z");
		C=GameObject.Find("C");
		G=GameObject.Find("G");
		K=GameObject.Find("K");
		Zh=GameObject.Find("Zh");
		Sh=GameObject.Find("Sh");

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
		Texto6=GameObject.Find("Texto6");
		Texto7=GameObject.Find("Texto7");
		Texto8=GameObject.Find("Texto8");
		Texto9=GameObject.Find("Texto9");

		Airplane3=GameObject.Find("Airplane3");
		Car9=GameObject.Find("Car9");
		Cat6=GameObject.Find("Cat6");
		Snow5=GameObject.Find("Snow5");
		Knife8=GameObject.Find("Knife8");

		source=Texto.GetComponent<AudioSource>();
		source2=Texto2.GetComponent<AudioSource>();
		source3=Texto3.GetComponent<AudioSource>();
		source4=Texto4.GetComponent<AudioSource>();
		source5=Texto5.GetComponent<AudioSource>();
		source6=Texto6.GetComponent<AudioSource>();
		source7=Texto7.GetComponent<AudioSource>();
		source8=Texto8.GetComponent<AudioSource>();
		source9=Texto9.GetComponent<AudioSource>();

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
		Texto8.SetActive(false);
		Texto9.SetActive(false);

		Z.SetActive(true);
		C.SetActive(false);
		G.SetActive(false);
		K.SetActive(false);
		Zh.SetActive(false);
		Sh.SetActive(false);
		Airplane3.SetActive(false);
		Car9.SetActive(false);
		Cat6.SetActive(false);
		Snow5.SetActive(false);
		Knife8.SetActive(false);
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
							if(i==8 && !source8.isPlaying){
								source8.Play();	
							}
							if(i==9 && !source9.isPlaying){
								source9.Play();	
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
								Texto8.SetActive(false);
								Texto9.SetActive(false);

								Z.SetActive(true);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(false);
								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
							}
							if(i==2){
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();

								Texto.SetActive(true);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);

								Z.SetActive(true);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(false);
								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
								i=1;
							}

							if(i==3){
								
								source.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();

								Anterior.SetActive(true);
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(true);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(false);
								
								Next.SetActive(true);
								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
								i=2;
							}

							if(i==4){
								source.Stop();
								source2.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(true);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(false);
								
								Airplane3.SetActive(true);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
								i=3;
							}

							if(i==5){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(true);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(false);

								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
								i=4;
							}
							if(i==6){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(true);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(true);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(false);

								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(true);
								Knife8.SetActive(false);
								Next.SetActive(true);
								i=5;
							}
							if(i==7){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(true);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(true);
								Zh.SetActive(false);
								Sh.SetActive(false);

								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(true);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
								Next.SetActive(true);
								i=6;
							}
							if(i==8){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(true);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(true);
								Sh.SetActive(false);

								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
								Next.SetActive(true);
								i=7;
							}
							if(i==9){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(true);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(true);
								Sh.SetActive(false);
								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(true);
								Next.SetActive(true);
								i=8;
							}
							break;
							
						case "Next":

							if(i==9){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(true);

								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(true);
								Next.SetActive(false);
								Airplane3.SetActive(false);
								Car9.SetActive(true);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
							}
							if(i==8){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(true);
								
								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(true);
								Next.SetActive(false);
								Airplane3.SetActive(false);
								Car9.SetActive(true);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
								i=9;
							}
							if(i==7){
									
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(true);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(true);
								Sh.SetActive(false);
								Next.SetActive(true);
								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(true);
								i=8;
							}
							if(i==6){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(true);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(true);
								Sh.SetActive(false);
								Next.SetActive(true);
								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
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
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(true);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(true);
								Zh.SetActive(false);
								Sh.SetActive(false);
								Next.SetActive(true);
								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(true);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
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
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(true);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(true);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(false);
								Next.SetActive(true);
								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(true);
								Knife8.SetActive(false);
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
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(false);
								G.SetActive(true);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(false);
								Next.SetActive(true);
								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
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
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(false);
								C.SetActive(true);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(false);
								Next.SetActive(true);
								Airplane3.SetActive(true);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
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
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								Z.SetActive(true);
								C.SetActive(false);
								G.SetActive(false);
								K.SetActive(false);
								Zh.SetActive(false);
								Sh.SetActive(false);
								Next.SetActive(true);
								Airplane3.SetActive(false);
								Car9.SetActive(false);
								Cat6.SetActive(false);
								Snow5.SetActive(false);
								Knife8.SetActive(false);
								i=2;
							}

							break;
							
						case "Escuchar":
							Application.LoadLevel("Escuchar5");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo5");
							
							break;
							
						case "Ejercicios":
							//Ejercicios1 ej1=new Ejercicios1(1);
							//ej1.PutK(1);
							Application.LoadLevel("Ejercicios5");
							
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
