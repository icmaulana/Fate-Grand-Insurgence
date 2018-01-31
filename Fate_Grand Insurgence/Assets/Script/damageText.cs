using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().sortingOrder = 100;
		GetComponent<TextMesh> ().text = battleflow.currentDamage.ToString();
		Destroy (gameObject, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
