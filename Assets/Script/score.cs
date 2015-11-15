using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {

	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int updateScore = gameManager.happyCustomersCount * 30;

		this.gameObject.GetComponent<Text>().text  = "Score: " + updateScore.ToString();
	}
}
