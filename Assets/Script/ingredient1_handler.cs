using UnityEngine;
using System.Collections;

public class ingredient1_handler : MonoBehaviour {

	public GameObject ingredient;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

	}

	void OnMouseUp(){
		ingredient.GetComponent<Renderer> ().enabled = true;
	}


}
