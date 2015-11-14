using UnityEngine;
using System.Collections;

public class dish1_handler : MonoBehaviour {

	public GameManager gameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		gameManager.MakeCustomerOrder1 ();
	}


	boolean isGoreng() {
		char[] chars = gameManager.customerResult1.ToString ().ToCharArray ();
		return chars [0] == '1';
	}
	
	boolean isWithTelur() {
		char[] chars = gameManager.customerResult1.ToString ().ToCharArray ();
		return chars [1] == '3';
	}
	
	boolean isWithChilli() {
		char[] chars = gameManager.customerResult1.ToString ().ToCharArray ();
		return chars [2] == '4';
	}
	
	
}
