using UnityEngine;
using System.Collections;

public class replayBtn : MonoBehaviour {

	public GameManager gameManager;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		//REset scale
		this.transform.localScale = new Vector3 (100, 100, 1);

		gameManager.ResetGame ();
		gameManager.StartGame ();
	}

	void OnMouseDown(){
		//Make touch effect
		this.transform.localScale = new Vector3 (120, 120, 1);
	}

}
