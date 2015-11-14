using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Camera mainCamera;

	public int currentCustomerCount = 0;
	public int happyCustomersCount = 0;
	public int sadCustomersCount = 0;

	public int customerOrder1 = 0;
	public int customerResult1 = 0;
	public int customerOrder2 = 0;
	public int customerResult2 = 0;
	public int customerOrder3 = 0;
	public int customerResult3 = 0;

	public int secondsLeft = 90;


	private System.Timers.Timer gameTimer;

	public void StartGame() {
		// Create a timer and make it tick every second
		gameTimer = new System.Timers.Timer (1000);

		// Reduce `secondsLeft` every second
		gameTimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => {
			print ("Tick");
			secondsLeft--;
		};

		gameTimer.Start ();
	}

	public void MakeCustomerOrder1() {
		this.mainCamera.transform.Translate (new Vector3 (1400f, 0f, 0f));
	}

	public void MakeCustomerOrder2() {
		// TODO
		this.mainCamera.transform.Translate (new Vector3 (0.5f, 0f, 0f));
	}

	public void MakeCustomerOrder3() {
		// TODO
		this.mainCamera.transform.Translate (new Vector3 (-1.0f, 0f, 0f));
	}

	// To be called from the pop-up
	public void ServeCustomerResult1(int result) {
		if (result == customerOrder1) {
			happyCustomersCount++;
		} else {
			sadCustomersCount++;
		}
		clearCamera ();
	}

	// To be called from the pop-up
	public void ServeCustomerResult2(int result) {
		if (result == customerOrder2) {
			happyCustomersCount++;
		} else {
			sadCustomersCount++;
		}
		clearCamera ();
	}

	// To be called from the pop-up
	public void ServeCustomerResult3(int result) {
		if (result == customerOrder3) {
			happyCustomersCount++;
		} else {
			sadCustomersCount++;
		}
		clearCamera ();
	}


	public void clearCamera(){
		//Focus back on MainScene
		mainCamera.transform.Translate (-1319f,0,0);
	}


	// Parts needed for Singleton Pattern
	// ----------------------------------
	public static GameManager instance = null;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}
	// ----------------------------------

	private int determineRequestedIndomie(int orderNumber) {
		if (orderNumber == 1) {
			return 100;
		} else if (orderNumber == 2) {
			return 200;
		} else {
			// Really randomizes this time
			int result = 0;
			
			// For mie type
			int mieType = (int) Random.value * 100;
			result += mieType;
			
			// Customer wants egg?
			bool wantsEgg = Random.value > 0.5;
			if (wantsEgg) {
				result += 30;
			}
			
			// Customer wants vegetables?
			bool wantsVegetables = Random.value > 0.5;
			if (wantsVegetables) {
				result += 4;
			}
			
			return result;
		}
	}
	
	private int determineStars(int happyCustomersCount, int sadCustomersCount) {
		// TODO
		return 0;
	}

}
