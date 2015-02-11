﻿using UnityEngine;
using System.Collections;

public class PlayerCollisionHandler : MonoBehaviour {
	
	// Store the texture rendered above the cursor when the player is able to pickup an object.
	public Texture pickupIcon;
	
	// Flag for determining if the cursor is hovering over a collectable object (Battery etc.).
	bool hoveringOverCollectable = false;
	
	bool canClimb = false;
	bool topOfLadder = false;
	
	// Halo effect of the collectable object (If applied). Represents the glow effect when the mouse is hovered over a collectable object.
	Behaviour halo = null;
	
	// Reference to the CharacterMotor.js script. we use this to disable character movements whilst we are climbing laddes.
	CharacterMotor motor;
	
	void Start() {
		Screen.lockCursor = true;
		Screen.showCursor = true;
		
		// Disable the white capsule rendering that represents the player to prevent it clipping with the camera with head bobbing.
		GetComponentInChildren<MeshRenderer>().enabled = false;
		
		motor = GetComponent<CharacterMotor>();
	}
	
	void OnTriggerEnter(Collider collider) {
		if(collider.tag == "Ladder_Base") {
			canClimb = !canClimb;
			motor.enabled = !canClimb;
		}
		
		if(collider.tag == "Ladder_Top") {
			topOfLadder = true;
		}
	}

	void OnTriggerExit(Collider collider) {
		if(collider.tag == "Ladder_Top") {
			topOfLadder = false;
		}
	}

	// Update is performed each frame.
	void Update() {
		
	}

	// Fixed update is performed on each physic update (Delta time).
	void FixedUpdate () {
		Vector3 moveDirection = Vector3.zero;
		if(canClimb) {
			
			if(Input.GetAxisRaw("Vertical") > 0.0f && !topOfLadder) {
				transform.position += Vector3.up / 10f;
			}
			else if(Input.GetAxisRaw ("Vertical") < 0.0f) {
				transform.position -= Vector3.up / 10f;
			}
		}
		
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
		RaycastHit hit;
		
		// Perform a ray cast down the Z axis relative to the camera transform, with a distance of 2.
		if(Physics.Raycast(ray, out hit, 2.0f)) {
			// If the object the ray intersects with is a battery (Battery Tag)
			if(hit.collider.tag == "Battery") {
				hoveringOverCollectable = true;
				
				// Get the Halo effect component for the game object and enable it if the cursor is over it.
				halo = (Behaviour)hit.collider.gameObject.GetComponent ("Halo");
				halo.enabled = true;
				
				// If the action button is pressed (Defined in InputManager under Axes). E on PC X on controller.
				if(Input.GetAxisRaw("Action") == 1) {
					// Remove the game object from the scene.
					Destroy(hit.collider.gameObject);
					hoveringOverCollectable = false;
					halo.enabled = false;
					// Add a random amount of battery life to the flashlight.
					LightHandler.batteryLife += Random.Range(30, 45);
				}
			}
		// There was no ray cast intersection within the rays trace distance.
		} else {
			hoveringOverCollectable = false;
			if(halo != null)
				halo.enabled = false;
		}
	}
	
	// Called each GUI draw call.
	void OnGUI() {
		// Draw the box crosshair in the middle of the screen.
		GUI.Box (new Rect((Screen.width / 2) - 5, (Screen.height / 2) - 5, 10, 10), "");
		
		// Draw an indication to the user so they are aware they can pickup an object they are curently looking at.
		if(hoveringOverCollectable) {
			GUI.DrawTexture(new Rect((Screen.width / 2) - 5, (Screen.height / 2) - 5, 48, 48), pickupIcon);
		}
	}
}
