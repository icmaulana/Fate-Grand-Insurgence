using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_con : MonoBehaviour {

	public static Animator anim;
	public static float SMaxHP = 12215;
	public static float SCurHP;
	public static float SMaxAtt = 2825;
	public static float SMinAtt = SMaxAtt * 25 / 100;
	public static int XP = 2500;

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

		if (battleflow.whichTurn == 3) {
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

		if (battleflow.TStatus == "dead") {
			heroAttacked = 1;
		}

		if (battleflow.EStatus == "dead") {
			heroAttacked = 2;
		}

		if (heroAttacked == 1) {
			if (critcalc <= critsuccess) {
				int damagefix = Mathf.RoundToInt (Random.Range (SMaxAtt, SMinAtt));
				battleflow.currentDamage = damagefix;
				E_con.EcurHP = E_con.EcurHP - damagefix;
			}

			if (critcalc > critsuccess) {
				int damagefix = Mathf.RoundToInt (Random.Range (SMaxAtt, SMinAtt)) * 2;
				battleflow.currentDamage = damagefix;
				E_con.EcurHP = E_con.EcurHP - damagefix;
			}

			E_con.anim.Play ("Dantes_hitted");
			Instantiate (damtextObj, new Vector3 (0f, 6.86f, -14.41f), damtextObj.rotation);
			/*cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = true;
			StartCoroutine (camback ());*/
		} else {
			if (critcalc <= critsuccess) {
				int damagefix = Mathf.RoundToInt(Random.Range (SMaxAtt, SMinAtt));
				battleflow.currentDamage = damagefix;
				Tomoe_Con.TCurHP = Tomoe_Con.TCurHP - damagefix;
				Debug.Log ("Tomoe HP = " + Tomoe_Con.TCurHP); 
			}

			if (critcalc > critsuccess) {
				int damagefix = Mathf.RoundToInt(Random.Range (SMaxAtt, SMinAtt)) * 2;
				battleflow.currentDamage = damagefix;
				Tomoe_Con.TCurHP = Tomoe_Con.TCurHP - damagefix;
				Debug.Log ("Tomoe HP = " + Tomoe_Con.TCurHP);
			}

			Tomoe_Con.anim.Play ("hitted");
			Instantiate (damtextObj, new Vector3 (-6.45f,7.274f, -14.41f), damtextObj.rotation);
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

		if (battleflow.EStatus == "dead") {
			battleflow.whichTurn = 2;
			battleflow.heal1 = battleflow.heal1 - 1;
			battleflow.heal2 = battleflow.heal2 - 1;
		} else {
			battleflow.whichTurn = 1;
			battleflow.heal1 = battleflow.heal1 - 1;
			battleflow.heal2 = battleflow.heal2 - 1;
		}
	}
}
