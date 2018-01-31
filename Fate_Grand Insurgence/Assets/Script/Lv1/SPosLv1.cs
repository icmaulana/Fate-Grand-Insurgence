using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPosLv1 : MonoBehaviour {
	public Camera cam1;
	public Camera cam2;

	// Use this for initialization
	void Start () {
		cam1.enabled = true;
		cam2.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		/*if ((Input.GetKeyDown ("2")) && (MasterGameLv1.whichTurn == 2)) {
			//GetComponent<Transform> ().position = new Vector3 (22.52f, 6.86f, -14.41f);
			cam1.enabled = false;
			cam2.enabled = true;
			StartCoroutine (ret ());
		}*/

		if (EnemyConLv1.SCurHP == 0) {
			EnemyConLv1.anim.Play ("S_KO");
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
		MasterGameLv1.SStatus = "dead";
		Tomoe_ConLv1.curXP = Tomoe_ConLv1.curXP + EnemyConLv1.XP;
		E_conLv1.curXP = E_conLv1.curXP + EnemyConLv1.XP;
		Destroy(this.gameObject);
	}

	void endturn(){

		if (MasterGameLv1.EStatus == "dead") {
			MasterGameLv1.whichTurn = 2;
		} else {
			MasterGameLv1.whichTurn = 1;
		}
	}
}
