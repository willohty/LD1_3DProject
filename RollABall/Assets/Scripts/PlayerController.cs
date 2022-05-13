using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {


	public Indicator indicationUI;
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;


	//Values to regulate the amount of time speed is modified
	public float speedModifier = 1;
	public bool isBoosting = false;
	public float boostTimer;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private int count;
	private GameController gameController;

	public SimpleTimer SimpleTimer;

	// At the start of the game..
	void Start ()
	{
		gameController = GetComponentInParent<GameController>();
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		//Boost Timer keeps track of the amount of time while boosting
		boostTimer = 0;
	}

	// Each physics step..
	void FixedUpdate()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce(movement * speed * speedModifier);

		//Boost Timer regulates how long the player is boosted upon picking up object tagged "Speed Boost"
		if (isBoosting)
		{
			
			boostTimer += Time.deltaTime;
			if (boostTimer >= 1.5)
			{
				speedModifier = 1;
				boostTimer = 0;
				isBoosting = false;
			}
		}

		//Quit Function
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the GameController function for picking up a collectible
			gameController.OnPickUpCollectible(count);
		}


		//NEW STUFF
		//
		if (other.gameObject.CompareTag("Time Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive(false);

			// Run the GameController function for picking up a collectible
			SimpleTimer.AddToTimer(5);
			indicationUI.showTimeChangeToPlayer();

		}

		if (other.gameObject.CompareTag("Speed Boost"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive(false);

			speedModifier = 2;
			isBoosting = true;
			indicationUI.showBoostingToPlayer();
		}
	}
}