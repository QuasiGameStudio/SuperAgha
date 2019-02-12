using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour {

	[SerializeField]
	private Sprite[] photos;
	[SerializeField]
	private Sprite lockPhoto;

	private int index;

	private Image photo;

	// Use this for initialization
	void Start () {
		photo = transform.GetChild (0).GetChild (0).GetComponent<Image> ();

		if(GameData.Instance.GetOpenPhoto(index - 1) == 1)
			photo.sprite = photos [index];
		else
			photo.sprite = lockPhoto;
	}
	
	// Update is called once per frame
	void Update () {
		
	}	

	public void Next(){
		if (index < photos.Length - 1) {
			index++;
			if(GameData.Instance.GetOpenPhoto(index - 1) == 1)
				photo.sprite = photos [index];
			else
				photo.sprite = lockPhoto;
		}

	}

	public void Prev(){
		if (index > 0) {
			index--;
			if(GameData.Instance.GetOpenPhoto(index - 1) == 1)
				photo.sprite = photos [index];
			else
				photo.sprite = lockPhoto;
		}

	}
}
