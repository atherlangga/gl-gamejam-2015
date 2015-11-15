using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	public bool isSeatEmpty1 = true;
	public bool isSeatEmpty2 = true;
	public bool isSeatEmpty3 = true;


	//Audio variable
	AudioSource mainTheme;
	AudioSource rushTheme;

	private List<float> generatedRandomValues = new List<float> ();

	void Update() {

		// Determine whether the first seat is empty.
		if (customerAnimation1 != null && !customerAnimation1.isPlaying) {
			// If it is, we put the seat empty flag to true
			isSeatEmpty1 = true;
			customerOrder1 = 0;
		}

		// Do the same ting for the second seat..
		if (customerAnimation2 != null &&!customerAnimation2.isPlaying) {
			isSeatEmpty2 = true;
			customerOrder2 = 0;
		}

		// And the third seat.
		if (customerAnimation3 != null && !customerAnimation3.isPlaying) {
			isSeatEmpty3 = true;
			customerOrder3 = 0;
		}
	}

	public void Start(){
		//Get all the attached sounds, and store them into an Array.
		AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
		mainTheme = allMyAudioSources[0];
		rushTheme = allMyAudioSources[1];

		InvokeRepeating ("generateRandomNumber", 1.0f, 1.0f);
	}

	private void generateRandomNumber() {
		generatedRandomValues.Clear ();

		for (int i = 0; i < 10; i++) {
			generatedRandomValues.Add(Random.value);
		}
	}

	//Audio supporting functions
	private void stopMainTheme(){
		mainTheme.Stop ();
	}
	private void playRushTheme(){
		rushTheme.Play ();
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

		//Play MainTheme
		mainTheme.Play ();
		Invoke ("stopMainTheme", 74);
		Invoke ("playRushTheme", 75);


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
		bool shouldShow = false;
		// For the first two Customers, 100% always show
		if (currentCustomerCount <= 1) {
			shouldShow = true;
		} else {
			// For the rest, give 1/3 chance to show
			float randomValue = generatedRandomValues[0];
			shouldShow = randomValue < 0.333f;
		}

		// If we decide not to show new Customer, return;
		if (!shouldShow) {
			return;
		}

		if (isSeatEmpty1) {
			customerOrder1 = determineRequestedIndomie(currentCustomerCount);
			isSeatEmpty1 = false;
			Debug.Log ("customerOrder1: " + customerOrder1);
		} else if (isSeatEmpty2) {
			customerOrder2 = determineRequestedIndomie(currentCustomerCount);
			isSeatEmpty2 = false;
			Debug.Log ("customerOrder2: " + customerOrder2);
		} else if (isSeatEmpty3) {
			customerOrder3 = determineRequestedIndomie(currentCustomerCount);
			isSeatEmpty3 = false;
			Debug.Log ("customerOrder3: " + customerOrder3);
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
			bool wantsGoreng = generatedRandomValues[1] > 0.5;
			if (wantsGoreng) {
				result += 100;
			} else {
				result += 200;
			}
			
			// Customer wants egg?
			bool wantsEgg = generatedRandomValues[2] > 0.5;
			if (wantsEgg) {
				result += 30;
			}
			
			// Customer wants vegetables?
			bool wantsVegetables = generatedRandomValues[3] > 0.5;
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
