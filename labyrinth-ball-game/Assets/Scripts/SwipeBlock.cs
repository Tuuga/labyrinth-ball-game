using UnityEngine;
using System.Collections;

public class SwipeBlock : MonoBehaviour {

	public float stepDistance;

	void Update () {

		if (Gestures.Swipe.currentDirection == Gestures.Swipe.Direction.Up) {
			transform.position += Vector3.forward * stepDistance;
		}

		if (Gestures.Swipe.currentDirection == Gestures.Swipe.Direction.Down) {
			transform.position += Vector3.back * stepDistance;
		}

		if (Gestures.Swipe.currentDirection == Gestures.Swipe.Direction.Left) {
			transform.position += Vector3.left * stepDistance;
		}

		if (Gestures.Swipe.currentDirection == Gestures.Swipe.Direction.Right) {
			transform.position += Vector3.right * stepDistance;
		}
	}
}
