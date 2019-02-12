using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backsound : Singleton<Backsound> {

	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName != "Home" && Application.loadedLevelName != "Level") {
			GetComponent<AudioSource> ().Pause ();		
		} else {
			if(!GetComponent<AudioSource> ().isPlaying)
				GetComponent<AudioSource> ().Play ();


		}
	}
}
