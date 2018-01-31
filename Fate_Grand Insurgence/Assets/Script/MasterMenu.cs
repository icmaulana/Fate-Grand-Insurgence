using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void newgame(string sceneName){
		Application.LoadLevel (sceneName);
	}

	public void con(string sceneName){
		load ();
		Application.LoadLevel (sceneName);
	}

	private void load(){
		SaveLoad.Load ();
	}

	public void exit(){
		Application.Quit ();
	}
}
