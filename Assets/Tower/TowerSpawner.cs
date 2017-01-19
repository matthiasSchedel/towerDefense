using UnityEngine;
using System.Collections;

/*
 * Spawns new tower on selected placePosition
 */ 
public class TowerSpawner : MonoBehaviour {
	private GameObject towerParent;

	public GameObject[] towers;
	public GameObject selectedTower;
	// Use this for initialization
	void Start () {
		towerParent = GameObject.Find ("towerParent");
		if (!towerParent) {
			towerParent = new GameObject ("towerParent");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		}

	public void SpawnTower(Transform position) {
		GameObject newTower = (GameObject) Instantiate(selectedTower);
		newTower.transform.position = position.position - new Vector3(0,2.525f,0);
		newTower.transform.parent = towerParent.transform;
	} 

	public void SelectTower(int tower) {
		selectedTower = towers[tower];
	}
}
