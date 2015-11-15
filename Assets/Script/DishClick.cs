using UnityEngine;
using System.Collections;

public class DishClick : MonoBehaviour {

	public GameManager gameManager;
	public int customerNumber;

	
	void OnMouseUp(){
		switch (customerNumber) {
		case 1:
				gameManager.MakeCustomerOrder1 ();
			break;
		case 2:
				gameManager.MakeCustomerOrder2 ();
			break;
		case 3:
				gameManager.MakeCustomerOrder3 ();
			break;
		}
	}
}
