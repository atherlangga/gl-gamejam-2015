using UnityEngine;
using System.Collections;

public class Balloon1 : MonoBehaviour {
	public GameManager gameManager;
	
	// Update is called once per frame
	void Update () {
		// TODO: Draw texture:
		// gameManager.customerOrder1
	}

	void OnMouseDown() {
		// TODO: Remove this
		gameManager.StartGame ();
	}
}
