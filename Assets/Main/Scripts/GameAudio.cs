using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : Singleton<GameAudio> {

	[SerializeField]
	private AudioClip[] gameClips;

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShotClip(int index){
		audioSource.PlayOneShot (gameClips[index]);
	}
}
