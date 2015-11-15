using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {
	public GameManager gameManager;

	public GameObject backgroundObject;
	public GameObject bowlObject;
	public GameObject rebusObject;
	public GameObject gorengObject;
	public GameObject eggObject;
	public GameObject chiliObject;

	public int customerNumber;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!isSeatEmpty (customerNumber)) {
			backgroundObject.GetComponent<Renderer> ().enabled = true;
			bowlObject.GetComponent<Renderer> ().enabled = true;
		} else {
			backgroundObject.GetComponent<Renderer> ().enabled = false;
			bowlObject.GetComponent<Renderer> ().enabled = false;
		}

		if (isGoreng () && !isSeatEmpty(customerNumber)) {
			//Make associated ingredient visible
			gorengObject.GetComponent<Renderer> ().enabled = true;
		} else {
			gorengObject.GetComponent<Renderer> ().enabled = false;
		}
		
		if (isRebus () && !isSeatEmpty(customerNumber)) {
			//Make associated ingredient visible
			rebusObject.GetComponent<Renderer> ().enabled = true;
		} else {
			rebusObject.GetComponent<Renderer> ().enabled = false;
		}
		
		if (isWithTelur () && !isSeatEmpty(customerNumber)) {
			//Make associated ingredient visible
			eggObject.GetComponent<Renderer> ().enabled = true;
		} else {
			eggObject.GetComponent<Renderer> ().enabled = false;
		}

		if (isWithChilli () && !isSeatEmpty(customerNumber)) {
			//Make associated ingredient visible
			chiliObject.GetComponent<Renderer> ().enabled = true;
		} else {
			chiliObject.GetComponent<Renderer> ().enabled = false;
		}
	}

	private char[] getCustomerOrderChars() {
		int customerOrder = 0;
		switch (customerNumber) {
		case 1:
			customerOrder = gameManager.customerOrder1;
			break;
		case 2:
			customerOrder = gameManager.customerOrder2;
			break;
		case 3:
			customerOrder = gameManager.customerOrder3;
			break;
		default:
			Debug.LogError("Customer number should only be 1, 2, or 3");
			break;
		}
		return customerOrder.ToString ().ToCharArray ();
	}
	
	private bool isGoreng() {
		char[] chars = getCustomerOrderChars ();
		if (chars.Length < 3) {
			return false;
		}
		return chars [0] == '1';
	}
	
	private bool isRebus() {
		char[] chars = getCustomerOrderChars ();
		if (chars.Length < 3) {
			return false;
		}
		return chars [0] == '2';
	}
	
	private bool isWithTelur() {
		char[] chars = getCustomerOrderChars ();
		if (chars.Length < 3) {
			return false;
		}
		return chars [1] == '3';
	}
	
	private bool isWithChilli() {
		char[] chars = getCustomerOrderChars ();
		if (chars.Length < 3) {
			return false;
		}
		return chars [2] == '4';
	}

	private bool isSeatEmpty(int customerNumber) {
		switch (customerNumber) {
		case 1:
			return gameManager.isSeatEmpty1;
		case 2:
			return gameManager.isSeatEmpty2;
		case 3:
			return gameManager.isSeatEmpty3;
		default:
			Debug.LogError("Customer number should only be 1, 2, or 3");
			return false;
		}
	}
}
