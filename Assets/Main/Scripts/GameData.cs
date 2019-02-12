using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData> {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenPhoto(int index){
		string key = "OpenPhoto_" + index;
		PlayerPrefs.SetInt (key, 1);
	}

	public int GetOpenPhoto(int index){
		string key = "OpenPhoto_" + index;
		return PlayerPrefs.GetInt (key, 0);
	}
}
