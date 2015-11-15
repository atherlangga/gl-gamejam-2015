using UnityEngine;
using System.Collections;

public class showStars : MonoBehaviour {

	public GameManager gameManager;

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public GameObject star4;
	public GameObject star5;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		determineStars ();
	}

	void determineStars(){
		int tempDetermine = gameManager.determineStars ();
		switch (tempDetermine) {
		case 5:
			star1.GetComponent<Renderer>().enabled = true;
			star2.GetComponent<Renderer>().enabled = true;
			star3.GetComponent<Renderer>().enabled = true;
			star4.GetComponent<Renderer>().enabled = true;
			star5.GetComponent<Renderer>().enabled = true;
			break;
		case 4:
			star1.GetComponent<Renderer>().enabled = true;
			star2.GetComponent<Renderer>().enabled = true;
			star3.GetComponent<Renderer>().enabled = true;
			star4.GetComponent<Renderer>().enabled = true;
			star5.GetComponent<Renderer>().enabled = false;
			break;
		case 3:
			star1.GetComponent<Renderer>().enabled = true;
			star2.GetComponent<Renderer>().enabled = true;
			star3.GetComponent<Renderer>().enabled = true;
			star4.GetComponent<Renderer>().enabled = false;
			star5.GetComponent<Renderer>().enabled = false;
			break;
		case 2:
			star1.GetComponent<Renderer>().enabled = true;
			star2.GetComponent<Renderer>().enabled = true;
			star3.GetComponent<Renderer>().enabled = false;
			star4.GetComponent<Renderer>().enabled = false;
			star5.GetComponent<Renderer>().enabled = false;
			break;
		case 1:
			star1.GetComponent<Renderer>().enabled = true;
			star2.GetComponent<Renderer>().enabled = false;
			star3.GetComponent<Renderer>().enabled = false;
			star4.GetComponent<Renderer>().enabled = false;
			star5.GetComponent<Renderer>().enabled = false;
			break;
		}
	}

}
