using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_con : MonoBehaviour {

	public static Animator anim;
	public static int EMaxHP = GameData.EHP;
	public static int EcurHP;
	public static int EMaxAtt = GameData.EAtt;
	public static int EMinAtt = EMaxAtt * 25 / 100;
	public Transform damtextObj;
	private int critsuccess;
	private int critcalc;
	public static int damagefix;
	public AudioSource audiosource;
	public AudioClip regdam;

	public static int lv = GameData.ELv;
	public static int curXP = GameData.EcurXP;
	public static int nextXP = GameData.EnextXP;
	public static int XPneed = GameData.EXPneed;

	public static tranPos pos;




	public Transform target1;
	public Transform target2;
	public float speed;

	// Use this for initialization
	void Start () {
		EcurHP = EMaxHP;
		anim = GetComponent<Animator> ();
		audiosource = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		//XP
		if (battleflow.SStatus == "dead") {
			XPneed = nextXP - curXP - 100;
			GameData.EcurXP = curXP;

			if (XPneed < 0) {
				XPneed = XPneed * (-1);
			}

			if (curXP > nextXP) {
				GetEXP ();
				battleflow.Elv = "lvup";
			}
		}

		//Battle Stat
		if (EcurHP <= 0) {
			EcurHP = 0;
			battleflow.EStatus = "dead";
			battleflow.whichTurn = 2;
		}

		if (Input.GetKeyDown("space")) {
			anim.Play ("Dantes_Buster1");
			/*float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target1.position, step);*/
		}


		/*if (Input.GetKeyDown("2") && (battleflow.whichTurn == 1)) {
			anim.Play ("Dantes_arts1");
			//battleflow.whichTurn = 2;
		}*/
	}

	void returns(){
		transform.position = Vector3.MoveTowards (transform.position, target2.position, speed);
	}

	void arts1(){
		S_con.anim.Play ("Hitted");
		critcalc = Random.Range(0,101);
		critsuccess = 65;

		if (critcalc <= critsuccess) {
			damagefix = Mathf.RoundToInt(Random.Range (EMaxAtt, EMinAtt));
			battleflow.currentDamage = damagefix;
			S_con.SCurHP = S_con.SCurHP - damagefix;
			Score.b = Score.b + damagefix;
		}

		if (critcalc > critsuccess) {
			damagefix = Mathf.RoundToInt(Random.Range (EMaxAtt, EMinAtt)) * 2;
			battleflow.currentDamage = damagefix;
			S_con.SCurHP = S_con.SCurHP - damagefix;
			Score.b = Score.b + damagefix;
		}


		Instantiate (damtextObj, new Vector3 (16.28f, 6.86f, -14.41f), damtextObj.rotation);
	}

	void hitted(){
		audiosource.PlayOneShot (regdam);
	}

	public void heal(){
		EcurHP = EcurHP + 800;
		battleflow.whichTurn = 2;
		battleflow.heal1 = 3;
	}

	public void attack(){
		anim.Play ("Dantes_arts1");
	}

	void GetEXP(){
		lv++;
		nextXP = nextXP * 2;
		EMaxHP = EMaxHP + 200 + (EMaxHP * 2 / 100);
		EMaxAtt = EMaxAtt + 200 + (EMaxAtt * 2 / 100);
		GameData.EAtt = EMaxAtt;
		GameData.EHP = EMaxHP;
		GameData.EnextXP = nextXP;
		GameData.ELv = lv;
	}
}
