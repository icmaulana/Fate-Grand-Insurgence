using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPGET : MonoBehaviour {
	public static int b;

	[SerializeField]
	private Text valueText;
	// Use this for initialization
	void Start () {
		b = 0;

	}

	// Update is called once per frame
	void Update () {
		b = S_con.XP;
		valueText.text = b.ToString ();
	}
}
