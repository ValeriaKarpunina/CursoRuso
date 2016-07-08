using UnityEngine;
using System.Collections;

public class Ranking : MonoBehaviour {
	private GameObject leccion, nombre1,nombre2,nombre3,nombre4,intentos1,intentos2,
	intentos3,intentos4,tiempo1,tiempo2,tiempo3,tiempo4,L1,L2,L3,L4,L5,L6,L7,L8,L9,L10,L11,L12,L13,L14,L15,L16,L17,
	L18,Nombre,Tiempo,Intentos,Exit,pos1,pos2,pos3,pos4,Lecciones,Leccion;

	private Touch tocar;
	private Camera cam;
	private RaycastHit hit;
	private Ray ray;

	void Start () {
		Leccion=GameObject.Find("Leccion");
		Lecciones=GameObject.Find("Lecciones");
		Exit=GameObject.Find("Exit");
		Nombre=GameObject.Find("Nombre");
		Tiempo=GameObject.Find("Tiempo");
		Intentos=GameObject.Find("Intentos");
		leccion=GameObject.Find("Lec");
		nombre1=GameObject.Find("Nombre1");
		nombre2=GameObject.Find("Nombre2");
		nombre3=GameObject.Find("Nombre3");
		nombre4=GameObject.Find("Nombre4");
		intentos1=GameObject.Find("Intentos1");
		intentos2=GameObject.Find("Intentos2");
		intentos3=GameObject.Find("Intentos3");
		intentos4=GameObject.Find("Intentos4");
		tiempo1=GameObject.Find("Tiempo1");
		tiempo2=GameObject.Find("Tiempo2");
		tiempo3=GameObject.Find("Tiempo3");
		tiempo4=GameObject.Find("Tiempo4");
		pos1=GameObject.Find("pos1");
		pos2=GameObject.Find("pos2");
		pos3=GameObject.Find("pos3");
		pos4=GameObject.Find("pos4");
		L1=GameObject.Find("L1");
		L2=GameObject.Find("L2");
		L3=GameObject.Find("L3");
		L4=GameObject.Find("L4");
		L5=GameObject.Find("L5");
		L6=GameObject.Find("L6");
		L7=GameObject.Find("L7");
		L8=GameObject.Find("L8");
		L9=GameObject.Find("L9");
		L10=GameObject.Find("L10");
		L11=GameObject.Find("L11");
		L12=GameObject.Find("L12");
		L13=GameObject.Find("L13");
		L14=GameObject.Find("L14");
		L15=GameObject.Find("L15");
		L16=GameObject.Find("L16");
		L17=GameObject.Find("L17");
		L18=GameObject.Find("L18");
		Nombre.SetActive(false);
		Tiempo.SetActive(false);
		Intentos.SetActive(false);
		nombre1.SetActive(false);
		nombre2.SetActive(false);
		nombre3.SetActive(false);
		nombre4.SetActive(false);
		intentos1.SetActive(false);
		intentos2.SetActive(false);
		intentos3.SetActive(false);
		intentos4.SetActive(false);
		tiempo1.SetActive(false);
		tiempo2.SetActive(false);
		tiempo3.SetActive(false);
		tiempo4.SetActive(false);
		pos1.SetActive(false);
		pos2.SetActive(false);
		pos3.SetActive(false);
		pos4.SetActive(false);
		configurarL();

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
						
					case "Exit":
						Application.Quit();
						
						break;

					case "Lecciones":
						Application.LoadLevel("Lecciones");
						
						break;

					case "L1":
						config();
						ClienteTCP2 cliente1=new ClienteTCP2(1);
						PonerDatos(1,cliente1.GetName1(),cliente1.GetName2(),cliente1.GetName3(),cliente1.GetName4(),cliente1.GetInt());
						break;

					case "L2":
						config();
						ClienteTCP2 cliente2=new ClienteTCP2(2);
						PonerDatos(2,cliente2.GetName1(),cliente2.GetName2(),cliente2.GetName3(),cliente2.GetName4(),cliente2.GetInt());
						break;

					case "L3":
						config();
						ClienteTCP2 cliente3=new ClienteTCP2(3);
						PonerDatos(3,cliente3.GetName1(),cliente3.GetName2(),cliente3.GetName3(),cliente3.GetName4(),cliente3.GetInt());
						break;

					case "L4":
						config();
						ClienteTCP2 cliente4=new ClienteTCP2(4);
						PonerDatos(4,cliente4.GetName1(),cliente4.GetName2(),cliente4.GetName3(),cliente4.GetName4(),cliente4.GetInt());
						break;

					case "L5":
						config();
						ClienteTCP2 cliente5=new ClienteTCP2(5);
						PonerDatos(5,cliente5.GetName1(),cliente5.GetName2(),cliente5.GetName3(),cliente5.GetName4(),cliente5.GetInt());
						break;

					case "L6":
						config();
						ClienteTCP2 cliente6=new ClienteTCP2(6);
						PonerDatos(6,cliente6.GetName1(),cliente6.GetName2(),cliente6.GetName3(),cliente6.GetName4(),cliente6.GetInt());
						break;

					case "L7":
						config();
						ClienteTCP2 cliente7=new ClienteTCP2(7);
						PonerDatos(7,cliente7.GetName1(),cliente7.GetName2(),cliente7.GetName3(),cliente7.GetName4(),cliente7.GetInt());
						break;

					case "L8":
						config();
						ClienteTCP2 cliente8=new ClienteTCP2(8);
						PonerDatos(8,cliente8.GetName1(),cliente8.GetName2(),cliente8.GetName3(),cliente8.GetName4(),cliente8.GetInt());
						break;

					case "L9":
						config();
						ClienteTCP2 cliente9=new ClienteTCP2(9);
						PonerDatos(9,cliente9.GetName1(),cliente9.GetName2(),cliente9.GetName3(),cliente9.GetName4(),cliente9.GetInt());
						break;

					case "L10":
						config();
						ClienteTCP2 cliente10=new ClienteTCP2(10);
						PonerDatos(10,cliente10.GetName1(),cliente10.GetName2(),cliente10.GetName3(),cliente10.GetName4(),cliente10.GetInt());
						break;

					case "L11":
						config();
						ClienteTCP2 cliente11=new ClienteTCP2(11);
						PonerDatos(11,cliente11.GetName1(),cliente11.GetName2(),cliente11.GetName3(),cliente11.GetName4(),cliente11.GetInt());
						break;

					case "L12":
						config();
						ClienteTCP2 cliente12=new ClienteTCP2(12);
						PonerDatos(12,cliente12.GetName1(),cliente12.GetName2(),cliente12.GetName3(),cliente12.GetName4(),cliente12.GetInt());
						break;

					case "L13":
						config();
						ClienteTCP2 cliente13=new ClienteTCP2(13);
						PonerDatos(13,cliente13.GetName1(),cliente13.GetName2(),cliente13.GetName3(),cliente13.GetName4(),cliente13.GetInt());
						break;

					case "L14":
						config();
						ClienteTCP2 cliente14=new ClienteTCP2(14);
						PonerDatos(14,cliente14.GetName1(),cliente14.GetName2(),cliente14.GetName3(),cliente14.GetName4(),cliente14.GetInt());
						break;

					case "L15":
						config();
						ClienteTCP2 cliente15=new ClienteTCP2(15);
						PonerDatos(15,cliente15.GetName1(),cliente15.GetName2(),cliente15.GetName3(),cliente15.GetName4(),cliente15.GetInt());
						break;

					case "L16":
						config();
						ClienteTCP2 cliente16=new ClienteTCP2(16);
						PonerDatos(16,cliente16.GetName1(),cliente16.GetName2(),cliente16.GetName3(),cliente16.GetName4(),cliente16.GetInt());
						break;

					case "L17":
						config();
						ClienteTCP2 cliente17=new ClienteTCP2(17);
						PonerDatos(17,cliente17.GetName1(),cliente17.GetName2(),cliente17.GetName3(),cliente17.GetName4(),cliente17.GetInt());
						break;

					case "L18":
						config();
						ClienteTCP2 cliente18=new ClienteTCP2(18);
						PonerDatos(18,cliente18.GetName1(),cliente18.GetName2(),cliente18.GetName3(),cliente18.GetName4(),cliente18.GetInt());
						break;
					}
				}
			}
				
		}
	}
	
	private void PonerDatos(int lec,string n1,string n2,string n3, string n4,int[] datos){//int inten1,int inten2,int inten3,int inten4,int t1,int t2,int t3, int t4){
		leccion.GetComponent<TextMesh>().text=lec.ToString();

		if(n1.Length>8){
			n1=n1.Substring(0,8);
			nombre1.GetComponent<TextMesh>().text=string.Concat(n1,"...");
		}else{
			nombre1.GetComponent<TextMesh>().text=n1;
		}

		if(n2.Length>8){
			n2=n2.Substring(0,8);
			nombre2.GetComponent<TextMesh>().text=string.Concat(n2,"...");
			Debug.Log("nombre2 concat"+string.Concat(n2,"..."));
		}else{
			nombre2.GetComponent<TextMesh>().text=n2;
		}

		if(n3.Length>8){
			n3=n3.Substring(0,8);
			nombre3.GetComponent<TextMesh>().text=string.Concat(n3,"...");
		}else{
			nombre3.GetComponent<TextMesh>().text=n3;
		}

		if(n4.Length>8){
			n4=n4.Substring(0,8);
			nombre4.GetComponent<TextMesh>().text=string.Concat(n4,"...");
		}else{
			nombre4.GetComponent<TextMesh>().text=n4;
		}

		if(n1.Equals("-")){
			intentos1.GetComponent<TextMesh>().text="-";
			tiempo1.GetComponent<TextMesh>().text="-";
			pos1.GetComponent<TextMesh>().text="-";
		}else{
			intentos1.GetComponent<TextMesh>().text=datos[1].ToString();
			tiempo1.GetComponent<TextMesh>().text=datos[2].ToString();
			pos1.GetComponent<TextMesh>().text=1.ToString();
		}

		if(n2.Equals("-")){
			intentos2.GetComponent<TextMesh>().text="-";
			tiempo2.GetComponent<TextMesh>().text="-";
			pos2.GetComponent<TextMesh>().text="-";
		}else{
			intentos2.GetComponent<TextMesh>().text=datos[4].ToString();
			tiempo2.GetComponent<TextMesh>().text=datos[5].ToString();
			pos2.GetComponent<TextMesh>().text=2.ToString();
		}

		if(n3.Equals("-")){
			intentos3.GetComponent<TextMesh>().text="-";
			tiempo3.GetComponent<TextMesh>().text="-";
			pos3.GetComponent<TextMesh>().text="-";
		}else{
			intentos3.GetComponent<TextMesh>().text=datos[7].ToString();
			tiempo3.GetComponent<TextMesh>().text=datos[8].ToString();
			pos3.GetComponent<TextMesh>().text=3.ToString();
		}

		if(n4.Equals("-")){
			intentos4.GetComponent<TextMesh>().text="-";
			tiempo4.GetComponent<TextMesh>().text="-";
			pos4.GetComponent<TextMesh>().text="-";
		}else{
			intentos4.GetComponent<TextMesh>().text=datos[11].ToString();
			tiempo4.GetComponent<TextMesh>().text=datos[12].ToString();
			pos4.GetComponent<TextMesh>().text=datos[9].ToString();
		}
	}
	
	private void configurarL(){
		SaveLoad load = new SaveLoad();
		int[] valores=new int[3];
		valores=load.Load();
		int puntos=valores[0];
		
		if(puntos>=20 && puntos<40){
			L1.SetActive(true);
			L2.SetActive(false);
			L3.SetActive(false);
			L4.SetActive(false);
			L5.SetActive(false);
			L6.SetActive(false);
			L7.SetActive(false);
			L8.SetActive(false);
			L9.SetActive(false);
			L10.SetActive(false);
			L11.SetActive(false);
			L12.SetActive(false);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		
		if(puntos>=40 && puntos<65){
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(false);
			L4.SetActive(false);
			L5.SetActive(false);
			L6.SetActive(false);
			L7.SetActive(false);
			L8.SetActive(false);
			L9.SetActive(false);
			L10.SetActive(false);
			L11.SetActive(false);
			L12.SetActive(false);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		
		if(puntos>=65 && puntos<100){
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(false);
			L5.SetActive(false);
			L6.SetActive(false);
			L7.SetActive(false);
			L8.SetActive(false);
			L9.SetActive(false);
			L10.SetActive(false);
			L11.SetActive(false);
			L12.SetActive(false);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		
		if(puntos>=100 && puntos<125){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(false);
			L6.SetActive(false);
			L7.SetActive(false);
			L8.SetActive(false);
			L9.SetActive(false);
			L10.SetActive(false);
			L11.SetActive(false);
			L12.SetActive(false);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		
		if(puntos>=125 && puntos<150){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(false);
			L7.SetActive(false);
			L8.SetActive(false);
			L9.SetActive(false);
			L10.SetActive(false);
			L11.SetActive(false);
			L12.SetActive(false);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		
		if(puntos>=150 && puntos<175){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(false);
			L8.SetActive(false);
			L9.SetActive(false);
			L10.SetActive(false);
			L11.SetActive(false);
			L12.SetActive(false);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		
		if(puntos>=175 && puntos<195){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(false);
			L9.SetActive(false);
			L10.SetActive(false);
			L11.SetActive(false);
			L12.SetActive(false);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		
		if(puntos>=195 && puntos<230){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(true);
			L9.SetActive(false);
			L10.SetActive(false);
			L11.SetActive(false);
			L12.SetActive(false);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		
		if(puntos>=230 && puntos<245){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(true);
			L9.SetActive(true);
			L10.SetActive(false);
			L11.SetActive(false);
			L12.SetActive(false);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		if(puntos>=245 && puntos<280){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(true);
			L9.SetActive(true);
			L10.SetActive(true);
			L11.SetActive(false);
			L12.SetActive(false);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		
		if(puntos>=280 && puntos<310){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(true);
			L9.SetActive(true);
			L10.SetActive(true);
			L11.SetActive(true);
			L12.SetActive(false);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		
		if(puntos>=310 && puntos<345){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(true);
			L9.SetActive(true);
			L10.SetActive(true);
			L11.SetActive(true);
			L12.SetActive(true);
			L13.SetActive(false);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		
		if(puntos>=345 && puntos<365){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(true);
			L9.SetActive(true);
			L10.SetActive(true);
			L11.SetActive(true);
			L12.SetActive(true);
			L13.SetActive(true);
			L14.SetActive(false);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		if(puntos>=365 && puntos<375){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(true);
			L9.SetActive(true);
			L10.SetActive(true);
			L11.SetActive(true);
			L12.SetActive(true);
			L13.SetActive(true);
			L14.SetActive(true);
			L15.SetActive(false);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		if(puntos>=375 && puntos<400){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(true);
			L9.SetActive(true);
			L10.SetActive(true);
			L11.SetActive(true);
			L12.SetActive(true);
			L13.SetActive(true);
			L14.SetActive(true);
			L15.SetActive(true);
			L16.SetActive(false);
			L17.SetActive(false);
			L18.SetActive(false);
			
		}
		if(puntos>=400 && puntos<415){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(true);
			L9.SetActive(true);
			L10.SetActive(true);
			L11.SetActive(true);
			L12.SetActive(true);
			L13.SetActive(true);
			L14.SetActive(true);
			L15.SetActive(true);
			L16.SetActive(true);
			L17.SetActive(false);
			L18.SetActive(false);
		}
		if(puntos>=415 && puntos<420){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(true);
			L9.SetActive(true);
			L10.SetActive(true);
			L11.SetActive(true);
			L12.SetActive(true);
			L13.SetActive(true);
			L14.SetActive(true);
			L15.SetActive(true);
			L16.SetActive(true);
			L17.SetActive(true);
			L18.SetActive(false);
		}
		if(puntos>=420){
			
			L1.SetActive(true);
			L2.SetActive(true);
			L3.SetActive(true);
			L4.SetActive(true);
			L5.SetActive(true);
			L6.SetActive(true);
			L7.SetActive(true);
			L8.SetActive(true);
			L9.SetActive(true);
			L10.SetActive(true);
			L11.SetActive(true);
			L12.SetActive(true);
			L13.SetActive(true);
			L14.SetActive(true);
			L15.SetActive(true);
			L16.SetActive(true);
			L17.SetActive(true);
			L18.SetActive(true);
		}
	}

	private void config(){
		Leccion.SetActive(false);
		L1.SetActive(false);
		L2.SetActive(false);
		L3.SetActive(false);
		L4.SetActive(false);
		L5.SetActive(false);
		L6.SetActive(false);
		L7.SetActive(false);
		L8.SetActive(false);
		L9.SetActive(false);
		L10.SetActive(false);
		L11.SetActive(false);
		L12.SetActive(false);
		L13.SetActive(false);
		L14.SetActive(false);
		L15.SetActive(false);
		L16.SetActive(false);
		L17.SetActive(false);
		L18.SetActive(false);
		Nombre.SetActive(true);
		Tiempo.SetActive(true);
		Intentos.SetActive(true);
		nombre1.SetActive(true);
		nombre2.SetActive(true);
		nombre3.SetActive(true);
		nombre4.SetActive(true);
		intentos1.SetActive(true);
		intentos2.SetActive(true);
		intentos3.SetActive(true);
		intentos4.SetActive(true);
		tiempo1.SetActive(true);
		tiempo2.SetActive(true);
		tiempo3.SetActive(true);
		tiempo4.SetActive(true);
		pos1.SetActive(true);
		pos2.SetActive(true);
		pos3.SetActive(true);
		pos4.SetActive(true);
	}
}
