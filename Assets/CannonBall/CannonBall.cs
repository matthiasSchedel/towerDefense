using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {
	private AudioSource audioSource;
	public AudioClip hit;
	public AudioClip shot;
	private Rigidbody myRigidBody;
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.transform.tag == "Attacker") {
			Attacker a = coll.transform.GetComponent<Attacker> ();
			if (!a) {
				a = coll.transform.GetComponentInParent<Attacker> ();
			}
			a.Hit ();

		}
		DestroyObject (transform.gameObject);
	}
}
