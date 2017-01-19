using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	public float rotationSpeed;
	private Transform gunTransform;
	private TowerGun cannon;
	private Transform target;
	[Range(1,5)]
	public int fireRate;

	private bool shooting;
	public int cost;
	public int buildTime;

	public TowerUpgrade[] towerupgrades;

	private AudioSource audioSource;
	public AudioClip shot;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		shooting = false;
		cannon = GetComponentInChildren<TowerGun> ();
		gunTransform = GetComponentInChildren<TowerGun> ().GetComponent<Transform> ();
		//target = FindObjectOfType<Attacker> ().GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		 * float step = rotationSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(gun.forward, target.position, step, 0.0F);
		Debug.DrawRay(gun.position, newDir, Color.red);
		gun.rotation = Quaternion.LookRotation(newDir);

	*/
	}

	public void Upgrade() {
		
	}

	void OnTriggerStay(Collider coll) {
		if (coll.tag == "Attacker") {
			float step = rotationSpeed * Time.deltaTime * 1000;

			//Quaternion lookDirection = Quaternion.LookRotation(coll.transform.position);
			//Vector3 newDir = Vector3.RotateTowards(gunTransform.forward, coll.transform.position, step, step + 1F);
			//gun.rotation = Vector3.RotateTowards(gun.forward, lookDirection, step);

			//Debug.DrawRay(gunTransform.position, newDir, Color.red);
			//gunTransform.transform.
			//gunTransform.rotation = lookDirection;
			Vector3.RotateTowards(gunTransform.transform.position,coll.transform.position, 10, 10);
			gunTransform.transform.LookAt (coll.transform.position);


			if (!shooting) {
				shooting = true;
				Invoke ("Fire", fireRate);
			}

		}
	}
	public void SelectTower() {
		TowerSelector.selectedTower = this;
		GetComponentInChildren<TowerGround> ().SetActive ();
	}

	void Fire() {
		audioSource.clip = shot;
		audioSource.Play ();
			cannon.Fire ();
			shooting = false;
			}
}
