using UnityEngine;
using System.Collections;

public class TowerGround : MonoBehaviour {
	private bool active;
	private Material material;
	public Material activeMaterial;
	public Material standardMaterial;
	private MeshRenderer mr;
	// Use this for initialization
	void Start () {
		mr = GetComponent<MeshRenderer> ();
		active = false;
		material = GetComponent<Material> ();
		//normalColor = material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetActive() {
		if (!active) { 
			
			mr.material = activeMaterial;
			active = true;
		} else {
			active = false;
			mr.material = standardMaterial;
		}
	}
}
