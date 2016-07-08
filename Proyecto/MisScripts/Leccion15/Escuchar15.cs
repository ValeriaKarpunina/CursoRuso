using UnityEngine;
using System.Collections;

public class Escuchar15 : MonoBehaviour
{
	GameObject texto1, texto2,verbo1,verbo2,
	Play, Pause, Next, Repeat, Anterior, Vocabulario, Dialogo, Ejercicios, Exit,Lecciones,PlayGlobal,Vpered,Nazad,PausaGlobal;
	AudioSource source,source2;
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

		verbo1=GameObject.Find("verbo1");
		verbo2=GameObject.Find("verbo2");


		source=texto1.GetComponent<AudioSource>();
		source2=texto2.GetComponent<AudioSource>();
	
		if (cam == null){
			cam = Camera.main;
		}
	
		
		texto2.SetActive(false);
	
		verbo2.SetActive(false);

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

					
							break;
							
							
						case "Anterior":
							
							Debug.Log ("Se pasa al audio anterior");

							if(i==1){
								texto1.SetActive(true);
								texto2.SetActive(false);

								verbo1.SetActive(true);
								verbo2.SetActive(false);
								
								Anterior.SetActive(false);
								Next.SetActive(true);
							}

							if(i==2){
								texto1.SetActive(true);
								texto2.SetActive(false);
								
								verbo1.SetActive(true);
								verbo2.SetActive(false);
								
								Anterior.SetActive(false);
								Next.SetActive(true);
								i=1;
							}
	
							break;
							
						case "Next":
							
							Debug.Log ("Se pasa a siguiente audio");


							if(i==2){
								Next.SetActive(false);
								Anterior.SetActive(true);
								texto1.SetActive(false);
								texto2.SetActive(true);
								
								verbo1.SetActive(false);
								verbo2.SetActive(true);
								
							}
							if(i==1){

								i=2;
								texto1.SetActive(false);
								texto2.SetActive(true);

								verbo1.SetActive(false);
								verbo2.SetActive(true);
								
								Anterior.SetActive(true);
								Next.SetActive(false);
							}
							break;
							
						case "Vocabulario":
							Application.LoadLevel("Vocabulario15");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo15");
							
							break;
							
						case "Ejercicios":
							Application.LoadLevel("Ejercicios15");
							
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
