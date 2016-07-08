using UnityEngine;
using System.Collections;

public class Escuchar0 : MonoBehaviour
{
	GameObject texto1,
	Play,Next, Repeat, Anterior, Vocabulario, Dialogo, Ejercicios, Exit,Lecciones, Model,PlayGlobal,Vpered,Nazad,PausaGlobal;
	AudioSource source;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i,j;
	Animation girl;
	float Pitch;

	void Start () {

		i=1;
		j=0;

		Play=GameObject.Find("Play");
		Vocabulario=GameObject.Find("Vocabulario");
		Dialogo=GameObject.Find("Dialogo");
		Ejercicios=GameObject.Find("Ejercicios");
		Lecciones=GameObject.Find("Lecciones");
		Exit=GameObject.Find("Exit");
		Model=GameObject.Find("Model");

		girl=Model.GetComponent<Animation>();

		texto1=GameObject.Find("Texto1");

		PlayGlobal=GameObject.Find("PlayGlobal");
		Vpered=GameObject.Find("Vpered");
		Nazad=GameObject.Find("Nazad");
		PausaGlobal=GameObject.Find("PausaGlobal");

		source=texto1.GetComponent<AudioSource>();

		if (cam == null){
			cam = Camera.main;
		}
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
								girl.Play("anim1");
							}
							break;
							
						case "Vocabulario":
							Application.LoadLevel("Vocabulario0");
							
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
