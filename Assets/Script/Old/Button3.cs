using UnityEngine;
using System.Collections;

public class Button3 : MonoBehaviour {
	public GameManager gameManager;
	
	void OnMouseDown() {
		print ("Button3 clicked");
		gameManager.MakeCustomerOrder3 ();
	}
}
