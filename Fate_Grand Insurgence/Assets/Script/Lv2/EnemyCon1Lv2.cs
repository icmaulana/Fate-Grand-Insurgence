using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCon1Lv2 : MonoBehaviour {

	public static Animator anim;
	public static float SMaxHP = 3243;
	public static float SCurHP;
	public static float SMaxAtt = 325;
	public static float SMinAtt = SMaxAtt * 25 / 100;
	public static int XP = 621;

	public int heroAttacked;

	public Transform damtextObj;
	private int critsuccess;
	private int critcalc;
	public AudioSource audiosource;
	public AudioClip shot;
	public AudioClip regdam;

	public Camera cam1;
	public Camera cam2;
	public Camera cam3;

	// Use this for initialization
	void Start () {
		SCurHP = SMaxHP;
		anim = GetComponent<Animator> ();
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
		audiosource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (SCurHP < 0) {
			SCurHP = 0;
		}

		if (MasterGameLv2.whichTurn == 3) {
			anim.Play ("Buster1");
			if (MasterGameLv2.S2Status == "OK") {
				StartCoroutine (delay ());
				MasterGameLv2.whichTurn = 4;
			} else {
				endturn ();
			}
		}
	}

	public void hitted(){
		anim.Play ("Hitted");
		audiosource.PlayOneShot (regdam);
	}

	void attack(){

		heroAttacked = Random.Range (1, 3);

		critcalc = Random.Range(0,101);
		critsuccess = 65;

		if (MasterGameLv2.TStatus == "dead") {
			heroAttacked = 1;
		}

		if (MasterGameLv2.EStatus == "dead") {
			heroAttacked = 2;
		}

		if (heroAttacked == 1) {
			if (critcalc <= critsuccess) {
				int damagefix = Mathf.RoundToInt (Random.Range (SMaxAtt, SMinAtt));
				MasterGameLv2.currentDamage = damagefix;
				E_con1Lv2.EcurHP = E_con1Lv2.EcurHP - damagefix;
			}

			if (critcalc > critsuccess) {
				int damagefix = Mathf.RoundToInt (Random.Range (SMaxAtt, SMinAtt)) * 2;
				MasterGameLv2.currentDamage = damagefix;
				E_con1Lv2.EcurHP = E_con1Lv2.EcurHP - damagefix;
			}

			E_con1Lv2.anim.Play ("Dantes_hitted");
			Instantiate (damtextObj, new Vector3 (-74.1f,27.846f, 62.4f), damtextObj.rotation);
			/*cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = true;
			StartCoroutine (camback ());*/
		} else {
			if (critcalc <= critsuccess) {
				int damagefix = Mathf.RoundToInt(Random.Range (SMaxAtt, SMinAtt));
				MasterGameLv2.currentDamage = damagefix;
				Tomoe_ConLv2.TCurHP = Tomoe_ConLv2.TCurHP - damagefix;
				Debug.Log ("Tomoe HP = " + Tomoe_ConLv2.TCurHP); 
			}

			if (critcalc > critsuccess) {
				int damagefix = Mathf.RoundToInt(Random.Range (SMaxAtt, SMinAtt)) * 2;
				MasterGameLv2.currentDamage = damagefix;
				Tomoe_ConLv2.TCurHP = Tomoe_ConLv2.TCurHP - damagefix;
				Debug.Log ("Tomoe HP = " + Tomoe_ConLv2.TCurHP);
			}

			Tomoe_ConLv2.anim.Play ("hitted");
			Instantiate (damtextObj, new Vector3 (-112.7f, 28.26f, 62.4f), damtextObj.rotation);
			/*cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = true;
			StartCoroutine (camback());*/
		}

	}

	IEnumerator camback(){
		yield return new WaitForSeconds (2.3F);
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
	}

	void ashot(){
		audiosource.PlayOneShot (shot);
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
