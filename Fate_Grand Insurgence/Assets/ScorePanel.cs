using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour {
	//float a;
	public static int b;

	[SerializeField]
	private Text valueText;
	// Use this for initialization
	void Start () {
		//a = battleflow.currentDamage;
		b = Score.b;

	}

	// Update is called once per frame
	void Update () {
		//a = a + E_con.damagefix;
		//b = (int)a;

		valueText.text = b.ToString ();
	}
}
