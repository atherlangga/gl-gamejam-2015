using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {
	public GameManager gameManager;
	public int customerNumber;

	// Update is called once per frame
	void Update () {
		bool isSeatEmpty = true;
		switch (customerNumber) {
		case 1:
			isSeatEmpty = gameManager.isSeatEmpty1;
			break;
		case 2:
			isSeatEmpty = gameManager.isSeatEmpty2;
			break;
		case 3:
			isSeatEmpty = gameManager.isSeatEmpty3;
			break;
		default:
			Debug.LogError("Customer number should only be 1, 2, or 3");
			break;
		}

		if (isSeatEmpty) {
			gameObject.GetComponent<Renderer> ().enabled = false;
		} else {
			gameObject.GetComponent<Renderer> ().enabled = true;

			// Make customer gone 5 seconds after the food are served.
			clearCustomerIfNeeded();
		}
	}

	void clearCustomerIfNeeded() {
		switch (customerNumber) {
		case 1:
			if (gameManager.customerResult1 != 999 && gameManager.customerResult1 != 0) {
				StartCoroutine("clearCustomer");
			}
			break;
		case 2:
			if (gameManager.customerResult2 != 999 && gameManager.customerResult2 != 0) {
				StartCoroutine("clearCustomer");
			}
			break;
		case 3:
			if (gameManager.customerResult3 != 999 && gameManager.customerResult3 != 0) {
				StartCoroutine("clearCustomer");
			}
			break;
		default:
			Debug.LogError("Customer number should only be 1, 2, or 3");
			break;
		}
	}

	IEnumerator clearCustomer() {
		yield return new WaitForSeconds(5);

		Debug.Log("Will reset customer " + customerNumber);
		switch (customerNumber) {
		case 1:
			gameManager.isSeatEmpty1 = true;
			gameManager.customerOrder1 = 0;
			break;
		case 2:
			gameManager.isSeatEmpty2 = true;
			gameManager.customerOrder2 = 0;
			break;
		case 3:
			gameManager.isSeatEmpty2 = true;
			gameManager.customerOrder2 = 0;
			break;
		default:
			Debug.LogError("Customer number should only be 1, 2, or 3");
			break;
		}
	}
}
