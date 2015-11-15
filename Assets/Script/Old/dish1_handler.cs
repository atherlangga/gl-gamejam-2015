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

	void OnMouseDown(){
		gameManager.displayPopUp ();
	}

	// Update is called once per frame
	void Update () {
		if (isGoreng ()) {
			//Make associated ingredient visible
			isGorengObject.GetComponent<Renderer> ().enabled = true;
			StartCoroutine("clearFood");
		} else {
			isGorengObject.GetComponent<Renderer> ().enabled = false;
		}
		
		if (isRebus ()) {
			//Make associated ingredient visible
			isRebusObject.GetComponent<Renderer> ().enabled = true;
			StartCoroutine("clearFood");
		}else {
			isRebusObject.GetComponent<Renderer> ().enabled = false;
		}
		
		if (isWithTelur ()) {
			//Make associated ingredient visible
			HasEggObject.GetComponent<Renderer> ().enabled = true;
		} else {
			HasEggObject.GetComponent<Renderer> ().enabled = false;
		}
		if (isWithChilli ()) {
			//Make associated ingredient visible
			HasChiliObject.GetComponent<Renderer> ().enabled = true;
		}
		else {
			HasChiliObject.GetComponent<Renderer> ().enabled = false;
		}
	}

	//Clear the food after a specified time has passed
	IEnumerator clearFood()
	{
		yield return new WaitForSeconds(5);
		gameManager.customerResult1 = 999;
	}

	
	bool isGoreng() {
		if (gameManager.customerResult1 == 0) {
			return false;
		}
		char[] chars = gameManager.customerResult1.ToString ().ToCharArray ();
		return chars [0] == '1';
	}

	bool isRebus() {
		if (gameManager.customerResult1 == 0) {
			return false;
		}
		char[] chars = gameManager.customerResult1.ToString ().ToCharArray ();
		return chars [0] == '2';
	}
	
	bool isWithTelur() {
		if (gameManager.customerResult1 == 0) {
			return false;
		}
		char[] chars = gameManager.customerResult1.ToString ().ToCharArray ();
		return chars [1] == '3';
	}
	
	bool isWithChilli() {
		if (gameManager.customerResult1 == 0) {
			return false;
		}
		char[] chars = gameManager.customerResult1.ToString ().ToCharArray ();
		return chars [2] == '4';
	}
	
	
}
