using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public class LightHandler : MonoBehaviour {

	// Reference to the Spotlight component.
	public Light _light;

	// Battery life remaining for the flashlight.
	public static float batteryLife = 100.0f;
	
	// The rate in which the battery life is drained every 1 second.
	public float drainRate = 2.0f;
	
	void Start() {
		_light.intensity = 2.0f;
		_light.spotAngle = 55.0f;
		_light.range = 39.0f;
		
		// Call the DrainBattery method every 1 second.
		InvokeRepeating("DrainBattery", 1.0f, 1.0f);
	}
	
	// Drain the battery by a set amount each second.
	void DrainBattery() {
		batteryLife -= drainRate;
		Debug.Log("Battery life drained: " + batteryLife);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
