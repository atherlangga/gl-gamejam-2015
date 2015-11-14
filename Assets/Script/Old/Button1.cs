using UnityEngine;
using System.Collections;

public class Button1 : MonoBehaviour {
	public GameManager gameManager;

	void OnMouseDown() {
		print ("Button1 clicked");
		gameManager.MakeCustomerOrder1 ();
	}
}
