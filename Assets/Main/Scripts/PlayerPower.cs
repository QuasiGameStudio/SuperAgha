using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : Singleton<PlayerPower> {

	private float milkPower;

	private bool activeSuperAgha;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddMilkPower(){
		milkPower += 5f;
		GUIManager.Instance.GetMilkSlider ().value = milkPower;

		if (milkPower >= GUIManager.Instance.GetMilkSlider ().maxValue)
			activeSuperAgha = true;


	}

	public bool GetActiveSuperAgha(){
		return activeSuperAgha;
	}
}
