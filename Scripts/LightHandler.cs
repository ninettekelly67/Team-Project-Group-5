using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections;

public class LightHandler : MonoBehaviour {

	// Reference to the Spotlight component.
	public Light _light;
	
	public Slider battery;

	// Battery life remaining for the flashlight.
	public static float batteryLife = 100.0f;
	
	// The rate in which the battery life is drained every 1 second.
	public float drainRate = 2.0f;
	
	// Speed (in seconds) the battery life is drained at.
	public float drainSpeed = 1.0f;
	
	void Start() {
		// Call the DrainBattery method every 1 second.
		InvokeRepeating("DrainBattery", drainSpeed, drainSpeed);
	}
	
	// Drain the battery by a set amount each second.
	void DrainBattery() {
		batteryLife -= drainRate;
		//Debug.Log("Battery life drained: " + batteryLife);
		
		if(batteryLife < 0) {
			batteryLife = 0;
		}
	}
	
	public static void AddBatteryLife(float _batteryLife) {
		batteryLife += _batteryLife;
		
		if(batteryLife > 100.0f) {
			batteryLife = 100.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		battery.value = batteryLife;
		
		if(batteryLife <= 0) {
			_light.intensity = 1.2f;
			_light.spotAngle = 38.0f;
			_light.range = 15.0f;
		} else {
			_light.intensity = 2.0f;
			_light.spotAngle = 40.0f;
			_light.range = 30.0f;
		}
	}
}
