using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour {

	[SerializeField]
	private SignInfo[] signInfo;

	private GameObject uiSignPaper;

	private int infoIndex;

	private int infoCount;

	// Use this for initialization
	void Start () {
		infoCount = signInfo.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetInfoCount(){
		return infoCount;
	}

	public void ShowSignPaper(){

		uiSignPaper = GUIManager.Instance.GetSignPaper ();

		//title
		uiSignPaper.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = signInfo[infoIndex].GetTitle();
		//body
		uiSignPaper.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = signInfo[infoIndex].GetBody();
		//image
		uiSignPaper.transform.GetChild (0).GetChild (0).GetChild (2).GetComponent<Image> ().sprite= signInfo [infoIndex].GetSprite();
		uiSignPaper.SetActive (true);
	}

	public void NextInfo(){

		infoIndex++;

		if (infoIndex < infoCount) {
			//title		
//			uiSignPaper.
//
//			transform.
//			GetChild (0).
//			GetChild (0).
//			GetChild (0).
//			GetComponent<Text> ().text = 
//				signInfo [infoIndex].GetTitle ();
			//body
			uiSignPaper.transform.GetChild (0).GetChild (0).GetChild (1).GetComponent<Text> ().text = signInfo [infoIndex].GetBody ();
			//image
			uiSignPaper.transform.GetChild (0).GetChild (0).GetChild (2).GetComponent<Image> ().sprite= signInfo [infoIndex].GetSprite();

		} else {
			uiSignPaper.SetActive (false);	
			infoIndex = 0;
		}

	}


}
	
[System.Serializable]
public class SignInfo {


	[SerializeField]
	private string title;
	[SerializeField]
	private string body;
	[SerializeField]
	private Sprite sprite;


	public string GetTitle(){
		return title;
	}

	public string GetBody(){
		return body;
	}

	public Sprite GetSprite(){
		return sprite;
	}
}
