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
	private bool paused;
	private float deathCooldownRemaining;

	private const float DEATH_COOLDOWN = 1f;

	public bool Dead {
		get { return dead; }
	}

	void Start () {
		flapped = false;
		dead = false;
		Pause();
		animator = GetComponentInChildren<Animator>();
	}

	void Update() {
		bool clicked = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);

		if (paused) {
			if (clicked) {
				UnPause();
			} else {
				return;
			}
		}

		if (dead) {
			deathCooldownRemaining -= Time.deltaTime;

			if (deathCooldownRemaining <= 0 && clicked) {
				Application.LoadLevel(Application.loadedLevel);
			}
		} else if (clicked) {
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
		deathCooldownRemaining = DEATH_COOLDOWN;
	}

	private void Pause() {
		Time.timeScale = 0;
		paused = true;
	}

	private void UnPause() {
		Time.timeScale = 1;
		paused = false;
	}
}
