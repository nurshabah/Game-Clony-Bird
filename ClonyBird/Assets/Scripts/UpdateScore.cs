using UnityEngine;
using System.Collections;

public class UpdateScore : MonoBehaviour {

	public Scorer scorer;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			scorer.AddPoint();
		}
	}
}
