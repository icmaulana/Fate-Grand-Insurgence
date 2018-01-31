using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageTextLv2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().sortingOrder = 100;
		GetComponent<TextMesh> ().text = MasterGameLv2.currentDamage.ToString();
		Destroy (gameObject, 0.3f);
	}

	// Update is called once per frame
	void Update () {

	}
}
