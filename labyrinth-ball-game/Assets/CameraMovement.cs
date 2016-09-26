using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float zoomSpeed;

	void Update () {
		transform.position += Vector3.up * zoomSpeed * Gestures.Pinch.normalizedDelta;
	}
}
