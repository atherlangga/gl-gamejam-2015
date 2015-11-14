using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Camera mainCamera;

	public int currentCustomerCount = 0;
	public int happyCustomersCount = 0;
	public int sadCustomersCount = 0;

	public int customerOrder1 = 0;
	public int customerResult1 = 999;
	public int customerOrder2 = 0;
	public int customerResult2 = 999;
	public int customerOrder3 = 0;
	public int customerResult3 = 999;

	public int secondsLeft = 90;
	public int currentPopUp;

	public Animator customerAnimator1;
	public Animator customerAnimator2;
	public Animator customerAnimator3;

	public Animation customerAnimation1;
	public Animation customerAnimation2;
	public Animation customerAnimation3;

	private System.Timers.Timer gameTimer;

	private bool isSeatEmpty1 = true;
	private bool isSeatEmpty2 = true;
	private bool isSeatEmpty3 = true;

	void Update() {
		// Determine whether the first seat is empty.
		if (customerAnimation1 != null && !customerAnimation1.isPlaying) {
			// If it is, we put the seat empty flag to true
			isSeatEmpty1 = true;
		}

		// Do the same ting for the second seat..
		if (customerAnimation2 != null &&!customerAnimation2.isPlaying) {
			isSeatEmpty2 = true;
		}

		// And the third seat.
		if (customerAnimation3 != null && !customerAnimation3.isPlaying) {
			isSeatEmpty3 = true;
		}
	}

	public void Start(){
		StartGame ();
	}

	public void StartGame() {
		// Create a timer and make it tick every second
		gameTimer = new System.Timers.Timer (1000);

		gameTimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => {
			// Reduce `secondsLeft` every second
			secondsLeft--;

			// Generate new Customer if necessary
			generateNewCustomerIfNecessary();
		};

		gameTimer.Start ();
	}

	public void MakeCustomerOrder1() {
		displayPopUp ();
		//Specify the customer you are serving
		currentPopUp = 1;
	}

	public void MakeCustomerOrder2() {
		displayPopUp ();
		//Specify the customer you are serving
		currentPopUp = 2;
	}

	public void MakeCustomerOrder3() {
		displayPopUp ();
		//Specify the customer you are serving
		currentPopUp = 3;
	}

	// To be called from the pop-up
	public void ServeCustomerResult1(int result) {
		if (result == customerOrder1) {
			happyCustomersCount++;
		} else {
			sadCustomersCount++;
		}
		clearCamera ();

		customerResult1 = result;
		// TODO: play animation.
	}

	// To be called from the pop-up
	public void ServeCustomerResult2(int result) {
		if (result == customerOrder2) {
			happyCustomersCount++;
		} else {
			sadCustomersCount++;
		}
		clearCamera ();

		customerResult2 = result;
	}

	// To be called from the pop-up
	public void ServeCustomerResult3(int result) {
		if (result == customerOrder3) {
			happyCustomersCount++;
		} else {
			sadCustomersCount++;
		}
		clearCamera ();

		customerResult3 = result;
	}


	public void clearCamera(){
		//Focus back on MainScene
		//mainCamera.transform.Translate (-1319f,0,0);
		Vector3 newPosition = mainCamera.transform.position;
		newPosition.x = -1320f;
		mainCamera.transform.position = newPosition;
	}

	public void displayPopUp(){
		Vector3 newPosition = mainCamera.transform.position;
		newPosition.x += 1320f;
		mainCamera.transform.position = newPosition;
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

	private void generateNewCustomerIfNecessary() {
		if (currentCustomerCount == 0) {
			customerOrder1 = determineRequestedIndomie (currentCustomerCount);
		} else if (currentCustomerCount == 1) {
			customerOrder2 = determineRequestedIndomie (currentCustomerCount);
		} else {
			if (isSeatEmpty1) {
				customerOrder1 = determineRequestedIndomie(currentCustomerCount);
			} else if (isSeatEmpty2) {
				customerOrder2 = determineRequestedIndomie(currentCustomerCount);
			} else if (isSeatEmpty3) {
				customerOrder3 = determineRequestedIndomie(currentCustomerCount);
			}
		}

		currentCustomerCount++;
	}

	private int determineRequestedIndomie(int orderNumber) {
		if (orderNumber == 0) {
			return 100;
		} else if (orderNumber == 1) {
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
