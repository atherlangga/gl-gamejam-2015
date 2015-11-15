using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public Camera mainCamera;

	public GameObject dish1;
	public GameObject dish2;
	public GameObject dish3;

	public GameObject hand1;
	public GameObject hand2;
	public GameObject hand3;


	public GameObject dishContent1;
	public GameObject dishContent2;
	public GameObject dishContent3;

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

	public bool isSeatEmpty1 = true;
	public bool isSeatEmpty2 = true;
	public bool isSeatEmpty3 = true;

	public GameObject customer1;
	public GameObject customer2;
	public GameObject customer3;
	
	//Audio variable
	AudioSource mainTheme;
	AudioSource rushTheme;

	AudioSource happyCustomerSound;
	AudioSource sadCustomerSound;
	private List<float> generatedRandomValues = new List<float> ();

	public void Start(){
		//Get all the attached sounds, and store them into an Array.
		AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
		mainTheme = allMyAudioSources[0];
		rushTheme = allMyAudioSources[1];
		happyCustomerSound = allMyAudioSources [2];
		sadCustomerSound = allMyAudioSources [3];
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
	private void stopRushTheme() {
		rushTheme.Play ();
	}

	private void tick() {
		generateRandomNumber ();
		generateNewCustomerIfNecessary();

		secondsLeft--;

		//Trigger the game over!
		if (secondsLeft == 0) {
			EndGame();
		}

	}

	public void StartGame() {
		//Center the camera on the Game.
		clearCamera ();

		// Register a function to be called every second
		InvokeRepeating ("tick", 1.0f, 1.0f);

		//Play MainTheme
		mainTheme.Play ();
		Invoke ("stopMainTheme", 74);
		Invoke ("playRushTheme", 75);
		Invoke ("stopRushTheme", 89);
	}

	public void EndGame(){
		print ("game over");

		CancelInvoke ();

		Vector3 newPosition = mainCamera.transform.position;
		newPosition.x = -2370f;
		mainCamera.transform.position = newPosition;
	}

	public void ResetGame() {
		secondsLeft = 90;
		currentCustomerCount = 0;
		happyCustomersCount = 0;
		sadCustomersCount = 0;

		resetTable1 ();
		resetTable2 ();
		resetTable3 ();
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
		customerResult1 = result;
		if (result == customerOrder1) {
			happyCustomersCount++;
			happyCustomerSound.Play();
		} else {
			sadCustomersCount++;
			sadCustomerSound.Play();
		}
		clearCamera ();
	
		// Make sure the table is ready
		dish1.GetComponent<DishClick> ().makeDishBusy (1);
		dishContent1.GetComponent<dish_handler> ().Render ();
		hand1.GetComponent<Animator> ().SetBool ("HandActive", true);

		// Make sure the table is cleaned afterwards
		Invoke ("resetTable1", 5.0f);
	}

	// To be called from the pop-up
	public void ServeCustomerResult2(int result) {
		customerResult2 = result;
		if (result == customerOrder2) {
			happyCustomersCount++;
			happyCustomerSound.Play();
		} else {
			sadCustomersCount++;
			sadCustomerSound.Play();
		}
		clearCamera ();

		// Make sure the table is ready
		dish2.GetComponent<DishClick> ().makeDishBusy (2);
		dishContent2.GetComponent<dish_handler> ().Render ();
		hand2.GetComponent<Animator> ().SetBool ("HandActive", true);
		// Make sure the table is cleaned afterwards
		Invoke ("resetTable2", 5.0f);
	}

	// To be called from the pop-up
	public void ServeCustomerResult3(int result) {
		customerResult3 = result;
		if (result == customerOrder3) {
			happyCustomersCount++;
			happyCustomerSound.Play();
		} else {
			sadCustomersCount++;
			sadCustomerSound.Play();
		}
		clearCamera ();

		// Make sure the table is ready
		dish3.GetComponent<DishClick> ().makeDishBusy (2);
		dishContent3.GetComponent<dish_handler> ().Render ();
		hand3.GetComponent<Animator> ().SetBool ("HandActive", true);
		
		// Make sure the table is cleaned afterwards
		Invoke ("resetTable3", 5.0f);
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

		// For the first Customer, give the player 5 seconds, and
		// give 4 seconds for the second Customer.
		if (secondsLeft == 90 || secondsLeft == 85) {
			shouldShow = true;
		} else if (secondsLeft <= 81) {
			// For the rest, give 1/3 chance to show
			float randomValue = generatedRandomValues[0];
			shouldShow = randomValue < 0.5f;
		}

		// If we decide not to show new Customer, return;
		if (!shouldShow) {
			return;
		}

		if (isSeatEmpty1) {
			customerOrder1 = determineRequestedIndomie(currentCustomerCount);
			isSeatEmpty1 = false;
			customer1.GetComponent<Renderer> ().enabled = true;
			currentCustomerCount++;
		} else if (isSeatEmpty2) {
			customerOrder2 = determineRequestedIndomie(currentCustomerCount);
			isSeatEmpty2 = false;
			customer2.GetComponent<Renderer> ().enabled = true;
			currentCustomerCount++;
		} else if (isSeatEmpty3) {
			customerOrder3 = determineRequestedIndomie(currentCustomerCount);
			isSeatEmpty3 = false;
			customer3.GetComponent<Renderer> ().enabled = true;
			currentCustomerCount++;
		}
	}

	private void resetTable1() {
		customerOrder1 = 0;
		customerResult1 = 999;
		customer1.GetComponent<Renderer> ().enabled = false;
		dishContent1.GetComponent<dish_handler> ().Render ();
		hand1.GetComponent<Animator> ().SetBool ("HandActive", false);
		isSeatEmpty1 = true;
	}

	private void resetTable2() {
		customerOrder2 = 0;
		customerResult2 = 999;
		customer2.GetComponent<Renderer> ().enabled = false;
		dishContent2.GetComponent<dish_handler> ().Render ();
		hand2.GetComponent<Animator> ().SetBool ("HandActive", false);
		isSeatEmpty2 = true;
	}

	private void resetTable3() {
		customerOrder3 = 0;
		customerResult3 = 999;
		customer3.GetComponent<Renderer> ().enabled = false;
		dishContent3.GetComponent<dish_handler> ().Render ();
		hand3.GetComponent<Animator> ().SetBool ("HandActive", false);
		isSeatEmpty3 = true;
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
	
	public int determineStars() {
		if (happyCustomersCount >= 20) {
			return 5;
		} else if (happyCustomersCount >= 10) {
			return 4;
		} else if (happyCustomersCount >= 5) {
			return 3;
		} else if (happyCustomersCount >= 2) {
			return 2;
		} else {
			return 1;
		}
	}

}
