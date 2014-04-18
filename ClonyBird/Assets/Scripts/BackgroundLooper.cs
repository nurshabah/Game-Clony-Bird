using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour {

	public int numPanels;

	void OnTriggerEnter2D(Collider2D collider) {
		float width = ((BoxCollider2D)collider).size.x;
		Vector3 newPosition = collider.transform.position;
		newPosition.x += width * (numPanels - 1);
		collider.transform.position = newPosition;
	}
}
