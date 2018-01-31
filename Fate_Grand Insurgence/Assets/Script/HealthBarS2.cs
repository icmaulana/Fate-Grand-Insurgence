﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarS2 : MonoBehaviour {
	private float fillAmount;

	[SerializeField]
	private Image content;

	[SerializeField]
	private Text valueText;

	[SerializeField]
	private Color fullH;

	[SerializeField]
	private Color lowH;

	[SerializeField]
	private bool lerpColors;

	// Use this for initialization
	void Start () {
		valueText.text = Tomoe_Con.TCurHP.ToString ();
	}

	// Update is called once per frame
	void Update () {
		HandleBar ();
		valueText.text = E_con.EcurHP.ToString ();
	}

	private void HandleBar(){
		if (fillAmount != content.fillAmount) {
			content.fillAmount = Map(Tomoe_Con.TCurHP,0,Tomoe_Con.TMaxHP,0,1);
		}

		if (content.fillAmount <=0.1f) {
			content.color = lowH;
		}
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return(value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

	}
}
