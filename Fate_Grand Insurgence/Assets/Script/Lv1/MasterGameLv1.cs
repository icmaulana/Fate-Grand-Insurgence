using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGameLv1 : MonoBehaviour {

	public static int whichTurn = 1;
	public static float currentDamage = 0;

	public GameObject ava1;
	public GameObject ava2;
	public GameObject health1;
	public GameObject health2;
	public GameObject panelfinish;
	public GameObject panelgameover;
	public GameObject lvup1;
	public GameObject lvup2;

	public static int heal1 = 0;
	public static int heal2 = 0;
	public GameObject sk1;
	public GameObject sk2;

	public static string TStatus = "OK";
	public static string EStatus = "OK";
	public static string SStatus = "OK";
	public static string Elv = "no";
	public static string Tlv = "no";

	// Use this for initialization
	void Start () {
		heal1 = 0;
		heal2 = 0;
		sk1.SetActive (true);
		sk2.SetActive (true);

		ava1.SetActive (true);
		ava2.SetActive (false);
		health1.SetActive (true);
		health2.SetActive (true);
		panelfinish.SetActive(false);
		panelgameover.SetActive(false);
		lvup1.SetActive (false);
		lvup1.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (whichTurn == 1) {
			ava1.SetActive (true);
			ava2.SetActive (false);
		}
		if (whichTurn == 2) {
			ava1.SetActive (false);
			ava2.SetActive (true);
			StartCoroutine (delay_turn());
		} 

		if (EStatus == "dead") {
			health1.SetActive (false);
		}

		if (TStatus == "dead") {
			health2.SetActive (false);
			ava2.SetActive (false);
		}

		if (SStatus == "dead") {
			panelfinish.SetActive (true);
		}

		if ((TStatus == "dead") && (EStatus == "dead")) {
			panelgameover.SetActive (true);
		}

		if (Elv == "lvup") {
			lvup1.SetActive (true);
		}

		if (Elv == "no") {
			lvup1.SetActive (false);
		}

		if (Tlv == "lvup") {
			lvup2.SetActive (true);
		}

		if (Tlv == "no") {
			lvup2.SetActive (false);
		}

		if (heal1 > 0) {
			sk1.SetActive (false);
		}

		if (heal2 > 0) {
			sk2.SetActive (false);
		}

		if (heal1 < 0) {
			heal1 = 0;
		}
		if (heal2 < 0) {
			heal2 = 0;
		}
	}

	IEnumerator delay_turn(){
		yield return new WaitForSeconds (2.03F);
		if (whichTurn == 3) {
			ava1.SetActive (false);
			ava2.SetActive (false);
		}
	}

	public void withdraw(string sceneName){
		Elv = "no";
		Tlv = "no";
		Application.LoadLevel (sceneName);
	}

	public void nextpanelUI(string sceneName){
		SaveLoad.Save ();
		Elv = "no";
		Tlv = "no";
		GameData.lv2 = "ok";
		MapMaster.lv2stat = "ok";
		Application.LoadLevel (sceneName);
	}
}
