using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour {

	private int index;

	// Use this for initialization
	void Start () {
		string name = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer> ().sprite.name;
		string tempName = "";
		for (int i = 0; i < name.Length; i++) {
			if (int.TryParse (name [i].ToString(),out index)) {
				string n = name [i].ToString();
				tempName += n;

			}
		}
			
		index = int.Parse (tempName);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetPhoto(){
		GUIManager.Instance.GetPhotoPanel ().transform.GetChild (0).GetChild (0).GetChild (0).GetComponent<Image> ().sprite = GUIManager.Instance.GetPhoto (index - 1);
		GUIManager.Instance.GetPhotoPanel ().transform.GetChild (0).GetChild (0).GetChild (3).GetComponent<Text> ().text = GUIManager.Instance.GetPhotoNote(index - 1);
		GUIManager.Instance.GetPhotoPanel ().SetActive (true);
		GameData.Instance.OpenPhoto (index);
	}


}
