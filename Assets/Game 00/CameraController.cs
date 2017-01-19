using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private float horizontalSpeed = 40.0f;
	private float verticalSpeed = 40.0f;

	// Use this for initialization
	void Start () {
	
	}


	void Update () {

		// If Right Button is clicked Camera will move.
		if (Input.GetMouseButton(0)) {
			float h = horizontalSpeed * Input.GetAxis ("Mouse Y");
			float v = verticalSpeed * Input.GetAxis ("Mouse X");
			transform.Translate(v,h,0);
		}

	}

}
