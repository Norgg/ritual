using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

	bool dragged = false;

	float maxForce = 1000.0f;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}

	void OnMouseDown() {
		dragged = true;
	}

	void OnMouseUp() {
		dragged = false;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if (dragged) {
			Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouseWorldPoint.z = 0.0f;
			float dist = (mouseWorldPoint - transform.position).magnitude;
			Vector3 force = (mouseWorldPoint - transform.position) * dist * dist * 1000.0f;
			if (force.magnitude > maxForce) {
				force = force.normalized * maxForce;
			}
			body.AddForce(force);
			if (dist < 10) {
				body.velocity = new Vector2 (0.0f, 0.0f);
			}
		}
	}
}
