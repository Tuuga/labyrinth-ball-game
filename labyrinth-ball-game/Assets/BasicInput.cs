using UnityEngine;
using System.Collections;

public class BasicInput : MonoBehaviour {

	void Start () {
		Input.simulateMouseWithTouches = false;
	}

	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)) {
				transform.position = hit.point;
			}
		}
	}
}
