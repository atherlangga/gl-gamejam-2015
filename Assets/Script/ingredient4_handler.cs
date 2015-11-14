using UnityEngine;
using System.Collections;

public class ingredient4_handler : MonoBehaviour {
	public GameObject ingredient;
	public static bool pressed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//Add a onTOuch effect
		if (pressed == false) {
			this.transform.localScale = new Vector3 (240, 240, 1); 

		}
	}


	void OnMouseUp(){
		//Come back to normal the scale
		this.transform.localScale = new Vector3 (210, 205, 1);

		if (pressed == false) {
			performOrder ();
		}
	}
	
	void performOrder(){
			//Make sure can be pressed only once.
			pressed = true;

		//Make associated ingredient visible
		ingredient.GetComponent<Renderer> ().enabled = true;
		
		//Update order
		ok_btn.currentOrder += 4;

	}


}
