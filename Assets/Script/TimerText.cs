using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerText : MonoBehaviour {
	public GameManager gameManager;

	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Text> ().text = gameManager.secondsLeft.ToString();
	}
}
