using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private int health = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Flip(){
		transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
	}

	void Dead(){
		GetComponent<Animator> ().SetTrigger ("Dead");
	}

	public void Destroy(){
		GameAudio.Instance.ShotClip (0);
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Bullet") {
			GameAudio.Instance.ShotClip (1);
			health--;
			if (health <= 0) {
				Dead ();
			}
		}
	}
}
