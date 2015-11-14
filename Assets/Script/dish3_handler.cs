using UnityEngine;
using System.Collections;

public class dish3_handler : MonoBehaviour {

	public GameManager gameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		gameManager.MakeCustomerOrder3 ();
	}


}
