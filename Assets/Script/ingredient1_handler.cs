using UnityEngine;
using System.Collections;

public class ingredient1_handler : MonoBehaviour {

	public GameObject ingredient;
	public static bool pressed;
	AudioSource fryingSound;
	AudioSource BlockSound;

	
	void Start () {
			//Get all the attached sounds, and store them into an Array.
			AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
			fryingSound = allMyAudioSources[0];
			BlockSound = allMyAudioSources[1];
		}

	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		//Add a onTOuch effect
		if (ok_btn.isGoreng == false & pressed == false) {
			this.transform.localScale = new Vector3 (240, 240, 1); 
			//Play the sound
			fryingSound.Play();

		}
		if (pressed) {
			//If you already pressed, play the blockSound
			BlockSound.Play ();
		}

	}

	void OnMouseUp(){
		//Come back to normal the scale
		this.transform.localScale = new Vector3 (210, 205, 1); 

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
