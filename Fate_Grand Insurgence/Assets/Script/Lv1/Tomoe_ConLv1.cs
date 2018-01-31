﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomoe_ConLv1 : MonoBehaviour {

	public static Animator anim;
	public static int TMaxHP = GameData.THP;
	public static int TCurHP;
	public static int TMaxAtt = GameData.TAtt;
	public static int TMinAtt = TMaxAtt * 25 / 100;
	public static int damagefix;

	public Transform damtextObj;
	private int critsuccess;
	private int critcalc;
	public AudioSource audiosource;
	public AudioClip Quick;
	public AudioClip regdam;

	public static int lv = GameData.TLv;
	public static int curXP = GameData.TcurXP;
	public static int nextXP = GameData.TnextXP;
	public static int XPneed = GameData.TXPneed;

	// Use this for initialization
	void Start () {
		TCurHP = TMaxHP;
		anim = GetComponent<Animator> ();
		audiosource = GetComponent<AudioSource> ();
	}
	// Update is called once per frame
	void Update () {
		//XP
		if (MasterGameLv1.SStatus == "dead") {
			XPneed = nextXP - curXP - 100;
			GameData.TcurXP = curXP;
			GameData.TXPneed = XPneed;

			if (XPneed < 0) {
				XPneed = XPneed * (-1);
			}

			if (curXP > nextXP) {
				GetEXP ();
				MasterGameLv1.Tlv = "lvup";
			}
		}


		//Battle
		if (TCurHP < 0) {
			TCurHP = 0;
			MasterGameLv1.TStatus = "dead";
			anim.Play ("dead");
			StartCoroutine (ko ());
		}
		/*if (Input.GetKeyDown("2") && (MasterGameLv1.whichTurn == 2)) {
			audiosource.PlayOneShot (Quick);
			GetComponent<Transform> ().position = new Vector3 (13.34f,6.86f, -14.41f);
			anim.Play ("Quick");
			StartCoroutine (returnpos ());

		}*/

	}

	public void hitted(){
		anim.Play ("hitted");
		audiosource.PlayOneShot (regdam);
	}

	void quck(){
		EnemyConLv1.anim.Play ("Hitted");
		critcalc = Random.Range(0,101);
		critsuccess = 65;

		if (critcalc <= critsuccess) {
			damagefix = Mathf.RoundToInt(Random.Range (TMaxAtt, TMinAtt));
			MasterGameLv1.currentDamage = damagefix/3;
			EnemyConLv1.SCurHP = EnemyConLv1.SCurHP - damagefix;
			Score.b = Score.b + damagefix;
		}

		if (critcalc > critsuccess) {
			damagefix = Mathf.RoundToInt(Random.Range (TMaxAtt, TMinAtt)) * 2;
			MasterGameLv1.currentDamage = damagefix/3;
			EnemyConLv1.SCurHP = EnemyConLv1.SCurHP - damagefix;
			Score.b = Score.b + damagefix;
		}

		Instantiate (damtextObj, new Vector3 (22.2f,-28.614f, 62.4f), damtextObj.rotation);
	}

	IEnumerator returnpos(){
		yield return new WaitForSeconds (2.03F);
		GetComponent<Transform> ().position = new Vector3 (-46.9f,-28.2f, 62.4f);
		MasterGameLv1.whichTurn = 3;
	}

	IEnumerator ko(){
		yield return new WaitForSeconds (3);
		Destroy (this.gameObject);
	}

	public void heal(){
		TCurHP = TCurHP + 1200;
		MasterGameLv1.whichTurn = 3;
		MasterGameLv1.heal2 = 3;
	}

	public void attack(){
		audiosource.PlayOneShot (Quick);
		GetComponent<Transform> ().position = new Vector3 (12.2f,-28.614f, 62.4f);
		anim.Play ("Quick");
		StartCoroutine (returnpos ());
	}

	void GetEXP(){
		lv++;
		nextXP = nextXP * 2;
		TMaxHP = TMaxHP + 200 + (TMaxHP * 2 / 100);
		TMaxAtt = TMaxAtt + 200 + (TMaxAtt * 2 / 100);
		GameData.TAtt = TMaxAtt;
		GameData.THP = TMaxHP;
		GameData.TnextXP = nextXP;
		GameData.TLv = lv;	
	}
}
