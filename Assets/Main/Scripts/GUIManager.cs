using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager> {

	[SerializeField]
	private Slider milkSlider;
	[SerializeField]
	private GameObject signPaper;
	[SerializeField]
	private GameObject winPanel;
	[SerializeField]
	private GameObject losePanel;
	[SerializeField]
	private GameObject photoPanel;
	[SerializeField]
	private Image keyImage;

	[SerializeField]
	private Sprite[] photos;

	[SerializeField]
	private string[] photoNotes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Slider GetMilkSlider(){
		return milkSlider;
	}

	public GameObject GetSignPaper(){
		return signPaper;
	}

	public GameObject GetWinPanel(){
		return winPanel;
	}

	public GameObject GetLosePanel(){
		return losePanel;
	}

	public GameObject GetPhotoPanel(){
		return photoPanel;
	}

	public Image GetKeyImage(){
		return keyImage;
	}

	public Sprite GetPhoto(int index){
		return photos [index];
	}

	public string GetPhotoNote(int index){
		return photoNotes [index];
	}
}
