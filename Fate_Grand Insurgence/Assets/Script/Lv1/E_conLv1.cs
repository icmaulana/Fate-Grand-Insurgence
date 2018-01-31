using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_conLv1 : MonoBehaviour {

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
	public static int XPneed = nextXP-curXP;

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
		if (MasterGameLv1.SStatus == "dead") {
			XPneed = nextXP - curXP - 100;
			GameData.EcurXP = curXP;
			GameData.EXPneed = XPneed;

			if (XPneed < 0) {
				XPneed = XPneed * (-1);
			}

			if (curXP > nextXP) {
				GetEXP ();
				MasterGameLv1.Elv = "lvup";
			}
		}

		//Battle Stat
		if (EcurHP <= 0) {
			EcurHP = 0;
			MasterGameLv1.EStatus = "dead";
			MasterGameLv1.whichTurn = 2;
		}

		if (Input.GetKeyDown("space")) {
			anim.Play ("Dantes_Buster1");
			/*float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target1.position, step);*/
		}


		/*if (Input.GetKeyDown("2") && (MasterGameLv1.whichTurn == 1)) {
			anim.Play ("Dantes_arts1");
			//MasterGameLv1.whichTurn = 2;
		}*/
	}

	void returns(){
		transform.position = Vector3.MoveTowards (transform.position, target2.position, speed);
	}

	void arts1(){
		EnemyConLv1.anim.Play ("Hitted");
		critcalc = Random.Range(0,101);
		critsuccess = 65;

		if (critcalc <= critsuccess) {
			damagefix = Mathf.RoundToInt(Random.Range (EMaxAtt, EMinAtt));
			MasterGameLv1.currentDamage = damagefix;
			EnemyConLv1.SCurHP = EnemyConLv1.SCurHP - damagefix;
			Score.b = Score.b + damagefix;
		}

		if (critcalc > critsuccess) {
			damagefix = Mathf.RoundToInt(Random.Range (EMaxAtt, EMinAtt)) * 2;
			MasterGameLv1.currentDamage = damagefix;
			EnemyConLv1.SCurHP = EnemyConLv1.SCurHP - damagefix;
			Score.b = Score.b + damagefix;
		}


		Instantiate (damtextObj, new Vector3 (22.2f,-28.614f, 62.4f), damtextObj.rotation);
	}

	void hitted(){
		audiosource.PlayOneShot (regdam);
	}

	public void heal(){
		EcurHP = EcurHP + 800;
		MasterGameLv1.whichTurn = 2;
		MasterGameLv1.heal1 = 3;
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
