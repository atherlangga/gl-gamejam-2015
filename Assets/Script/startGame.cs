using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {
	public GameManager gameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){

		//Start the game on click
		gameManager.StartGame ();

		//Move away the screen
		Vector3 newPosition = this.transform.position;
		newPosition.x = 9000;
		this.transform.position = newPosition;
	}
}
