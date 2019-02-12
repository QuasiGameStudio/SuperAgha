using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

	private bool isPaused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameFinish(){
		Debug.Log ("Game Finish");
		GUIManager.Instance.GetWinPanel ().SetActive (true);
		GameAudio.Instance.ShotClip (2);
	}

	public IEnumerator GameOver(){
		Debug.Log ("Game Over");

		yield return new WaitForSeconds(2);
		GUIManager.Instance.GetLosePanel ().SetActive (true);
	}

	public void SetIsPaused(bool value){
		isPaused = value;
	}

	public bool GetIsPaused(){
		return isPaused;
	}
}
