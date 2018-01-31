using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConLv1 : MonoBehaviour {

	public static Animator anim;
	public static float SMaxHP = 2243;
	public static float SCurHP;
	public static float SMaxAtt = 225;
	public static float SMinAtt = SMaxAtt * 25 / 100;
	public static int XP = 521;

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

		if (MasterGameLv1.whichTurn == 3) {
			anim.Play ("Buster1");
			endturn ();
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

		if (MasterGameLv1.TStatus == "dead") {
			heroAttacked = 1;
		}

		if (MasterGameLv1.EStatus == "dead") {
			heroAttacked = 2;
		}

		if (heroAttacked == 1) {
			if (critcalc <= critsuccess) {
				int damagefix = Mathf.RoundToInt (Random.Range (SMaxAtt, SMinAtt));
				MasterGameLv1.currentDamage = damagefix;
				E_conLv1.EcurHP = E_conLv1.EcurHP - damagefix;
			}

			if (critcalc > critsuccess) {
				int damagefix = Mathf.RoundToInt (Random.Range (SMaxAtt, SMinAtt)) * 2;
				MasterGameLv1.currentDamage = damagefix;
				E_conLv1.EcurHP = E_conLv1.EcurHP - damagefix;
			}

			E_conLv1.anim.Play ("Dantes_hitted");
			Instantiate (damtextObj, new Vector3 (-31f, -28.614f, 62.4f), damtextObj.rotation);
			/*cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = true;
			StartCoroutine (camback ());*/
		} else {
			if (critcalc <= critsuccess) {
				int damagefix = Mathf.RoundToInt(Random.Range (SMaxAtt, SMinAtt));
				MasterGameLv1.currentDamage = damagefix;
				Tomoe_ConLv1.TCurHP = Tomoe_ConLv1.TCurHP - damagefix;
				Debug.Log ("Tomoe HP = " + Tomoe_ConLv1.TCurHP); 
			}

			if (critcalc > critsuccess) {
				int damagefix = Mathf.RoundToInt(Random.Range (SMaxAtt, SMinAtt)) * 2;
				MasterGameLv1.currentDamage = damagefix;
				Tomoe_ConLv1.TCurHP = Tomoe_ConLv1.TCurHP - damagefix;
				Debug.Log ("Tomoe HP = " + Tomoe_ConLv1.TCurHP);
			}

			Tomoe_ConLv1.anim.Play ("hitted");
			Instantiate (damtextObj, new Vector3 (-46.9f, -28.614f, 62.4f), damtextObj.rotation);
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

	void endturn(){

		if (MasterGameLv1.EStatus == "dead") {
			MasterGameLv1.whichTurn = 2;
			MasterGameLv1.heal1 = MasterGameLv1.heal1 - 1;
			MasterGameLv1.heal2 = MasterGameLv1.heal2 - 1;
		} else {
			MasterGameLv1.whichTurn = 1;
			MasterGameLv1.heal1 = MasterGameLv1.heal1 - 1;
			MasterGameLv1.heal2 = MasterGameLv1.heal2 - 1;
		}
	}
}
