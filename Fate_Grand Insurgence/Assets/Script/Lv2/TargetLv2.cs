using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLv2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Transform> ().position = new Vector3 (17.494f, 58.860f, 62.4f);
	}
	
	// Update is called once per frame
	void Update () {
		if (MasterGameLv2.target == true) {
			GetComponent<Transform> ().position = new Vector3 (17.494f, 58.860f, 62.4f);
		}
		if (MasterGameLv2.target == false) {
			GetComponent<Transform> ().position = new Vector3 (77.2f, 58.860f, 62.4f);
		}
	}

	public void move1(){
		GetComponent<Transform> ().position = new Vector3 (17.494f, 58.860f, 62.4f);
		MasterGameLv2.target = true;
	}

	public void move2(){
		GetComponent<Transform> ().position = new Vector3 (77.2f, 58.860f, 62.4f);
		MasterGameLv2.target = false;
	}
}
