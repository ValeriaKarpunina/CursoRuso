using UnityEngine;
using System.Collections;

public class Escuchar5 : MonoBehaviour
{
	GameObject texto1, texto2, texto3,texto4,texto5,texto6,texto7,texto8,
	Play, Pause, Next, Repeat, Anterior, Vocabulario, Dialogo, Ejercicios, Exit,Lecciones,yawn;
	AudioSource source,source2,source3,source4,source5,source6,source7,source8;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i;
	
	void Start () {

		i=1;

		Play=GameObject.Find("Play");
		Next=GameObject.Find("Next");
		Anterior=GameObject.Find ("Anterior");
		Vocabulario=GameObject.Find("Vocabulario");
		Dialogo=GameObject.Find("Dialogo");
		Ejercicios=GameObject.Find("Ejercicios");
		Lecciones=GameObject.Find("Lecciones");
		Exit=GameObject.Find("Exit");
		yawn=GameObject.Find("yawn");
		
		
		texto1=GameObject.Find("Texto1");
		texto2=GameObject.Find("Texto2");
		texto3=GameObject.Find("Texto3");
		texto4=GameObject.Find("Texto4");
		texto5=GameObject.Find("Texto5");
		texto6=GameObject.Find("Texto6");
		texto7=GameObject.Find("Texto7");
		texto8=GameObject.Find("Texto8");

		source=texto1.GetComponent<AudioSource>();
		source2=texto2.GetComponent<AudioSource>();
		source3=texto3.GetComponent<AudioSource>();
		source4=texto4.GetComponent<AudioSource>();
		source5=texto5.GetComponent<AudioSource>();
		source6=texto6.GetComponent<AudioSource>();
		source7=texto7.GetComponent<AudioSource>();
		source8=texto8.GetComponent<AudioSource>();

		if (cam == null){
			cam = Camera.main;
		}
	
		
		texto2.SetActive(false);
		texto3.SetActive(false);
		texto4.SetActive(false);
		texto5.SetActive(false);
		texto6.SetActive(false);
		texto7.SetActive(false);
		texto8.SetActive(false);
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
							
						case "Play":
							
						if(i==1 && !source.isPlaying){
								source.Play();
								yawn.GetComponent<Animation>().Play();
							}
						if(i==2 && !source2.isPlaying){
								source2.Play();
								yawn.GetComponent<Animation>().Play();
							}
						if(i==3&& !source3.isPlaying){
								source3.Play();
								yawn.GetComponent<Animation>().Play();
							}
						if(i==4 && !source4.isPlaying){
								source4.Play();
								yawn.GetComponent<Animation>().Play();
							}
						if(i==5 && !source5.isPlaying){
								source5.Play();
								yawn.GetComponent<Animation>().Play();
							}
						if(i==6 && !source6.isPlaying){
								source6.Play();
								yawn.GetComponent<Animation>().Play();
						}
						if(i==7 && !source7.isPlaying){
								source7.Play();
								yawn.GetComponent<Animation>().Play();
						}
						if(i==8 && !source8.isPlaying){
								source8.Play();
								yawn.GetComponent<Animation>().Play();
						}
							break;
							
							
						case "Anterior":
							
							Debug.Log ("Se pasa al audio anterior");

							if(i==2){
								texto1.SetActive(true);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(false);
								texto6.SetActive(false);
								texto7.SetActive(false);
								texto8.SetActive(false);
								Anterior.SetActive(false);
								Next.SetActive(true);
								i=1;
							}
							if(i==3){
								texto1.SetActive(false);
								texto2.SetActive(true);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(false);
								texto6.SetActive(false);
								texto7.SetActive(false);
								texto8.SetActive(false);
								Next.SetActive(true);
								i=2;
							}
							if(i==4){
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(true);
								texto4.SetActive(false);
								texto5.SetActive(false);
								texto6.SetActive(false);
								texto7.SetActive(false);
								texto8.SetActive(false);
								Next.SetActive(true);
								i=3;
							}
							if(i==5){
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(true);
								texto5.SetActive(false);
								texto6.SetActive(false);
								texto7.SetActive(false);
								texto8.SetActive(false);
								Next.SetActive(true);
								i=4;
							}
							if(i==6){
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(true);
								texto6.SetActive(false);
								texto7.SetActive(false);
								texto8.SetActive(false);
								Next.SetActive(true);
								i=5;
							}
							if(i==7){
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(false);
								texto6.SetActive(true);
								texto7.SetActive(false);
								texto8.SetActive(false);
								Next.SetActive(true);
								i=6;
							}
							if(i==8){
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(false);
								texto6.SetActive(false);
								texto7.SetActive(true);
								texto8.SetActive(false);
								Next.SetActive(true);
								i=7;
							}
							break;
							
						case "Next":
							
							Debug.Log ("Se pasa a siguiente audio");
						if(i==7){
							
							i=8;
							texto1.SetActive(false);
							texto2.SetActive(false);
							texto3.SetActive(false);
							texto4.SetActive(false);
							texto5.SetActive(false);
							texto6.SetActive(false);
							texto7.SetActive(false);
							texto8.SetActive(true);
							Next.SetActive(false);
						}
						if(i==6){
							
							i=7;
							texto1.SetActive(false);
							texto2.SetActive(false);
							texto3.SetActive(false);
							texto4.SetActive(false);
							texto5.SetActive(false);
							texto6.SetActive(false);
							texto7.SetActive(true);
							texto8.SetActive(false);
							Next.SetActive(true);
							
						}
						if(i==5){
							
							i=6;
							texto1.SetActive(false);
							texto2.SetActive(false);
							texto3.SetActive(false);
							texto4.SetActive(false);
							texto5.SetActive(false);
							texto6.SetActive(true);
							texto7.SetActive(false);
							texto8.SetActive(false);
							
						}
							if(i==4){
								
								i=5;
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(true);
								texto6.SetActive(false);
								texto7.SetActive(false);
								texto8.SetActive(false);

							}
							if(i==3){
								
								i=4;
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(true);
								texto5.SetActive(false);
								texto6.SetActive(false);
								texto7.SetActive(false);
								texto8.SetActive(false);
							}
							if(i==2){
								
								i=3;
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(true);
								texto4.SetActive(false);
								texto5.SetActive(false);
								texto6.SetActive(false);
								texto7.SetActive(false);
								texto8.SetActive(false);
							}
							if(i==1){

								i=2;
								texto1.SetActive(false);
								texto2.SetActive(true);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(false);
								texto6.SetActive(false);
								texto7.SetActive(false);
								texto8.SetActive(false);
								Anterior.SetActive(true);
							}
							break;
							
						case "Vocabulario":
							Application.LoadLevel("Vocabulario5");
							
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
