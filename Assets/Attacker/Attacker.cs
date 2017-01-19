using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	private NavMeshAgent agent;
	private Transform target;
	private Transform spawnPoint;

	public int maxHealth;
	private int currHealth;
	private AudioSource audioSource;
	public AudioClip gotShot;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		currHealth = maxHealth;
		agent = GetComponent<NavMeshAgent> ();
		target = FindObjectOfType<Finish> ().GetComponent<Transform> (); 
		spawnPoint = FindObjectOfType<SpawnPoint> ().GetComponent<Transform> (); 
		transform.position = spawnPoint.position;
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (target.position);
		//jump
		/* if (transform.position.y == 2.63f) {
			transform.position += new Vector3 (0, 1f, 0);
		} */

	}
	void Die() {
		Destroy (gameObject);
	}
	public void Hit() {
		audioSource.clip = gotShot;
		audioSource.Play ();
		if (--currHealth <= 0) {
			FindObjectOfType<GameController> ().EarnMoney ();
			audioSource.clip = gotShot;
			audioSource.Play ();
			Invoke ("Die", audioSource.clip.length);
		}
		}
}
