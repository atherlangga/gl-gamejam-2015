﻿using UnityEngine;
using System.Collections;

public class ingredient1_handler : MonoBehaviour {

	public GameObject ingredient;
	public static bool pressed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

	}

	void OnMouseUp(){
		//If Goreng wasnt choosed you can still choose Rebus :) 
			if (ok_btn.isGoreng == false & pressed == false) {
				performOrder();
		}
	}


	void performOrder(){
		//Make sure can be pressed only once.
		pressed = true;

		//Make associated ingredient visible
		ingredient.GetComponent<Renderer> ().enabled = true;
		
		//Update order
		ok_btn.currentOrder += 100;
		
		//Inform Rebus has been chosen
		ok_btn.isRebus = true;
	}
}
