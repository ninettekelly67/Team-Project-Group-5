using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	Transform playerToFollow;
	NavMeshAgent nav;
	public AudioSource monsterSoundsPlayer;
	public AudioSource monsterRoarPlayer;
	
	public AudioClip[] sounds;

	void Start () {
		nav = GetComponent<NavMeshAgent>();
		playerToFollow = GameObject.FindGameObjectWithTag("Player").transform;
	
		PlayRoar ();
		
		Invoke("PlaySound", Random.Range(3.5f, 7.5f));
	}
	
	void Update () {
		nav.SetDestination(playerToFollow.position);
	}
	
	void PlaySound() {
		int index = Random.Range(0, sounds.Length);
		
		monsterSoundsPlayer.clip = sounds[index];
		monsterSoundsPlayer.Play();
		
		Invoke ("PlaySound", Random.Range(2.5f, 10.0f));
	}
	
	void PlayRoar() {
		monsterRoarPlayer.Play ();
	}
}
