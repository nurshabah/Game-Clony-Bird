using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	public Vector3 gravity;
	public float flapSpeed;
	public float forwardSpeed;
	public bool godMode;

	private Animator animator;
	private bool dead;
	private bool flapped;

	void Start () {
		flapped = false;
		dead = false;
		animator = GetComponentInChildren<Animator>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			flapped = true;
		}
	}

	void FixedUpdate () {
		if (dead) {
			return;
		}

		rigidbody2D.AddForce (Vector2.right * forwardSpeed);

		if (flapped) {
			flapped = false;
			rigidbody2D.AddForce (Vector2.up * flapSpeed);
			animator.SetTrigger("Flap");
		}

		float angle = Mathf.Lerp (-90, 90, (rigidbody2D.velocity.y + 3) / 6);
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (godMode) {
			return;
		}

		animator.SetTrigger("Death");
		dead = true;
	}
}
