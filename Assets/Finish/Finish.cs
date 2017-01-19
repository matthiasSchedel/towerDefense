using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Attacker") {
			FindObjectOfType<GameController> ().EnemieThrough ();
			Destroy (coll.transform.gameObject);
		}
	}
}
