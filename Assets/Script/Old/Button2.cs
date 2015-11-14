using UnityEngine;
using System.Collections;

public class Button2 : MonoBehaviour {
	public GameManager gameManager;
	
	void OnMouseDown() {
		print ("Button2 clicked");
		gameManager.MakeCustomerOrder2 ();
	}
}
