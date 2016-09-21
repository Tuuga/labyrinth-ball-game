using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	void Update() {

		if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
			TouchObstacle(Input.touches[0].position);
		}

		if (Input.GetMouseButtonDown(0)) {
			TouchObstacle(Input.mousePosition);
		}
	}

	void TouchObstacle(Vector3 rayVector) {
		Ray ray = Camera.main.ScreenPointToRay(rayVector);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit)) {
			var obstacle = hit.transform.GetComponent<ObstacleState>();

			if (obstacle == null || obstacle.IsRunning())
				return;

			StartCoroutine(obstacle.Rotate());
		}
	}
}
