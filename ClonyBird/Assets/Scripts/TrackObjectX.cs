using UnityEngine;
using System.Collections;

public class TrackObjectX : MonoBehaviour {

	public Transform target;

	private float offset;

	void Start() {
		offset = transform.position.x - target.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			Vector3 newPosition = transform.position;
			newPosition.x = target.transform.position.x + offset;
			transform.position = newPosition;
		}
	}
}
