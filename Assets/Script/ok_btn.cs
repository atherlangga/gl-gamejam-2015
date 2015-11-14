using UnityEngine;
using System.Collections;

public class ok_btn : MonoBehaviour {

	public GameManager gameManager;


	public static int currentOrder;
	public static bool isRebus;
	public static bool isGoreng;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//print (currentOrder);
		//print ("Is rebus: " + isRebus);
		//print ("Is Goreng: " + isGoreng);
	}

	void OnMouseUp(){
		gameManager.ServeCustomerResult1 (currentOrder);
	}


}
