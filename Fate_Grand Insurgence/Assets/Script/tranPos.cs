using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tranPos : MonoBehaviour {

	public E_con con;
	public Camera cam1;
	public Camera cam2;

	// Use this for initialization
	void Start () {
		cam1.enabled = true;
		cam2.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown("2") && (battleflow.whichTurn == 1)) {
			GetComponent<Transform> ().position = new Vector3 (13.34f,6.86f, -14.41f);
			cam1.enabled = false;
			cam2.enabled = true;
			StartCoroutine (returnpos ());
		}*/

		if (Input.GetKeyDown ("space")) {
			cam1.enabled = false;
			cam2.enabled = true;
			StartCoroutine (returncam ());
		}

		if (E_con.EcurHP == 0) {
			E_con.anim.Play ("Dantes_ko");
			battleflow.EStatus = "dead";
			StartCoroutine (dead ());
		}
	}

	IEnumerator returnpos(){
		yield return new WaitForSeconds (1.535F);
		GetComponent<Transform> ().position = new Vector3 (0f,6.86f, -14.41f);
		cam1.enabled = true;
		cam2.enabled = false;
		endturn ();
	}

	IEnumerator returncam(){
		yield return new WaitForSeconds (2.3F);
		cam1.enabled = true;
		cam2.enabled = false;
	}

	IEnumerator dead(){
		yield return new WaitForSeconds (2.3F);
		Destroy(this.gameObject);
	}

	void endturn(){
		if (battleflow.TStatus == "dead") {
			battleflow.whichTurn = 3;
		} else {
			battleflow.whichTurn = 2;
		}
	}

	public void movepos(){
		GetComponent<Transform> ().position = new Vector3 (13.34f,6.86f, -14.41f);
		StartCoroutine (returnpos ());
	}
}
