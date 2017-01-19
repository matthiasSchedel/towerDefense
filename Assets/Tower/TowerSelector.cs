using UnityEngine;
using System.Collections;

/*
 * Select towers that are already placed
 */
public class TowerSelector : MonoBehaviour {
	public static Tower selectedTower;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnMouseDown() {
		//selectedTower = GetComponentInParent<Tower> ();
	}

}
