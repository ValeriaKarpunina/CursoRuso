using UnityEngine;
using System.Collections;

public class Escuchar11 : MonoBehaviour
{
	GameObject Texto1, Texto2, Texto3,Texto4,Texto5,Texto6,Texto7,Texto8,Texto9,Texto10,Texto11,
	Play, Next,Anterior,Escuchar, Dialogo, Ejercicios, Exit,Lecciones,Teoria,flex;
	AudioSource source1,source2,source3,source4,source5,source6,source7,source8,source9,source10,source11;
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
		Teoria=GameObject.Find("Teoria");

		Anterior=GameObject.Find ("Anterior");
		Dialogo=GameObject.Find("Dialogo");
		Escuchar=GameObject.Find("Escuchar");
		Ejercicios=GameObject.Find("Ejercicios");
		Exit=GameObject.Find("Exit");
		Lecciones=GameObject.Find("Lecciones");
		flex=GameObject.Find("flex");

		Texto1=GameObject.Find("Texto1");
		Texto2=GameObject.Find("Texto2");
		Texto3=GameObject.Find("Texto3");
		Texto4=GameObject.Find("Texto4");
		Texto5=GameObject.Find("Texto5");
		Texto6=GameObject.Find("Texto6");
		Texto7=GameObject.Find("Texto7");
		Texto8=GameObject.Find("Texto8");
		Texto9=GameObject.Find("Texto9");
		Texto10=GameObject.Find("Texto10");
		Texto11=GameObject.Find("Texto11");
		
		source1=Texto1.GetComponent<AudioSource>();
		source2=Texto2.GetComponent<AudioSource>();
		source3=Texto3.GetComponent<AudioSource>();
		source4=Texto4.GetComponent<AudioSource>();
		source5=Texto5.GetComponent<AudioSource>();
		source6=Texto6.GetComponent<AudioSource>();
		source7=Texto7.GetComponent<AudioSource>();
		source8=Texto8.GetComponent<AudioSource>();
		source9=Texto9.GetComponent<AudioSource>();
		source10=Texto10.GetComponent<AudioSource>();
		source11=Texto11.GetComponent<AudioSource>();
		
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
		Texto8.SetActive(false);
		Texto9.SetActive(false);
		Texto10.SetActive(false);
		Texto11.SetActive(false);
	
	}
	
	
	void Update(){
	
		if(!flex.GetComponent<Animation>().isPlaying){
			flex.GetComponent<Animation>().Play();
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
					case "Teoria":
						Application.OpenURL("https://github.com/ValeriaKarpunina/CursoRuso/blob/Lecciones/CursoRuso/Lecci%C3%B3n%2011.pdf");
						break;

					case "Play":
						
						if(i==1 && !source1.isPlaying){
							source1.Play();
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
						if(i==8 && !source8.isPlaying){
							source8.Play();	
						}
						if(i==9 && !source9.isPlaying){
							source9.Play();	
						}
						if(i==10 && !source10.isPlaying){
							source10.Play();	
						}
						if(i==11 && !source11.isPlaying){
							source11.Play();	
						}
						break;
						
						
					case "Anterior":
						if(i==1){
							Anterior.SetActive(false);
							Next.SetActive(true);
							Texto1.SetActive(true);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
						}
						
						if(i==2){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							
							Texto1.SetActive(true);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							i=1;
						}
						
						if(i==3){
							
							source1.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							
							Anterior.SetActive(true);
							Texto1.SetActive(false);
							Texto2.SetActive(true);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							i=2;
						}
						
						if(i==4){
							source1.Stop();
							source2.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(true);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							i=3;
						}
						
						if(i==5){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(true);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							i=4;
						}
						if(i==6){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(true);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							i=5;
						}
						if(i==7){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(true);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							i=6;
						}
						if(i==8){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(true);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							i=7;
						}
						if(i==9){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(true);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							i=8;
						}
						
						if(i==10){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(true);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							i=9;
						}
						if(i==11){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(true);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							i=10;
						}
						break;
						
					case "Next":
						if(i==11){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(true);
							Next.SetActive(false);
							
						}
						if(i==10){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(true);
							Next.SetActive(false);
							i=11;
						}
						if(i==9){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(true);
							Texto11.SetActive(false);
							Next.SetActive(true);
							
							i=10;
						}
						if(i==8){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(true);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							Next.SetActive(true);
							
							i=9;
						}
						if(i==7){
							
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(true);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							
							i=8;
						}
						if(i==6){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(true);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							
							i=7;
						}
						if(i==5){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(true);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							
							i=6;
						}
						if(i==4){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(true);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							
							i=5;
						}
						
						if(i==3){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(false);
							Texto4.SetActive(true);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							
							i=4;
						}
						
						if(i==2){
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							Texto1.SetActive(false);
							Texto2.SetActive(false);
							Texto3.SetActive(true);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							
							i=3;
						}
						
						if(i==1){
							Anterior.SetActive(true);
							source1.Stop();
							source2.Stop();
							source3.Stop();
							source4.Stop();
							source5.Stop();
							source6.Stop();
							source7.Stop();
							source8.Stop();
							source9.Stop();
							source10.Stop();
							source11.Stop();
							Texto1.SetActive(false);
							Texto2.SetActive(true);
							Texto3.SetActive(false);
							Texto4.SetActive(false);
							Texto5.SetActive(false);
							Texto6.SetActive(false);
							Texto7.SetActive(false);
							Texto8.SetActive(false);
							Texto9.SetActive(false);
							Texto10.SetActive(false);
							Texto11.SetActive(false);
							
							Next.SetActive(true);
							
							i=2;
						}
						
						break;
							
						case "Vocabulario":
							Application.LoadLevel("Vocabulario11");
							
							break;
							
						case "Dialogo":
							Application.LoadLevel("Dialogo11");
							
							break;
							
						case "Ejercicios":
							Application.LoadLevel("Ejercicios11");
							
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
