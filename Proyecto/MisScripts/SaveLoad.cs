using UnityEngine;
using System.Collections;
using System; // para poner [Serializable]
using System.Runtime.Serialization.Formatters.Binary; //para save and load
using System.IO;

public class SaveLoad {
	private int puntuacion,intentos,tiempo,FinalTime,leccion;
	private int i=0;
	

	
	public SaveLoad(){}

	public SaveLoad(int pts,int intentos,int time){
		puntuacion=pts;
		this.intentos=intentos;
		tiempo=time;
		FinalTime=0;
		leccion=0;
	}
	public SaveLoad(int pts,int intentos,int time,int leccion, int tiempoFinal){ //Para Ranking
		puntuacion=pts;
		this.intentos=intentos;
		tiempo=time;
		this.leccion=leccion;
		FinalTime=tiempoFinal;
		i=1;
	}
	
	public void Save(){
		
		BinaryFormatter binary = new BinaryFormatter();
		FileStream fstream = File.Create(Application.persistentDataPath+"/saveFile.dat");
		SaveManager saver = new SaveManager();
		
		saver.pntuacion=puntuacion;
		saver.intentos=intentos;
		saver.watch=tiempo;
		saver.lec=leccion;
		//saver.Nombre=name;
		saver.TimeEnd=FinalTime;
		binary.Serialize(fstream,saver);
		fstream.Close();

		if(i==1){//Guardar en el servidor

			ClienteTCP2 cliente=new ClienteTCP2();
			cliente.PonerDatos(puntuacion,intentos,tiempo,leccion,FinalTime);//PonerDatos(int puntos,int intento, int time,int lesson, int timeF)
			cliente.Mandar();
		}
		
	}

	public int[] Load(){
		int[] resultado=new int[3];
		if(File.Exists(Application.persistentDataPath+"/saveFile.dat")){
			BinaryFormatter binary = new BinaryFormatter();
			FileStream fstream = File.Open(Application.persistentDataPath+"/saveFile.dat", FileMode.Open);
			SaveManager saver = (SaveManager) binary.Deserialize(fstream);
			fstream.Close();
			
			resultado[0]=saver.pntuacion;
			resultado[1]=saver.intentos;
			resultado[2]=saver.watch;

		}else{

			ClienteTCP2 cliente=new ClienteTCP2(0);
			SaveLoad guardar=new SaveLoad(cliente.MisDatos()[0],cliente.MisDatos()[1],cliente.MisDatos()[2]);
			guardar.Save();
			resultado[0]=0;
			resultado[1]=0;
			resultado[2]=0;
		}
		
		return resultado;
	}
}

[Serializable]

class SaveManager
{
	public int lec;
	public int TimeEnd;
	public int pntuacion;
	public int intentos;
	public int watch;
}
