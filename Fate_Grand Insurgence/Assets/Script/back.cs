using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour {

	public class backPressFromAR : MonoBehaviour {


		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown (KeyCode.Escape))
				Application.LoadLevel ("main_menu");
		}

}
}
