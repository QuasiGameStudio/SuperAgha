using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float bulletSpeedX = 200;
	private float bulletSpeedY = 70;

	void Start(){
		GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeedY);
		if(Player.Instance.GetPlayerDir() > 0)
			GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeedX);
		else
			GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeedX);
	}



	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.layer == 9|| other.tag == "Enemy")
			Destroy (this.gameObject);
	}

}
