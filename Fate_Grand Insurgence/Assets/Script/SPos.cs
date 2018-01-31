using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPos : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;

	// Use this for initialization
	void Start () {
		cam1.enabled = true;
		cam2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*if ((Input.GetKeyDown ("2")) && (battleflow.whichTurn == 2)) {
			//GetComponent<Transform> ().position = new Vector3 (22.52f, 6.86f, -14.41f);
			cam1.enabled = false;
			cam2.enabled = true;
			StartCoroutine (ret ());
		}*/

		if (S_con.SCurHP == 0) {
			S_con.anim.Play ("S_KO");
			StartCoroutine (dead ());
		}
	}

	IEnumerator ret(){
		yield return new WaitForSeconds (1.535F);
		endturn ();
		cam1.enabled = true;
		cam2.enabled = false;
	}

	IEnumerator dead(){
		yield return new WaitForSeconds (2.3F);
		battleflow.SStatus = "dead";
		Tomoe_Con.curXP = Tomoe_Con.curXP + S_con.XP;
		E_con.curXP = E_con.curXP + S_con.XP;
		Destroy(this.gameObject);
	}

	void endturn(){

		if (battleflow.EStatus == "dead") {
			battleflow.whichTurn = 2;
		} else {
			battleflow.whichTurn = 1;
		}
	}
}
