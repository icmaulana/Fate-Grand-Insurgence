using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextEXP2 : MonoBehaviour {
	public static int b;

	[SerializeField]
	private Text valueText;
	// Use this for initialization
	void Start () {
		b = 0;

	}

	// Update is called once per frame
	void Update () {
		b = GameData.TXPneed;
		valueText.text = b.ToString ();
	}
}
