using UnityEngine;
using System.Collections;

public class Escuchar13 : MonoBehaviour
{
	GameObject texto1, texto2, texto3,texto4,texto5,texto6,texto7,
	Play, Pause, Next, Repeat, Anterior, Vocabulario, Dialogo, Ejercicios, Exit,Lecciones,modelo1,modelo4,modelo2,modelo7,PlayGlobal,Vpered,Nazad,PausaGlobal;
	AudioSource source,source2,source3,source4,source5,source6,source7;
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

		modelo1=GameObject.Find("modelo1");
		modelo2=GameObject.Find("modelo2");
		modelo4=GameObject.Find("modelo4");
		modelo7=GameObject.Find("modelo7");

		source=texto1.GetComponent<AudioSource>();
		source2=texto2.GetComponent<AudioSource>();
		source3=texto3.GetComponent<AudioSource>();
		source4=texto4.GetComponent<AudioSource>();
		source5=texto5.GetComponent<AudioSource>();
		source6=texto6.GetComponent<AudioSource>();
		source7=texto7.GetComponent<AudioSource>();

		if (cam == null){
			cam = Camera.main;
		}
	
		
		texto2.SetActive(false);
		texto3.SetActive(false);
		texto4.SetActive(false);
		texto5.SetActive(false);
		texto6.SetActive(false);
		texto7.SetActive(false);

		modelo2.SetActive(false);
		modelo4.SetActive(false);
		modelo7.SetActive(false);
		
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
								modelo1.SetActive(true);
								modelo2.SetActive(false);
								modelo4.SetActive(false);
								modelo7.SetActive(false);
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
								modelo1.SetActive(false);
								modelo2.SetActive(true);
								modelo4.SetActive(false);
								modelo7.SetActive(false);
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
								modelo1.SetActive(false);
								modelo2.SetActive(false);
								modelo4.SetActive(false);
								modelo7.SetActive(false);
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
								modelo1.SetActive(false);
								modelo2.SetActive(false);
								modelo4.SetActive(true);
								modelo7.SetActive(false);
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
								modelo1.SetActive(false);
								modelo2.SetActive(false);
								modelo4.SetActive(false);
								modelo7.SetActive(false);
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
								modelo1.SetActive(false);
								modelo2.SetActive(false);
								modelo4.SetActive(false);
								modelo7.SetActive(false);
								Next.SetActive(true);
								i=6;
							}
							
							break;
							
						case "Next":
							
						if(i==6){
							
							i=7;
							texto1.SetActive(false);
							texto2.SetActive(false);
							texto3.SetActive(false);
							texto4.SetActive(false);
							texto5.SetActive(false);
							texto6.SetActive(false);
							texto7.SetActive(true);
							modelo1.SetActive(false);
							modelo2.SetActive(false);
							modelo4.SetActive(false);
							modelo7.SetActive(true);
							Next.SetActive(false);
							
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
							modelo1.SetActive(false);
							modelo2.SetActive(false);
							modelo4.SetActive(false);
							modelo7.SetActive(false);
							Next.SetActive(true);
							
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
								modelo1.SetActive(false);
								modelo2.SetActive(false);
								modelo4.SetActive(false);
								modelo7.SetActive(false);

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
								modelo1.SetActive(false);
								modelo2.SetActive(false);
								modelo4.SetActive(true);
								modelo7.SetActive(false);

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
								modelo1.SetActive(false);
								modelo2.SetActive(false);
								modelo4.SetActive(false);
								modelo7.SetActive(false);
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
								modelo1.SetActive(false);
								modelo2.SetActive(true);
								modelo4.SetActive(false);
								modelo7.SetActive(false);
								Anterior.SetActive(true);
							}
							break;
							
						case "Vocabulario":
							Application.LoadLevel("Vocabulario13");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo13");
							
							break;
							
						case "Ejercicios":
							Application.LoadLevel("Ejercicios13");
							
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
