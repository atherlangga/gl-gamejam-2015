using UnityEngine;
using System.Collections;

public class DishClick : MonoBehaviour {

	public GameManager gameManager;
	public int customerNumber;

	public bool dish1Busy;
	public bool dish2Busy;
	public bool dish3Busy;

	//Prevent dishes to be touchable while they are full
	public void makeDishBusy(int dishNum){
		switch (dishNum) {
		case 1: dish1Busy = true;
			Invoke("makeDish1Empty", 5);
			break;
		case 2: dish2Busy = true;
			Invoke("makeDish2Empty", 5);
			break;
		case 3: dish3Busy = true;
			Invoke("makeDish3Empty", 5);
			break;
		}
	}

	//Empty my dishes functions
	void makeDish1Empty(){
		dish1Busy = false;
		}
	void makeDish2Empty(){
		dish2Busy = false;
	}
	void makeDish3Empty(){
		dish3Busy = false;
	}


	void OnMouseUp(){
		switch (customerNumber) {
		case 1:
			if(!dish1Busy){ gameManager.MakeCustomerOrder1 ();}
			break;
		case 2:
			if(!dish2Busy){ gameManager.MakeCustomerOrder2 (); }
			break;
		case 3:
			if(!dish3Busy){gameManager.MakeCustomerOrder3 (); }
			break;
		}
	}
}
