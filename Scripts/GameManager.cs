using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Starting time (in seconds) that the level will initialise at.
	public float startTime = 60.0f;
	public Text timer;
	
	public static bool gameOver;
	
	bool releaseMonster;
	bool monsterReleased;
	static float currentTime;
	


	// Use this for initialization
	void Start () {
		currentTime = startTime;
		releaseMonster = false;
		gameOver = false;
		
		InvokeRepeating("CountTimer", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(gameOver) {
			EndGame();
		}
		
		if(releaseMonster) {
			if(!monsterReleased) {
				monsterReleased = true;
				SpawnManager sm = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
				sm.SpawnMonster();
			}
		}
	}
	
	public static void AddTime(float _time) {
		currentTime += _time;
	}
	
	static void EndGame() {
		//TODO: Set the scene to a game over state.
		Application.Quit();
	}
	
	void CountTimer() {
		currentTime--;
		
		if(currentTime < 0) {
			currentTime = 0;
			releaseMonster = true;
			timer.text = "RUN!";
		}
		else {
			timer.text = currentTime.ToString ();
		}
		
		
	}
}
