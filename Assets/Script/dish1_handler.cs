using UnityEngine;
using System.Collections;

public class dish1_handler : MonoBehaviour {

	public GameManager gameManager;
	public GameObject isRebusObject;
	public GameObject isGorengObject;
	public GameObject HasEggObject;
	public GameObject HasChiliObject;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp(){
		gameManager.MakeCustomerOrder1 ();
	}


	bool isGoreng() {
		char[] chars = gameManager.customerResult1.ToString ().ToCharArray ();
		return chars [0] == '1';
	}
	
	bool isWithTelur() {
		char[] chars = gameManager.customerResult1.ToString ().ToCharArray ();
		return chars [1] == '3';
	}
	
	bool isWithChilli() {
		char[] chars = gameManager.customerResult1.ToString ().ToCharArray ();
		return chars [2] == '4';
	}
	
	
}
