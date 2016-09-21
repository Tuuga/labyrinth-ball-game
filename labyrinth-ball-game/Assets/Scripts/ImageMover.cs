using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageMover : MonoBehaviour {

	public GameObject image;

	void Update () {
		if (Input.touchCount > 0)
			image.transform.position = Input.touches[0].position;
	}
}
