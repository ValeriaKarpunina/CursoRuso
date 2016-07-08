using UnityEngine;
using System.Collections;

public class Escuchar10 : MonoBehaviour
{
	GameObject Texto, Texto2, Texto3,Play, Next,Anterior,Escuchar,
	Dialogo,Vocabulario, Ejercicios, Exit,Lecciones,boy,PlayGlobal,Vpered,Nazad,PausaGlobal;
	AudioSource source,source2,source3,source4,source5;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i,j;//identifica cada uno de los textos
	bool next,anterior;
	Animation boy1;
	float Pitch;

	void Start () {

		next=false;
		anterior=false;
		
		i=1; 
		j=0;
		Play=GameObject.Find("Play");
		Next=GameObject.Find("Next");
		boy=GameObject.Find("boy");
		boy1=boy.GetComponent<Animation>();
	
		Anterior=GameObject.Find ("Anterior");
		Vocabulario=GameObject.Find("Vocabulario");
		Dialogo=GameObject.Find("Dialogo");
		Escuchar=GameObject.Find("Escuchar");
		Ejercicios=GameObject.Find("Ejercicios");
		Exit=GameObject.Find("Exit");
		Lecciones=GameObject.Find("Lecciones");

		PlayGlobal=GameObject.Find("PlayGlobal");
		Vpered=GameObject.Find("Vpered");
		Nazad=GameObject.Find("Nazad");
		PausaGlobal=GameObject.Find("PausaGlobal");

		Texto=GameObject.Find("Texto");
		Texto2=GameObject.Find("Texto2");
		Texto3=GameObject.Find("Texto3");
		
		source=Texto.GetComponent<AudioSource>();
		source2=Texto2.GetComponent<AudioSource>();
		source3=Texto3.GetComponent<AudioSource>();
		
		
		if (cam == null){
			cam = Camera.main;
		}
		
		Anterior.SetActive(false);
		
		Texto2.SetActive(false);
		Texto3.SetActive(false);
	
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
							boy1.Play("anim1");
						}
						if(i==2 && !source2.isPlaying){
							source2.Play();
							boy1.Play("anim2");
						}
						if(i==3 && !source3.isPlaying){
							source3.Play();
							boy1.Play("anim3");
						}
						
						break;
						
						
					case "Anterior":
						if(i==1){
							Anterior.SetActive(false);
							Next.SetActive(true);
							Texto.SetActive(true);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							
						}
						if(i==2){
							source.Stop();
							source2.Stop();
							source3.Stop();
							
							Texto.SetActive(true);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Anterior.SetActive(false);
							Next.SetActive(true);
							i=1;
						}
						
						if(i==3){
							
							source.Stop();
							source2.Stop();
							source3.Stop();
							
							Anterior.SetActive(true);
							Texto.SetActive(false);
							Texto2.SetActive(true);
							Texto3.SetActive(false);
							
							Anterior.SetActive(true);
							Next.SetActive(true);
							
							i=2;
						}
						
						
						break;
						
					case "Next":
						
						
						if(i==2){
							source.Stop();
							source2.Stop();
							source3.Stop();
							
							Texto.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(true);
							
							Next.SetActive(false);
							i=3;
						}
						
						if(i==1){
							Anterior.SetActive(true);
							source.Stop();
							source2.Stop();
							source3.Stop();
							
							Texto.SetActive(false);
							Texto2.SetActive(true);
							Texto3.SetActive(false);
							
							Next.SetActive(true);
							i=2;
						}
						
						break;
							
						case "Vocabulario":
							Application.LoadLevel("Vocabulario10");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo10");
							
							break;
							
						case "Ejercicios":

							Application.LoadLevel("Ejercicios10");
							
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
