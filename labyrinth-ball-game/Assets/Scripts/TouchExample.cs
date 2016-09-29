using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TouchExample : MonoBehaviour {

	GameObject[] touchVisuals;

	void Start () {
		touchVisuals = GameObject.FindGameObjectsWithTag("TouchVisual");
	}

	void Update () {

		for (int i = 0; i < touchVisuals.Length; i++) {
			// If touch just began, moved or stationary
			// Show touch position and write the position on text UI
			if (Input.touchCount > i) {
				touchVisuals[i].SetActive(true);
				touchVisuals[i].transform.position = Input.touches[i].position;
				touchVisuals[i].GetComponentInChildren<Text>().text = "" + Input.touches[i].position;
			} else if (touchVisuals[i].activeSelf) {
				touchVisuals[i].SetActive(false);
			}
		}
	}
}
