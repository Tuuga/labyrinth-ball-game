using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	void Update () {

		if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
			TouchObstacle(Input.touches[0].position);
		}

		if (Input.GetMouseButtonDown(0)) {
			TouchObstacle(Input.mousePosition);
		}

	}

	void TouchObstacle (Vector3 v) {
		Ray ray = Camera.main.ScreenPointToRay(v);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit)) {
			var state = hit.transform.GetComponent<ObstacleState>();
			Animator anim = hit.transform.GetComponent<Animator>();

			if (anim != null) {
				if (state.currentState == ObstacleState.State.c) {
					state.currentState = ObstacleState.State.cc;
					anim.Play("cc90");
				} else {
					state.currentState = ObstacleState.State.c;
					anim.Play("c90");
				}
			}
		}
	}
}
