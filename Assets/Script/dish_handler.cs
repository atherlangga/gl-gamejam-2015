using UnityEngine;
using System.Collections;

public class dish_handler : MonoBehaviour {
	
	public GameManager gameManager;
	public GameObject isRebusObject;
	public GameObject isGorengObject;
	public GameObject HasEggObject;
	public GameObject HasChiliObject;
	public int customerNumber;

	void Start(){
		InvokeRepeating ("scaleUp", 0.5f, 1.0f);
		InvokeRepeating ("scaleDown", 1.0f, 1.0f);
	}

	public void Render() {


		if (isGoreng ()) {
			//Make associated ingredient visible
			isGorengObject.GetComponent<Renderer> ().enabled = true;
		} else {
			isGorengObject.GetComponent<Renderer> ().enabled = false;
		}
		
		if (isRebus ()) {
			//Make associated ingredient visible
			isRebusObject.GetComponent<Renderer> ().enabled = true;
			//StartCoroutine("clearFood");
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

	char[] getCustomerResultChars() {
		int customerResult = 0;
		switch (customerNumber) {
		case 1:
			customerResult = gameManager.customerResult1;
			break;
		case 2:
			customerResult = gameManager.customerResult2;
			break;
		case 3:
			customerResult = gameManager.customerResult3;
			break;
		default:
			Debug.LogError("Customer number should only be 1, 2, or 3");
			break;
		}
		return customerResult.ToString ().ToCharArray ();
	}

	void scaleUp(){
		switch (customerNumber) {
		case 1: if(gameManager.customerOrder1 != 0 && (gameManager.customerResult1 == 999 || gameManager.customerResult1 == 0)) { this.transform.localScale = new Vector3 (100, 100, 1); }
			break;
		case 2: if(gameManager.customerOrder2 != 0 && (gameManager.customerResult2 == 999 || gameManager.customerResult2 == 0)) { this.transform.localScale = new Vector3 (100, 100, 1); }
			break;
		case 3: if(gameManager.customerOrder3 != 0 && (gameManager.customerResult3 == 999 || gameManager.customerResult3 == 0)) { this.transform.localScale = new Vector3 (100, 100, 1); }
			break;
		}

	}
	void scaleDown(){
		this.transform.localScale = new Vector3 (90, 90, 1);
	}

	bool isGoreng() {
		char[] chars = getCustomerResultChars ();
		if (chars.Length < 3) {
			return false;
		}
		return chars [0] == '1';
	}
	
	bool isRebus() {
		char[] chars = getCustomerResultChars ();
		if (chars.Length < 3) {
			return false;
		}
		return chars [0] == '2';
	}
	
	bool isWithTelur() {
		char[] chars = getCustomerResultChars ();
		if (chars.Length < 3) {
			return false;
		}
		return chars [1] == '3';
	}
	
	bool isWithChilli() {
		char[] chars = getCustomerResultChars ();
		if (chars.Length < 3) {
			return false;
		}
		return chars [2] == '4';
	}
	
	
}
