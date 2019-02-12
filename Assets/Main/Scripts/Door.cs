using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	private bool opened;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenDoor(GameObject player){
		if (opened) {
			//finish
			GameManager.Instance.GameFinish();
		}else{
			//has key
			if (player.GetComponent<Collecting> ().GetHasKey () && player.GetComponent<PlayerPower> ().GetActiveSuperAgha()) {
				opened = true;
				transform.GetChild (2).gameObject.SetActive (false);
			} 
			//no key
			else if(!player.GetComponent<Collecting> ().GetHasKey ()){ 
				Debug.Log ("No Key");
			}
			//milk not enough
			else if(!player.GetComponent<PlayerPower> ().GetActiveSuperAgha()){ 
				Debug.Log ("milk not enough");
			}
		}
	}
}
