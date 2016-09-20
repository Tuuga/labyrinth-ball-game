using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float force;

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		var dir = Quaternion.Euler(Vector3.left * 90) * Input.acceleration.normalized;
		dir.z *= -1;
		rb.AddForce(dir * force);
		Debug.DrawRay(transform.position, dir * force, Color.red);
		Debug.DrawRay(transform.position, rb.velocity, Color.green);
	}
}
