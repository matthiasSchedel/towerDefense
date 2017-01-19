using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public GameObject[] enemyPrefab;
	public int[] attackerCountPerWave;
	public float timeBetweenSpawns;

	private int enemiesToSpawn;
	private GameObject enemy;

	public int totalEnemies;

	private GameObject enemyParent;

	// Use this for initialization
	void Start () {
		enemyParent = GameObject.Find ("EnemyParent");
		if (!enemyParent) {
			enemyParent = new GameObject ("EnemyParent");
		}

		totalEnemies = 0;
		foreach (int i in attackerCountPerWave) {
			totalEnemies += i;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnNextWave(int wave) {
		enemiesToSpawn = attackerCountPerWave [wave];
		enemy = enemyPrefab [wave];
		SpawnEnemy ();
	
	}

	void SpawnEnemy() {
		GameObject newEnemy = (GameObject)Instantiate (enemy,transform.position,transform.rotation);
		newEnemy.transform.parent = enemyParent.transform;
		if (--enemiesToSpawn > 0) {
			Invoke ("SpawnEnemy", timeBetweenSpawns);
		}
	}

	public int GetEnemeyCountPerWave(int wave) {
		return attackerCountPerWave [wave];
	}

		
}
