using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private Camera camera;
	private TowerSpawner towerSpawner;

	private int money;
	public int startMoney;

	private int totalEnemies;
	private int startEnemies;
	private int currEnemies;

	public int startLifes;
	private int currLifes;

	public int waveCount;
	private int currWave;


	private TowerUI ui;

	public float timeBetweenWaves;
	public float timeBeforeFirstWave;

	private SpawnPoint enemeySpawner;

	private LevelManager levelManager;


	// Use this for initialization
	void Start () {

		currWave = -1;
		
		currEnemies = startEnemies;
		currLifes = startLifes;
		money = startMoney;

		enemeySpawner = FindObjectOfType<SpawnPoint> ();
		ui = FindObjectOfType<TowerUI> ();
		camera = FindObjectOfType<Camera> ();
		towerSpawner = FindObjectOfType<TowerSpawner> ();
		totalEnemies = enemeySpawner.totalEnemies;
		ui.UpdateMoney (money);
		ui.UpdateEnemies (currEnemies);
		ui.UpdateLifes (currLifes);
		ui.UpdateTotalEnemies (totalEnemies);
		Invoke ("StartNextWave", timeBeforeFirstWave);

	}

	void StartNextWave() {
		
		enemeySpawner.SpawnNextWave (++currWave);
		currEnemies = enemeySpawner.GetEnemeyCountPerWave (currWave);
		ui.UpdateEnemies (currEnemies);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit)) {
				string objectHit = hit.transform.gameObject.name;
				if (hit.transform.gameObject.tag == "TowerPlacePosition" && towerSpawner.selectedTower) {
					BuyTower(hit.transform);
				} 
				if (hit.transform.gameObject.tag == "Tower") {
					if (TowerSelector.selectedTower) {
						TowerSelector.selectedTower.BroadcastMessage ("SetActive");
					}
					hit.transform.gameObject.SendMessageUpwards ("SelectTower");
				

				}
				// Do something with the object that was hit by the raycast.
			}
		}
	}

	void BuyTower(Transform t) {
		int cost = towerSpawner.selectedTower.GetComponent<Tower> ().cost;
		if (cost <= money) {
			towerSpawner.SpawnTower (t);
			money -= cost;
			ui.UpdateMoney (money);
		}
	}
	public void UpgradeActiveTower() {
		if (TowerSelector.selectedTower) {
			TowerSelector.selectedTower.Upgrade ();

		}
	}
	public void RemoveActiveTower() {
		if (TowerSelector.selectedTower) {
			money += TowerSelector.selectedTower.cost;
			Destroy (TowerSelector.selectedTower.transform.gameObject);
			TowerSelector.selectedTower = null;
			ui.UpdateMoney (money);

		}
	}

	public void EarnMoney() {
		money += 25;

		currEnemies--;
		totalEnemies--;
		ui.UpdateTotalEnemies (totalEnemies);
		ui.UpdateMoney (money);
		ui.UpdateEnemies (currEnemies);

		if (currEnemies <= 0) {
			if (currWave < waveCount - 1) {
				Invoke ("StartNextWave", timeBetweenWaves);
			} else {
				Debug.Log ("Your won");
			}
		}

	}

	public void EnemieThrough() {
		currEnemies--;
		currLifes--;
		totalEnemies--;
		ui.UpdateTotalEnemies (totalEnemies);
		ui.UpdateEnemies (currEnemies);
		ui.UpdateLifes (currLifes);
		if (currLifes <= 0) {
			Debug.Log ("Game Over");
		}
		if (currEnemies <= 0) {
			if (currWave < waveCount - 1) {
				Invoke ("StartNextWave", timeBetweenWaves);
			} else {
				Debug.Log ("Your won");
				levelManager.LoadNextLevel ();
			}

		}

	}




}
