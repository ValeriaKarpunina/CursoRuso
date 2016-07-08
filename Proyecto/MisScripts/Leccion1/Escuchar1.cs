using UnityEngine;
using System.Collections;

public class Escuchar1 : MonoBehaviour
{
	GameObject texto1, texto2, texto3,texto4,texto5,
	Play, Pause, Next, Repeat, Anterior, Vocabulario, Dialogo, Ejercicios, Exit,Lecciones, Model;
	AudioSource source,source2,source3,source4,source5;
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
		texto5=GameObject.Find("Texto5");

		source=texto1.GetComponent<AudioSource>();
		source2=texto2.GetComponent<AudioSource>();
		source3=texto3.GetComponent<AudioSource>();
		source4=texto4.GetComponent<AudioSource>();
		source5=texto5.GetComponent<AudioSource>();

		if (cam == null){
			cam = Camera.main;
		}
	
		texto2.SetActive(false);
		texto3.SetActive(false);
		texto4.SetActive(false);
		texto5.SetActive(false);
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
								girl.Play("anim1");
							}
						if(i==2 && !source2.isPlaying){
								source2.Play();
								girl.Play("anim2");
							}
						if(i==3&& !source3.isPlaying){
								source3.Play();
								girl.Play("anim3");
							}
						if(i==4 && !source4.isPlaying){
								source4.Play();
								girl.Play("anim4");
							}
						if(i==5 && !source5.isPlaying){
								source5.Play();
								girl.Play("anim5");
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
								Next.SetActive(true);
								Anterior.SetActive(false);
								i=1;
							}
							if(i==3){
								texto1.SetActive(false);
								texto2.SetActive(true);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(false);
								
								i=2;
							}
							if(i==4){
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(true);
								texto4.SetActive(false);
								texto5.SetActive(false);
								Next.SetActive(true);
						
								i=3;
							}
							if(i==5){
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(true);
								texto5.SetActive(false);
								Next.SetActive(true);
						
								i=4;
							}
							break;
							
						case "Next":
							
							Debug.Log ("Se pasa a siguiente audio");
							if(i==4){
								
								i=5;
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(true);
								Next.SetActive(false);

							}
							if(i==3){
								
								i=4;
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(false);
								texto4.SetActive(true);
								texto5.SetActive(false);

							}
							if(i==2){
								
								i=3;
								texto1.SetActive(false);
								texto2.SetActive(false);
								texto3.SetActive(true);
								texto4.SetActive(false);
								texto5.SetActive(false);
								
							}
							if(i==1){

								i=2;
								texto1.SetActive(false);
								texto2.SetActive(true);
								texto3.SetActive(false);
								texto4.SetActive(false);
								texto5.SetActive(false);
								Anterior.SetActive(true);

							}
							break;
							
						case "Vocabulario":
							Application.LoadLevel("Vocabulario1");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo1");
							
							break;
							
						case "Ejercicios":
							//Ejercicios1 ej1=new Ejercicios1(1);
							//ej1.PutK(1);
							Application.LoadLevel("Ejercicios1");
							
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
