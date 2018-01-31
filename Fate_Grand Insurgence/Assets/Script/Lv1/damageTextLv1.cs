using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageTextLv1 : MonoBehaviour {

	void Start () {
		GetComponent<Renderer> ().sortingOrder = 100;
		GetComponent<TextMesh> ().text = MasterGameLv1.currentDamage.ToString();
		Destroy (gameObject, 0.3f);
	}

	// Update is called once per frame
	void Update () {

	}
}
