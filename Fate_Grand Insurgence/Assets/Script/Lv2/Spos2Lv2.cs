using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spos2Lv2 : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;

	// Use this for initialization
	void Start () {
		cam1.enabled = true;
		cam2.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		/*if ((Input.GetKeyDown ("2")) && (MasterGameLv2.whichTurn == 2)) {
			//GetComponent<Transform> ().position = new Vector3 (22.52f, 6.86f, -14.41f);
			cam1.enabled = false;
			cam2.enabled = true;
			StartCoroutine (ret ());
		}*/

		if (EnemyCon2Lv2.SCurHP == 0) {
			EnemyCon2Lv2.anim.Play ("S_KO");
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
		MasterGameLv2.S2Status = "dead";
		Tomoe_ConLv2.curXP = Tomoe_ConLv2.curXP + EnemyCon2Lv2.XP;
		E_con1Lv2.curXP = E_con1Lv2.curXP + EnemyCon2Lv2.XP;
		Destroy(this.gameObject);
	}

	IEnumerator delay(){
		yield return new WaitForSeconds (3f);
	}

	void endturn(){
		StartCoroutine (delay ());
		if (MasterGameLv2.EStatus == "dead") {
			MasterGameLv2.whichTurn = 2;
			MasterGameLv2.heal1 = MasterGameLv2.heal1 - 1;
			MasterGameLv2.heal2 = MasterGameLv2.heal2 - 1;
		} else {
			MasterGameLv2.whichTurn = 1;
			MasterGameLv2.heal1 = MasterGameLv2.heal1 - 1;
			MasterGameLv2.heal2 = MasterGameLv2.heal2 - 1;
		}
	}
}
