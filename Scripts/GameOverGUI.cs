using UnityEngine;
using System.Collections;

public class GameOverGUI : MonoBehaviour {

	public Texture gameOverTex;
	
	float buttonWidth = 256.0f;
	float buttonHeight = 64.0f;
	float buttonSpacing = 0.0f;
	
	float screenCentreX = Screen.width / 2;
	float screenCentreY = Screen.height / 2; 

	// Use this for initialization
	void Start () {
		buttonSpacing = buttonHeight + 10.0f;
		
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		// Draw the Game over background
		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), gameOverTex);
		
		// Draw the option buttons
		if(GUI.Button (new Rect(screenCentreX - (buttonWidth / 2), screenCentreY + buttonSpacing, buttonWidth, buttonHeight), "Play Again")) {
			// TODO: Way of loading the last played level when all levels are merged into project
			Application.LoadLevel ("ProtoRoom1");
		}
		if(GUI.Button (new Rect(screenCentreX - (buttonWidth / 2), screenCentreY + buttonSpacing * 2, buttonWidth, buttonHeight), "Main Menu")) {
			// TODO: Load the main menu when integrated
			Debug.Log ("Pressed menu button");
		}
		if(GUI.Button (new Rect(screenCentreX - (buttonWidth / 2), screenCentreY + buttonSpacing * 3, buttonWidth, buttonHeight), "Exit Game")) {
			Application.Quit();
		}
	}
}
