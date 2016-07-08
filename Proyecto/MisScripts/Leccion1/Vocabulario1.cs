using UnityEngine;
using System.Collections;

public class Vocabulario1 : MonoBehaviour
{
	GameObject Texto, Texto2, Texto3,Texto4,Texto5,A,O,I,U,E,
	Play, Next,Anterior,Escuchar, Dialogo, Ejercicios, Exit,Lecciones,Cow,phone;
	AudioSource source,source2,source3,source4,source5;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i;//identifica cada uno de los textos
	bool next,anterior,repetir,repetir2,repetir3,repetir4,repetir5;

	public void Start () {
	
		next=false;
		anterior=false;
		repetir=false;
		repetir2=false;
		repetir3=false;
		repetir4=false;
		repetir5=false;

		i=1; 
	
		Play=GameObject.Find("Play");
		Next=GameObject.Find("Next");
		phone=GameObject.Find("phone");
		//Pause=GameObject.Find("Pause");
		A=GameObject.Find("A");
		O=GameObject.Find("O");
		I=GameObject.Find("I");
		U=GameObject.Find("U");
		E=GameObject.Find("E");
		//Repeat=GameObject.Find("Repeat");
		Anterior=GameObject.Find ("Anterior");
		//Vocabulario=GameObject.Find("Vocabulario");
		Dialogo=GameObject.Find("Dialogo");
		Escuchar=GameObject.Find("Escuchar");
		Ejercicios=GameObject.Find("Ejercicios");
		Exit=GameObject.Find("Exit");
		Lecciones=GameObject.Find("Lecciones");
		Cow=GameObject.Find("Cow");
		
		Texto=GameObject.Find("Texto");
		Texto2=GameObject.Find("Texto2");
		Texto3=GameObject.Find("Texto3");
		Texto4=GameObject.Find("Texto4");
		Texto5=GameObject.Find("Texto5");

		source=Texto.GetComponent<AudioSource>();
		source2=Texto2.GetComponent<AudioSource>();
		source3=Texto3.GetComponent<AudioSource>();
		source4=Texto4.GetComponent<AudioSource>();
		source5=Texto5.GetComponent<AudioSource>();

		if (cam == null){
			cam = Camera.main;
		}

		Anterior.SetActive(false);
		Texto2.SetActive(false);
		Texto3.SetActive(false);
		Texto4.SetActive(false);
		Texto5.SetActive(false);
		O.SetActive(false);
		I.SetActive(false);
		U.SetActive(false);
		E.SetActive(false);
		Cow.SetActive(false);
	}
	
	public void Update(){

		if(!phone.GetComponent<Animation>().isPlaying){
			phone.GetComponent<Animation>().Play();
		}

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

							break;
							
					
						case "Anterior":
							if(i==1){
								Anterior.SetActive(false);
							}
							if(i==2){
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								Anterior.SetActive(false);
								Texto.SetActive(true);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								A.SetActive(true);
								O.SetActive(false);
								I.SetActive(false);
								U.SetActive(false);
								E.SetActive(false);
								Cow.SetActive(false);
								i=1;
							}

							if(i==3){
								source.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
							    Cow.SetActive(true);
								Anterior.SetActive(true);
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								A.SetActive(false);
								O.SetActive(true);
								I.SetActive(false);
								U.SetActive(false);
								E.SetActive(false);
								
								i=2;
							}

							if(i==4){
								source.Stop();
								source2.Stop();
								source4.Stop();
								source5.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								A.SetActive(false);
								O.SetActive(false);
								I.SetActive(true);
								U.SetActive(false);
								E.SetActive(false);
								
								i=3;
							}

							if(i==5){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								A.SetActive(false);
								O.SetActive(false);
								I.SetActive(false);
								U.SetActive(true);
								E.SetActive(false);
							    Next.SetActive(true);
								
								i=4;
							}

							break;
							
						case "Next":

							if(i==5){
								Next.SetActive(false);
							}

							if(i==4){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								Next.SetActive(false);
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(true);
								A.SetActive(false);
								O.SetActive(false);
								I.SetActive(false);
								U.SetActive(false);
								E.SetActive(true);
								
								i=5;
							}

							if(i==3){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								A.SetActive(false);
								O.SetActive(false);
								I.SetActive(false);
								U.SetActive(true);
								E.SetActive(false);
								
								i=4;
							}

							if(i==2){
								source.Stop();
								source2.Stop();
								source4.Stop();
								source5.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								A.SetActive(false);
								O.SetActive(false);
								I.SetActive(true);
								U.SetActive(false);
								E.SetActive(false);
							    Cow.SetActive(false);
								i=3;
							}

							if(i==1){
							    Anterior.SetActive(true);
								source.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								A.SetActive(false);
								O.SetActive(true);
								I.SetActive(false);
								U.SetActive(false);
								E.SetActive(false);
								Cow.SetActive(true);
								
								i=2;
							}

							break;
							
						case "Escuchar":
							Application.LoadLevel("Escuchar1");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo1");
							
							break;
							
						case "Ejercicios":
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
