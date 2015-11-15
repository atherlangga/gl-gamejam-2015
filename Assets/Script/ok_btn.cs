using UnityEngine;
using System.Collections;

public class ok_btn : MonoBehaviour {

	public GameManager gameManager;

	//Global varibles for the recipe
	public static int currentOrder;
	public static bool isRebus;
	public static bool isGoreng;

	public GameObject ingredient1;
	public GameObject ingredient2;
	public GameObject ingredient3;
	public GameObject ingredient4;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseUp(){
		//Come back to normal size
		this.transform.localScale = new Vector3 (70, 70, 1); 


		determineCustomerOrder ();
		resetPopUp ();
	}

	void OnMouseDown(){
		//Make touchEffect
		this.transform.localScale = new Vector3 (100, 100, 1); 
	}

	void determineCustomerOrder(){
		if (currentOrder != 0) {
			switch (gameManager.currentPopUp) {
			case 1:
				gameManager.ServeCustomerResult1 (currentOrder);
				break;
			case 2:
				gameManager.ServeCustomerResult2 (currentOrder);
				break;
			case 3:
				gameManager.ServeCustomerResult3 (currentOrder);
				break;
			}
		}
	}


	void resetPopUp(){
		ok_btn.currentOrder = 0;
		ok_btn.isRebus = false;
		ok_btn.isGoreng = false;
		
		//Make associated ingredients invisible again
		ingredient1.GetComponent<Renderer> ().enabled = false;
		ingredient2.GetComponent<Renderer> ().enabled = false;
		ingredient3.GetComponent<Renderer> ().enabled = false;
		ingredient4.GetComponent<Renderer> ().enabled = false;
		
		//Reset pressed handlers so they can be pressed again!
		ingredient1_handler.pressed = false;
		ingredient2_handler.pressed = false;
		ingredient3_handler.pressed = false;
		ingredient4_handler.pressed = false;
		
		gameManager.clearCamera ();

	}

	
}
