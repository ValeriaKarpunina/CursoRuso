using UnityEngine;
using System.Collections;

public class Escuchar4 : MonoBehaviour
{
	GameObject texto1, texto2, texto3,texto4,
	Play, Pause, Next, Repeat, Anterior, Vocabulario, Dialogo, Ejercicios, Exit,Lecciones,Model;
	AudioSource source,source2,source3,source4;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i;
	Animation girl;

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
		Model=GameObject.Find("Model");
		
		girl=Model.GetComponent<Animation>();

		texto1=GameObject.Find("Texto1");
		texto2=GameObject.Find("Texto2");
		texto3=GameObject.Find("Texto3");
		texto4=GameObject.Find("Texto4");

		source=texto1.GetComponent<AudioSource>();
		source2=texto2.GetComponent<AudioSource>();
		source3=texto3.GetComponent<AudioSource>();
		source4=texto4.GetComponent<AudioSource>();

		if (cam == null){
			cam = Camera.main;
		}
	
		
		texto2.SetActive(false);
		texto3.SetActive(false);
		texto4.SetActive(false);
	
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
								girl.Play("anim4");
							}
						if(i==2 && !source2.isPlaying){
								source2.Play();
								girl.Play("nichego");
							}
						if(i==3&& !source3.isPlaying){
								source3.Play();
								girl.Play("plojo");
							}
						if(i==4 && !source4.isPlaying){
								source4.Play();
								girl.Play("anim3");
							}
					
							break;
							
							
						case "Anterior":
							
							Debug.Log ("Se pasa al audio anterior");

							if(i==2){
								texto1.SetActive(true);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(false);

								Anterior.SetActive(false);
								Next.SetActive(true);
								i=1;
							}
							if(i==3){
								texto1.SetActive(false);
								texto2.SetActive(true);
								texto3.SetActive(false);
								texto4.SetActive(false);
								
								Next.SetActive(true);
								i=2;
							}
							if(i==4){
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(true);
								texto4.SetActive(false);
								
								Next.SetActive(true);
								i=3;
							}

							break;
							
						case "Next":
							
							Debug.Log ("Se pasa a siguiente audio");

							if(i==3){
								
								i=4;
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(true);
								
								Next.SetActive(false);

							}
							if(i==2){
								
								i=3;
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(true);
								texto4.SetActive(false);
								
							}
							if(i==1){

								i=2;
								texto1.SetActive(false);
								texto2.SetActive(true);
								texto3.SetActive(false);
								texto4.SetActive(false);
								
								Anterior.SetActive(true);
							}
							break;
							
						case "Vocabulario":
							Application.LoadLevel("Vocabulario4");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo4");
							
							break;
							
						case "Ejercicios":
							//Ejercicios1 ej1=new Ejercicios1(1);
							//ej1.PutK(1);
							Application.LoadLevel("Ejercicios4");
							
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
