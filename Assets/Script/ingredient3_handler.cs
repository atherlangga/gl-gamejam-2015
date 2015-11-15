using UnityEngine;
using System.Collections;

public class ingredient3_handler : MonoBehaviour {

	public GameObject ingredient;
	public static bool pressed;

	AudioSource mainSound;
	AudioSource BlockSound;
	
	// Use this for initialization
	void Start () {
		//Get all the attached sounds, and store them into an Array.
		AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
		mainSound = allMyAudioSources[0];
		BlockSound = allMyAudioSources[1];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//Add a onTOuch effect
		if (!pressed) {
			this.transform.localScale = new Vector3 (240, 240, 1); 
			//Crack the egg sound
			mainSound.Play();
		}
		if (pressed) {
			//If you already pressed, play the blockSound
			BlockSound.Play ();
			//Scale it smaller
			this.transform.localScale = new Vector3 (220, 215, 1); 
		}
	}

	void OnMouseUp(){
		//Come back to normal the scale
		this.transform.localScale = new Vector3 (210, 205, 1);

		if (pressed == false) {
			performOrder ();
		}
	}
	
	void performOrder(){
		//Make sure can be pressed only once.
		pressed = true;
		
		//Make associated ingredient visible
		ingredient.GetComponent<Renderer> ().enabled = true;
		
		//Update order
		ok_btn.currentOrder += 30;
		
	}
}
