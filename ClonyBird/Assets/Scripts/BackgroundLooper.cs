using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour {

	public int numPanels;

	public float pipeMaxY;
	public float pipeMinY;

	void Start() {
		GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
		foreach (var pipe in pipes) {
			Vector3 newPosition = pipe.transform.position;
			newPosition.y = GetNextPipeY();
			pipe.transform.position = newPosition;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		float width = ((BoxCollider2D)collider).size.x;
		Vector3 newPosition = collider.transform.position;
		newPosition.x += width * numPanels;

		if (collider.tag == "Pipe") {
			newPosition.y = GetNextPipeY();
		}

		collider.transform.position = newPosition;
	}

	private float GetNextPipeY() {
		return Random.Range(pipeMinY, pipeMaxY);
	}
}
