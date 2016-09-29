using UnityEngine;
using System.Collections;

public class BasicInputDone : MonoBehaviour {

	void Start () {
		Input.simulateMouseWithTouches = false;
	}

	void Update() {

		// PC input
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			MovePlayer(Input.mousePosition);
		}

		// Mobile input
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			MovePlayer(Input.touches[0].position);
		}
	}

	void MovePlayer(Vector3 pos) {
		Ray ray = Camera.main.ScreenPointToRay(pos);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit)) {
			transform.position = hit.point;
		}
	}
}
