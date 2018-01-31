using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaster : MonoBehaviour {

	public GameObject lv1;
	public GameObject lv2;
	public GameObject lv3;

	public static string lv1stat = "ok";
	public static string lv2stat = GameData.lv2;
	public static string lv3stat = GameData.lv3;

	// Use this for initialization
	void Start () {
		lv1.SetActive (true);
		lv2.SetActive (false);
		lv3.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (lv2stat == "ok") {
			lv2.SetActive (true);
		}

		if (lv3stat == "ok") {
			lv3.SetActive (true);
		}
	}

	public void ChangeScene(string sceneName){
		Application.LoadLevel (sceneName);
	}
}
