using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ServantHealthBar1 : MonoBehaviour {

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
		valueText.text = S_con.SCurHP.ToString ();
		//if (lerpColors) {
			content.color = fullH;
		//}
	}

	// Update is called once per frame
	void Update () {
		HandleBar ();
		valueText.text = S_con.SCurHP.ToString ();
	}

	private void HandleBar(){
		if (fillAmount != content.fillAmount) {
			content.fillAmount = Map(S_con.SCurHP,0,S_con.SMaxHP,0,1);
		}

		if (content.fillAmount <=0.1f) {
			content.color = lowH;
		}
		/*if (content.fillAmount >0.1f) {
			content.color = fullH;
		}*/
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return(value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

	}
}
