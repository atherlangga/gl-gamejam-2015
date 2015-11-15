using UnityEngine;
using System.Collections;

public class dish_handler : MonoBehaviour {
	
	public GameManager gameManager;
	public GameObject isRebusObject;
	public GameObject isGorengObject;
	public GameObject HasEggObject;
	public GameObject HasChiliObject;
	public int customerNumber;

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
