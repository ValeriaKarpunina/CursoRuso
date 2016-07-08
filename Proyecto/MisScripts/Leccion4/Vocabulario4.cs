using UnityEngine;
using System.Collections;

public class Vocabulario4 : MonoBehaviour
{
	GameObject Texto, Texto2, Texto3,Texto4,Texto5,Texto6,Texto7,Texto8,Texto9,B,P,V,F,D,T,
	Play, Next,Anterior,Escuchar, Dialogo, Ejercicios, Exit,Lecciones, house, diente,dedmodel,PlayGlobal,Vpered,Nazad,PausaGlobal;
	AudioSource source,source2,source3,source4,source5,source6,source7,source8,source9;
	Touch tocar;
	Camera cam;
	RaycastHit hit;
	Ray ray;
	int i,j;//identifica cada uno de los textos
	bool next,anterior;
	float Pitch;
	
	void Start () {
	
		next=false;
		anterior=false;

		i=1; 
		j=0;
		Play=GameObject.Find("Play");
		Next=GameObject.Find("Next");
		//Pause=GameObject.Find("Pause");
		B=GameObject.Find("B");
		P=GameObject.Find("P");
		V=GameObject.Find("V");
		F=GameObject.Find("F");
		D=GameObject.Find("D");
		T=GameObject.Find("T");

		//Repeat=GameObject.Find("Repeat");
		Anterior=GameObject.Find ("Anterior");
		//Vocabulario=GameObject.Find("Vocabulario");
		Dialogo=GameObject.Find("Dialogo");
		Escuchar=GameObject.Find("Escuchar");
		Ejercicios=GameObject.Find("Ejercicios");
		Exit=GameObject.Find("Exit");
		Lecciones=GameObject.Find("Lecciones");

		Vpered=GameObject.Find("Vpered");
		Nazad=GameObject.Find("Nazad");
		PausaGlobal=GameObject.Find("PausaGlobal");
		PlayGlobal=GameObject.Find("PlayGlobal");

		Texto=GameObject.Find("Texto");
		Texto2=GameObject.Find("Texto2");
		Texto3=GameObject.Find("Texto3");
		Texto4=GameObject.Find("Texto4");
		Texto5=GameObject.Find("Texto5");
		Texto6=GameObject.Find("Texto6");
		Texto7=GameObject.Find("Texto7");
		Texto8=GameObject.Find("Texto8");
		Texto9=GameObject.Find("Texto9");

		house=GameObject.Find("house");
		diente=GameObject.Find("diente");
		dedmodel=GameObject.Find("dedmodel");

		source=Texto.GetComponent<AudioSource>();
		source2=Texto2.GetComponent<AudioSource>();
		source3=Texto3.GetComponent<AudioSource>();
		source4=Texto4.GetComponent<AudioSource>();
		source5=Texto5.GetComponent<AudioSource>();
		source6=Texto6.GetComponent<AudioSource>();
		source7=Texto7.GetComponent<AudioSource>();
		source8=Texto8.GetComponent<AudioSource>();
		source9=Texto9.GetComponent<AudioSource>();

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

		B.SetActive(true);
		P.SetActive(false);
		V.SetActive(false);
		F.SetActive(false);
		D.SetActive(false);
		T.SetActive(false);
		house.SetActive(false);
		diente.SetActive(false);
		dedmodel.SetActive(false);
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
							break;
							
					
						case "Anterior":
							if(i==1){
								Anterior.SetActive(false);
								Next.SetActive(true);
								Texto.SetActive(true);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);

								B.SetActive(true);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(false);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
							}
							if(i==2){
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();

								Texto.SetActive(true);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);

								B.SetActive(true);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(false);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								i=1;
							}

							if(i==3){
								
								source.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();

								Anterior.SetActive(true);
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(true);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(false);
								house.SetActive(false);
								diente.SetActive(true);
								dedmodel.SetActive(false);
								Next.SetActive(true);
								i=2;
							}

							if(i==4){
								source.Stop();
								source2.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(true);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(false);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								Next.SetActive(true);
								i=3;
							}

							if(i==5){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(true);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(false);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								Next.SetActive(true);
								i=4;
							}
							if(i==6){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(true);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(true);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(false);

								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								Next.SetActive(true);
								i=5;
							}
							if(i==7){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(true);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(true);
								D.SetActive(false);
								T.SetActive(false);

								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								Next.SetActive(true);
								i=6;
							}
							if(i==8){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(true);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(true);
								T.SetActive(false);

								house.SetActive(true);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								Next.SetActive(true);
								i=7;
							}
							if(i==9){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(true);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(true);
								T.SetActive(false);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(true);
								Next.SetActive(true);
								i=8;
							}
							break;
							
						case "Next":

							if(i==9){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(true);

								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(true);
								Next.SetActive(false);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
							}
							if(i==8){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(true);
								
								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(true);
								Next.SetActive(false);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								i=9;
							}
							if(i==7){
									
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(true);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(true);
								T.SetActive(false);
								Next.SetActive(true);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(true);
								i=8;
							}
							if(i==6){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(true);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(true);
								T.SetActive(false);
								Next.SetActive(true);
								house.SetActive(true);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								i=7;
							}
							if(i==5){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(true);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(true);
								D.SetActive(false);
								T.SetActive(false);
								Next.SetActive(true);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								i=6;
							}
							if(i==4){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(true);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(true);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(false);
								Next.SetActive(true);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								i=5;
							}

							if(i==3){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(false);
								Texto4.SetActive(true);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(false);
								V.SetActive(true);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(false);
								Next.SetActive(true);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								i=4;
							}

							if(i==2){
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(false);
								Texto3.SetActive(true);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(false);
								P.SetActive(true);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(false);
								Next.SetActive(true);
								house.SetActive(false);
								diente.SetActive(false);
								dedmodel.SetActive(false);
								i=3;
							}

							if(i==1){
							    Anterior.SetActive(true);
								source.Stop();
								source2.Stop();
								source3.Stop();
								source4.Stop();
								source5.Stop();
								source6.Stop();
								source7.Stop();
								source8.Stop();
								source9.Stop();
								Texto.SetActive(false);
								Texto2.SetActive(true);
								Texto3.SetActive(false);
								Texto4.SetActive(false);
								Texto5.SetActive(false);
								Texto6.SetActive(false);
								Texto7.SetActive(false);
								Texto8.SetActive(false);
								Texto9.SetActive(false);
								
								B.SetActive(true);
								P.SetActive(false);
								V.SetActive(false);
								F.SetActive(false);
								D.SetActive(false);
								T.SetActive(false);
								Next.SetActive(true);
								house.SetActive(false);
								diente.SetActive(true);
								dedmodel.SetActive(false);
								i=2;
							}

							break;
							
						case "Escuchar":
							Application.LoadLevel("Escuchar4");
							
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
