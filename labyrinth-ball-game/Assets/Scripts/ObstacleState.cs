using UnityEngine;
using System.Collections;

public class ObstacleState : MonoBehaviour {
	bool turned;
	bool running;
	public float rotationAngle;
	public float secToComplete;

	public IEnumerator Rotate () {
		running = true;

		float timePassed = 0;

		while (timePassed < secToComplete) {
			timePassed += Time.deltaTime;
			float angle = rotationAngle / secToComplete;
			if (turned)
				transform.Rotate(Vector3.up * angle * Time.deltaTime);
			else
				transform.Rotate(Vector3.up * -angle * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}

		float finalYRot = Mathf.Round(transform.rotation.eulerAngles.y);
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, finalYRot, transform.rotation.eulerAngles.z);

		turned = !turned;
		running = false;
	}

	public bool IsRunning () {
		return running;
	}
}
