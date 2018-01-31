using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameData{
	//Dantes
	public static int ELv = 0;
	public static int EcurXP = 0;
	public static int EnextXP = 100;
	public static int EHP = 2352;
	public static int EAtt = 255;
	public static int EXPneed = EnextXP - EcurXP;

	//Tomoe
	public static int TLv = 0;
	public static int TcurXP = 0;
	public static int TnextXP = 100;
	public static int THP = 1728;
	public static int TAtt = 165;
	public static int TXPneed = TnextXP - TcurXP;

	//Map
	public static string lv1 = "ok";
	public static string lv2 = "no";
	public static string lv3 = "no";
}

public class SaveLoad : MonoBehaviour {
	public static void Save(){
		BinaryFormatter binaryformatter = new BinaryFormatter ();
		using (FileStream fs = new FileStream ("gamesave.bin", FileMode.Create, FileAccess.Write)) {
			//Dantes
			binaryformatter.Serialize (fs, GameData.ELv);
			binaryformatter.Serialize (fs, GameData.EcurXP);
			binaryformatter.Serialize (fs, GameData.EnextXP);
			binaryformatter.Serialize (fs, GameData.EHP);
			binaryformatter.Serialize (fs, GameData.EAtt);

			//Tomoe
			binaryformatter.Serialize (fs, GameData.TLv);
			binaryformatter.Serialize (fs, GameData.TcurXP);
			binaryformatter.Serialize (fs, GameData.TnextXP);
			binaryformatter.Serialize (fs, GameData.THP);
			binaryformatter.Serialize (fs, GameData.TAtt);

			//Map
			binaryformatter.Serialize(fs,GameData.lv1);
			binaryformatter.Serialize(fs,GameData.lv2);
			binaryformatter.Serialize(fs,GameData.lv3);
		}
	}

	public static void Load (){
		if (!File.Exists ("gamesave.bin"))
			return;

		BinaryFormatter binaryformatter = new BinaryFormatter ();
		using (FileStream fs = new FileStream ("gamesave.bin", FileMode.Open, FileAccess.Read)) {
			//Dantes
			binaryformatter.Serialize (fs, GameData.ELv);
			binaryformatter.Serialize (fs, GameData.EcurXP);
			binaryformatter.Serialize (fs, GameData.EnextXP);
			binaryformatter.Serialize (fs, GameData.EHP);
			binaryformatter.Serialize (fs, GameData.EAtt);

			//Tomoe
			binaryformatter.Serialize (fs, GameData.TLv);
			binaryformatter.Serialize (fs, GameData.TcurXP);
			binaryformatter.Serialize (fs, GameData.TnextXP);
			binaryformatter.Serialize (fs, GameData.THP);
			binaryformatter.Serialize (fs, GameData.TAtt);

			//Map
			binaryformatter.Serialize(fs,GameData.lv1);
			binaryformatter.Serialize(fs,GameData.lv2);
			binaryformatter.Serialize(fs,GameData.lv3);
		}
	}

	void Update(){
		GameData.EXPneed = GameData.EnextXP - GameData.EcurXP;
		GameData.TXPneed = GameData.TnextXP - GameData.TcurXP;
	}
}
