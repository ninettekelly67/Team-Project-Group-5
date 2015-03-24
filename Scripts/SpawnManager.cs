using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	// Store the battery prefab.
	public GameObject batteryPrefab;
	
	// Store the clock prefab.
	public GameObject clockPrefab;
	
	// Store the key prefab.
	public GameObject keyPrefab;
	
	// Store the door prefab.
	public GameObject doorPrefab;
	
	// Store the enemy prefab.
	public GameObject enemyPrefab;
	
	// Store the player prefab.
	public GameObject playerPrefab;
	
	// Set the minimum number of batteries that can spawn in the level.
	public int minBatteries = 1;
	
	// Set the maximum number of batteries that can spawn in the level.
	public int maxBatteries = 1;
	
	// Set the minimum number of clocks that can spawn in the level.
	public int minClocks = 1;
	
	// Set the maximum number of clocks that can spawn in the level.
	public int maxClocks = 1;

	// Store each of the possible battery spawn locations.
	ArrayList batterySpawns = new ArrayList();
	
	// Store each of the possible clock spawn locations.
	ArrayList clockSpawns = new ArrayList();
	
	// Store each of the possible key spawn locations.
	ArrayList keySpawns = new ArrayList();
	
	// Store each of the possible door spawn locations.
	ArrayList doorSpawns = new ArrayList();
	
	//Store each of the possible enemy spawn locations.
	ArrayList enemySpawns = new ArrayList();
	
	// Store each of the possible player spawn locations.
	ArrayList playerSpawns = new ArrayList();

	// Use this for initialization
	void Start () {
		Debug.Log ("Searching for spawn locations for batteries, clocks, keys, doors and enemies.");

		// Populate the spawn point arrays
		foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("Battery_Spawn")) {
			batterySpawns.Add(spawnPoint);
		}
		
		foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("Clock_Spawn")) {
			clockSpawns.Add(spawnPoint);
		}
		
		foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("Key_Spawn")) {
			keySpawns.Add(spawnPoint);
		}
		
		foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("Door_Spawn")) {
			doorSpawns.Add(spawnPoint);
		}
		
		foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("Enemy_Spawn")) {
			enemySpawns.Add(spawnPoint);
		}
		
		foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("Player_Spawn")) {
			playerSpawns.Add(spawnPoint);
		}
		
		Debug.Log ("Found " + batterySpawns.Count + " possible battery spawn locations.");
		Debug.Log ("Found " + clockSpawns.Count + " possible clock spawn locations.");
		Debug.Log ("Found " + keySpawns.Count + " possible key spawn locations.");
		Debug.Log ("Found " + doorSpawns.Count + " possible door spawn locations.");
		Debug.Log ("Found " + enemySpawns.Count + " possible enemy spawn locations.");
		Debug.Log ("Found " + playerSpawns.Count + " possible player spawn locations.");
		
		// Quick check to make sure the min and max battery counts are not invalid. I.e min is more than 1 and max is not higher than total spawn locations.
		if(minBatteries < 1) {
			Debug.LogWarning ("Min batteries can't be less than 1!");
			minBatteries = 1;
		}
		
		if(maxBatteries > batterySpawns.Count) {
			Debug.LogWarning("Max batteries can't be more than the current number of spawn locations for batteries!");
			maxBatteries = batterySpawns.Count;
		}
		
		// Quick check to make sure the min and max clock counts are not invalid. I.e min is more than 1 and max is not higher than total spawn locations.
		if(minClocks < 1) {
			Debug.LogWarning ("Min batteries can't be less than 1!");
			minClocks = 1;
		}
		
		if(maxClocks > clockSpawns.Count) {
			Debug.LogWarning("Max clocks can't be more than the current number of spawn locations for clocks!");
			maxClocks = clockSpawns.Count;
		}
		
		PlaceSpawnables();
		SpawnPlayer();
	}
	
	void PlaceSpawnables() {
		PlaceBatteries();
		PlaceClocks();
		PlaceKey();
		PlaceDoor();
	}
	
	void PlaceBatteries() {
		Debug.Log("Placing batteries..");
		
		// Specify a random number of batteries to spawn in the level.
		int numOfBatteries = Random.Range(minBatteries, maxBatteries);
		
		for(int i = 0; i < numOfBatteries; ++i) {
			// Choose a random location for the battery to spawn.
			int spawnIndex = Random.Range (0, batterySpawns.Count);
			GameObject spawnLocation = (GameObject)batterySpawns[spawnIndex];
			
			// Get the position of the selected spawn location.
			Vector3 position = spawnLocation.transform.position;
			
			// Offset the Y slightly so the battery doesnt clip with the object its placed on.
			position.y += 0.05f;
			
			// Instantiate the battery using the battery prefab, the spawn locations position and the prefabs rotation.
			Instantiate(batteryPrefab, position, batteryPrefab.transform.rotation);
			
			// Remove the selected spawn location to prevent duplicate battery spawns at the same location.
			batterySpawns.RemoveAt(spawnIndex);
		}
		
		Debug.Log ("Placed " + numOfBatteries + " batteries.");
	}
	
	void PlaceClocks() {
		Debug.Log("Placing clocks..");
		
		// Specify a random number of clocks to spawn in the level.
		int numOfClocks = Random.Range(minClocks, maxClocks);
		
		for(int i = 0; i < numOfClocks; ++i) {
			// Choose a random location for the clock to spawn.
			int spawnIndex = Random.Range (0, clockSpawns.Count);
			GameObject spawnLocation = (GameObject)clockSpawns[spawnIndex];
			
			// Get the position of the selected spawn location.
			Vector3 position = spawnLocation.transform.position;
			
			// Offset the Y slightly so the clock doesnt clip with the object its placed on.
			position.y += 0.05f;
			
			// Instantiate the clock using the clock prefab, the spawn locations position and the prefabs rotation.
			Instantiate(clockPrefab, position, clockPrefab.transform.rotation);
			
			// Remove the selected spawn location to prevent duplicate clock spawns at the same location.
			clockSpawns.RemoveAt(spawnIndex);
		}
		
		Debug.Log ("Placed " + numOfClocks + " clocks.");
	}
	
	void PlaceKey() {
		Debug.Log ("Placing key..");
		
		int spawnIndex = Random.Range (0, keySpawns.Count);
		GameObject spawnLocation = (GameObject)keySpawns[spawnIndex];
		
		Vector3 position = spawnLocation.transform.position;
		
		position.y -= 0.15f;
		
		Instantiate(keyPrefab, position, keyPrefab.transform.rotation);
		
		keySpawns.RemoveAt(spawnIndex);
	}
	
	void PlaceDoor() {
		Debug.Log ("Placing door..");
		
		int spawnIndex = Random.Range (0, doorSpawns.Count);
		GameObject spawnLocation = (GameObject)doorSpawns[spawnIndex];
		
		Vector3 position = spawnLocation.transform.position;
		position.y += 1.4f;
		
		Instantiate(doorPrefab, position, spawnLocation.transform.rotation);
		
		doorSpawns.RemoveAt(spawnIndex);
	}
	
	void SpawnPlayer() {
		Debug.Log ("Spawning player..");
		
		int spawnIndex = Random.Range (0, playerSpawns.Count);
		GameObject spawnLocation = (GameObject)playerSpawns[spawnIndex];
		
		Vector3 position = spawnLocation.transform.position;
		position.y += 2.0f;
		
		playerPrefab.transform.position = position;
		playerPrefab.transform.rotation = spawnLocation.transform.rotation;
	}
	
	public void SpawnMonster() {
		Debug.Log ("Spawning monster..");
		
		int spawnIndex = Random.Range(0, enemySpawns.Count);
		GameObject spawnLocation = (GameObject)enemySpawns[spawnIndex];
		
		Vector3 posistion = spawnLocation.transform.position;
		
		Instantiate(enemyPrefab, posistion, Quaternion.identity);
	}
}








