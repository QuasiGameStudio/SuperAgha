using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour {

	private bool hasKey;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){


		if(other.tag == "Milk"){
			Destroy (other.gameObject);
			PlayerPower.Instance.AddMilkPower ();
			GameAudio.Instance.ShotClip (4);
		} 

		if(other.tag == "Sign"){
			other.GetComponent<Sign> ().ShowSignPaper ();
		}

		if(other.tag == "Key"){
			Destroy (other.gameObject);
			GUIManager.Instance.GetKeyImage ().gameObject.SetActive (true);
			hasKey = true;
			GameAudio.Instance.ShotClip (11);
		}

		if(other.tag == "Door"){
			other.GetComponent<Door> ().OpenDoor (this.gameObject);
		}

		if(other.tag == "Enemy"){
			Player.Instance.Dead ();

		}

		if(other.tag == "Water"){			
			Player.Instance.Drown();

		}
			
		if(other.tag == "Chest"){			
			other.GetComponent<Animator> ().SetTrigger ("openChest");
			GameAudio.Instance.ShotClip (5);
		}

		if(other.tag == "Photo"){			
			Destroy (other.gameObject);
			other.GetComponent<Photo> ().GetPhoto ();
			GameAudio.Instance.ShotClip (5);
		}


	}

	public bool GetHasKey(){
		return hasKey;
	}
}
