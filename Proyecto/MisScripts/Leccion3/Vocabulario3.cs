using UnityEngine;
using System.Collections;

public class Vocabulario3 : MonoBehaviour
{
	GameObject Texto, Texto2, Texto3,Texto4,Texto5,Texto6,Texto7,Ts,Ch,Shi,M,N,L,R,
	Play, Next,Anterior,Escuchar, Dialogo, Ejercicios, Exit,Lecciones, Musica,arm,cara;
	AudioSource source,source2,source3,source4,source5,source6,source7;
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
		Ts=GameObject.Find("Ts");
		Ch=GameObject.Find("Ch");
		Shi=GameObject.Find("Shi");
		M=GameObject.Find("M");
		N=GameObject.Find("N");
		L=GameObject.Find("L");
		R=GameObject.Find("R");

		Musica=GameObject.Find("Musica");
		arm=GameObject.Find("arm");
		cara=GameObject.Find("cara");
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
		Ch.SetActive(false);
		Shi.SetActive(false);
		M.SetActive(false);
		N.SetActive(false);
		L.SetActive(false);
		R.SetActive(false);
		Musica.SetActive(false);
		arm.SetActive(false);
		cara.SetActive(false);
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
							break;
							
					
						case "Anterior":
							if(i==1){
								Anterior.SetActive(false);
								Musica.SetActive(false);
								Texto.SetActive(true);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Ts.SetActive(true);
								Ch.SetActive(false);
								Shi.SetActive(false);
								M.SetActive(false);
								N.SetActive(false);
								L.SetActive(false);
								R.SetActive(false);
								arm.SetActive(false);
								cara.SetActive(false);
							}
							if(i==2){
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								Musica.SetActive(false);
								Anterior.SetActive(false);
								Texto.SetActive(true);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Ts.SetActive(true);
								Ch.SetActive(false);
								Shi.SetActive(false);
								M.SetActive(false);
								N.SetActive(false);
								L.SetActive(false);
								R.SetActive(false);
								arm.SetActive(false);
								cara.SetActive(false);
								i=1;
							}

							if(i==3){
								Musica.SetActive(false);
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
								Ts.SetActive(false);
								Ch.SetActive(true);
								Shi.SetActive(false);
								M.SetActive(false);
								N.SetActive(false);
								L.SetActive(false);
								R.SetActive(false);
								arm.SetActive(false);
								cara.SetActive(false);
								i=2;
							}

							if(i==4){
								source.Stop();
								source2.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								Musica.SetActive(false);	
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Ts.SetActive(false);
								Ch.SetActive(false);
								Shi.SetActive(true);
								M.SetActive(false);
								N.SetActive(false);
								L.SetActive(false);
								R.SetActive(false);
								arm.SetActive(false);
								cara.SetActive(false);
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
								Ts.SetActive(false);
								Ch.SetActive(false);
								Shi.SetActive(false);
								M.SetActive(true);
								N.SetActive(false);
								L.SetActive(false);
								R.SetActive(false);
							    Next.SetActive(true);
								Musica.SetActive(true);
								arm.SetActive(false);
								cara.SetActive(false);
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
							Ts.SetActive(false);
							Ch.SetActive(false);
							Shi.SetActive(false);
							M.SetActive(false);
							N.SetActive(true);
							L.SetActive(false);
							R.SetActive(false);
							Next.SetActive(true);
							Musica.SetActive(false);
							arm.SetActive(false);
							cara.SetActive(false);
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
							Ts.SetActive(false);
							Ch.SetActive(false);
							Shi.SetActive(false);
							M.SetActive(false);
							N.SetActive(false);
							L.SetActive(true);
							R.SetActive(false);
							Next.SetActive(true);
							Musica.SetActive(false);
							arm.SetActive(false);
							cara.SetActive(true);
							i=6;
						}
							break;
							
						case "Next":

							if(i==7){
								Next.SetActive(false);
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(true);
								Ts.SetActive(false);
								Ch.SetActive(false);
								Shi.SetActive(false);
								M.SetActive(false);
								N.SetActive(false);
								L.SetActive(false);
								R.SetActive(true);
								Musica.SetActive(false);
								arm.SetActive(true);
								cara.SetActive(false);
							}
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
								Next.SetActive(false);
								Ts.SetActive(false);
								Ch.SetActive(false);
								Shi.SetActive(false);
								M.SetActive(false);
								N.SetActive(false);
								L.SetActive(false);
								R.SetActive(true);
								Musica.SetActive(false);
								arm.SetActive(true);
								cara.SetActive(false);
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
								Ts.SetActive(false);
								Ch.SetActive(false);
								Shi.SetActive(false);
								M.SetActive(false);
								N.SetActive(false);
								L.SetActive(true);
								R.SetActive(false);
								Musica.SetActive(false);
								arm.SetActive(false);
								cara.SetActive(true);
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
								Ts.SetActive(false);
								Ch.SetActive(false);
								Shi.SetActive(false);
								M.SetActive(false);
								N.SetActive(true);
								L.SetActive(false);
								R.SetActive(false);
								arm.SetActive(false);
								Musica.SetActive(false);
								cara.SetActive(false);
								i=5;
							}

							if(i==3){
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
								Ts.SetActive(false);
								Ch.SetActive(false);
								Shi.SetActive(false);
								M.SetActive(true);
								N.SetActive(false);
								L.SetActive(false);
								R.SetActive(false);
								Musica.SetActive(true);
								arm.SetActive(false);
								cara.SetActive(false);
								i=4;
							}

							if(i==2){
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
								Ts.SetActive(false);
								Ch.SetActive(false);
								Shi.SetActive(true);
								M.SetActive(false);
								N.SetActive(false);
								L.SetActive(false);
								R.SetActive(false);
								arm.SetActive(false);
								Musica.SetActive(false);
								cara.SetActive(false);
								i=3;
							}

							if(i==1){
							    Anterior.SetActive(true);
								source.Stop();
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
								Ts.SetActive(false);
								Ch.SetActive(true);
								Shi.SetActive(false);
								M.SetActive(false);
								N.SetActive(false);
								L.SetActive(false);
								R.SetActive(false);
								Musica.SetActive(false);
								arm.SetActive(false);
								cara.SetActive(false);
								i=2;
							}

							break;
							
						case "Escuchar":
							Application.LoadLevel("Escuchar3");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo3");
							
							break;
							
						case "Ejercicios":
							//Ejercicios1 ej1=new Ejercicios1(1);
							//ej1.PutK(1);
							Application.LoadLevel("Ejercicios3");
							
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
