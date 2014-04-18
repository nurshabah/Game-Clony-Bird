using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {

	public Rigidbody2D relativeTarget;

	void FixedUpdate() {
		float targetSpeed = relativeTarget.velocity.x * 0.75f;
		transform.position = transform.position + (Vector3.right * targetSpeed * Time.deltaTime);
	}
}
