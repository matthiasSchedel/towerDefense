using UnityEngine;
using System.Collections;

public class TowerGun : MonoBehaviour {
	private Transform cannonPosition;
	private GameObject cannonBallParent;
	public GameObject cannonBall;


	// Use this for initialization
	void Start () {
		cannonPosition = FindObjectOfType<CannonBallSpawnPoint> ().GetComponent<Transform> ();
		cannonBallParent = GameObject.Find ("cannonBallParent");
		if (!cannonBallParent) {
			cannonBallParent = new GameObject ("cannonBallParent");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Fire() {
		GameObject newCannonBall = (GameObject)Instantiate (cannonBall, cannonPosition.position, cannonPosition.rotation);
		newCannonBall.GetComponent<Rigidbody> ().velocity = transform.forward * 50;
		newCannonBall.transform.parent = cannonBallParent.transform;
	}
}
