using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerText : MonoBehaviour {
	public GameManager gameManager;

	// Update is called once per frame
	void Update () {
		if (gameManager.secondsLeft <= 10) {
			this.gameObject.GetComponent<Text> ().color = Color.red;
		}
		this.gameObject.GetComponent<Text> ().text = "Time Remaining: " + gameManager.secondsLeft.ToString();
	}

}
