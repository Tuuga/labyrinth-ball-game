using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float force;
	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		// Direction based on phones orientation
		var dir = Input.acceleration.normalized;
		// Rotate direction around x axis
		dir = Quaternion.Euler(new Vector3(-1, 0, 0) * 90) * dir;
		// Flip z axis
		dir.z *= -1;
		rb.AddForce(dir * force);

		Debug.DrawRay(transform.position, dir * force, Color.red);
		Debug.DrawRay(transform.position, rb.velocity, Color.green);
	}
}
