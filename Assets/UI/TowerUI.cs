using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour {
	private Text money;
	private Text lifesRemaining;
	private Text enemiesRemaining;
	private Text totalEnemiesRemaining;
	private Button[] newTower;
	public Material activeButton;
	public Material inactiveButton;
	// Use this for initialization

	void Awake() {
		//use in awake !!
		money = GetComponentsInChildren<Text> () [0];
		lifesRemaining = GetComponentsInChildren<Text> () [1];
		enemiesRemaining = GetComponentsInChildren<Text> () [2];
		totalEnemiesRemaining = GetComponentsInChildren<Text> () [3];
		Button[] towers = GetComponentsInChildren<Button> ();
		 newTower = new Button[towers.Length - 2];
		for (int i = 0; i < towers.Length; i++) {
			if (i >= 2) {
				newTower [i - 2] = towers [i];
			}
		}
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateMoney(int newMoney) {
		money.text = "Your money: " + newMoney;
	}

	public void UpdateEnemies(int enemies) {
		enemiesRemaining.text = "Enemies remaining: " + enemies.ToString ();
	}

	public void UpdateTotalEnemies(int enemies) {
		totalEnemiesRemaining.text = "Total enemies remaining: " + enemies.ToString ();
	}

	public void UpdateLifes(int lifes) {
		lifesRemaining.text = "Lifes remaining: " + lifes.ToString ();
	}

	public void SetButton(int bnr) {
		foreach (Button b in newTower) {
			b.GetComponent<Image> ().material = inactiveButton;
		}
		newTower [bnr].GetComponent<Image> ().material = activeButton;
	}

}
