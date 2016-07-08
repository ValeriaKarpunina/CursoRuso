using UnityEngine;
using System.Collections;

public class Escuchar9 : MonoBehaviour
{
	GameObject texto1, texto2, texto3,texto4,texto5,texto6,texto7,texto8,texto9,texto10,
	Play, Pause, Next, Repeat, Anterior, Vocabulario, Dialogo, Ejercicios, Exit,Lecciones,
	model1,model7,model9,PlayGlobal,Vpered,Nazad,PausaGlobal;
	AudioSource source,source2,source3,source4,source5,source6,source7,source8,source9,source10;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i,j;
	float Pitch;

	void Start () {

		i=1;
		j=0;
		Play=GameObject.Find("Play");
		Next=GameObject.Find("Next");
		Anterior=GameObject.Find ("Anterior");
		Vocabulario=GameObject.Find("Vocabulario");
		Dialogo=GameObject.Find("Dialogo");
		Ejercicios=GameObject.Find("Ejercicios");
		Lecciones=GameObject.Find("Lecciones");
		Exit=GameObject.Find("Exit");
		
		PlayGlobal=GameObject.Find("PlayGlobal");
		Vpered=GameObject.Find("Vpered");
		Nazad=GameObject.Find("Nazad");
		PausaGlobal=GameObject.Find("PausaGlobal");

		texto1=GameObject.Find("Texto1");
		texto2=GameObject.Find("Texto2");
		texto3=GameObject.Find("Texto3");
		texto4=GameObject.Find("Texto4");
		texto5=GameObject.Find("Texto5");
		texto6=GameObject.Find("Texto6");
		texto7=GameObject.Find("Texto7");
		texto8=GameObject.Find("Texto8");
		texto9=GameObject.Find("Texto9");
		texto10=GameObject.Find("Texto10");

		model1=GameObject.Find("model1");
		model7=GameObject.Find("model7");
		model9=GameObject.Find("model9");

		source=texto1.GetComponent<AudioSource>();
		source2=texto2.GetComponent<AudioSource>();
		source3=texto3.GetComponent<AudioSource>();
		source4=texto4.GetComponent<AudioSource>();
		source5=texto5.GetComponent<AudioSource>();
		source6=texto6.GetComponent<AudioSource>();
		source7=texto7.GetComponent<AudioSource>();
		source8=texto8.GetComponent<AudioSource>();
		source9=texto9.GetComponent<AudioSource>();
		source10=texto10.GetComponent<AudioSource>();

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
		texto9.SetActive(false);
		texto10.SetActive(false);

		model7.SetActive(false);
		model9.SetActive(false);
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

						case "Play":
							
						if(i==1 && !source.isPlaying){
								source.Play();
							}
						if(i==2 && !source2.isPlaying){
								source2.Play();
							}
						if(i==3&& !source3.isPlaying){
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
						if(i==10 && !source10.isPlaying){
							source10.Play();
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
								texto9.SetActive(false);
								texto10.SetActive(false);
								model1.SetActive(true);
								model7.SetActive(false);
								model9.SetActive(false);
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
								texto9.SetActive(false);
								texto10.SetActive(false);
								model1.SetActive(false);
								model7.SetActive(false);
								model9.SetActive(false);
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
								texto9.SetActive(false);
								texto10.SetActive(false);
								model1.SetActive(false);
								model7.SetActive(false);
								model9.SetActive(false);
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
								texto9.SetActive(false);
								texto10.SetActive(false);
								model1.SetActive(false);
								model7.SetActive(false);
								model9.SetActive(false);
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
								texto9.SetActive(false);
								texto10.SetActive(false);
								model1.SetActive(false);
								model7.SetActive(false);
								model9.SetActive(false);
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
								texto9.SetActive(false);
								texto10.SetActive(false);
								model1.SetActive(false);
								model7.SetActive(false);
								model9.SetActive(false);
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
								texto9.SetActive(false);
								texto10.SetActive(false);
								model1.SetActive(false);
								model7.SetActive(true);
								model9.SetActive(false);
								Next.SetActive(true);
								i=7;
							}
							if(i==9){
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(false);
								texto6.SetActive(false);
								texto7.SetActive(false);
								texto8.SetActive(true);
								texto9.SetActive(false);
								texto10.SetActive(false);
								model1.SetActive(false);
								model7.SetActive(false);
								model9.SetActive(false);
								Next.SetActive(true);
								i=8;
							}
							if(i==10){
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(false);
								texto6.SetActive(false);
								texto7.SetActive(false);
								texto8.SetActive(false);
								texto9.SetActive(true);
								texto10.SetActive(false);
								model1.SetActive(false);
								model7.SetActive(false);
								model9.SetActive(true);
								Next.SetActive(true);
								i=9;
							}
						break;
							
						case "Next":
						if(i==9){
							
							i=10;
							texto1.SetActive(false);
							texto2.SetActive(false);
							texto3.SetActive(false);
							texto4.SetActive(false);
							texto5.SetActive(false);
							texto6.SetActive(false);
							texto7.SetActive(false);
							texto8.SetActive(false);
							texto9.SetActive(false);
							texto10.SetActive(true);
							model1.SetActive(false);
							model7.SetActive(false);
							model9.SetActive(false);
							Next.SetActive(false);
						}
						if(i==8){
							
							i=9;
							texto1.SetActive(false);
							texto2.SetActive(false);
							texto3.SetActive(false);
							texto4.SetActive(false);
							texto5.SetActive(false);
							texto6.SetActive(false);
							texto7.SetActive(false);
							texto8.SetActive(false);
							texto9.SetActive(true);
							texto10.SetActive(false);
							model1.SetActive(false);
							model7.SetActive(false);
							model9.SetActive(true);
							Next.SetActive(true);
						}
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
							texto9.SetActive(false);
							texto10.SetActive(false);
							model1.SetActive(false);
							model7.SetActive(false);
							model9.SetActive(false);
							Next.SetActive(true);
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
							texto9.SetActive(false);
							texto10.SetActive(false);
							model1.SetActive(false);
							model7.SetActive(true);
							model9.SetActive(false);
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
							texto9.SetActive(false);
							texto10.SetActive(false);
							model1.SetActive(false);
							model7.SetActive(false);
							model9.SetActive(false);
							
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
								texto9.SetActive(false);
								texto10.SetActive(false);
								model1.SetActive(false);
								model7.SetActive(false);
								model9.SetActive(false);

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
								texto9.SetActive(false);
								texto10.SetActive(false);
								model1.SetActive(false);
								model7.SetActive(false);
								model9.SetActive(false);
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
								texto9.SetActive(false);
								texto10.SetActive(false);
								model1.SetActive(false);
								model7.SetActive(false);
								model9.SetActive(false);
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
								texto9.SetActive(false);
								texto10.SetActive(false);
								Anterior.SetActive(true);
								model1.SetActive(false);
								model7.SetActive(false);
								model9.SetActive(false);
							}
							break;
							
						case "Vocabulario":
							Application.LoadLevel("Vocabulario9");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo9");
							
							break;
							
						case "Ejercicios":

							Application.LoadLevel("Ejercicios9");
							
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
			}
		}
	}
}
