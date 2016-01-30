using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour {
	float shakeTime = 0.0f;
	Camera cam;

	Vector3 startPos;
	float startSize;

	// Use this for initialization
	void Start() {
		cam = GetComponent<Camera>();
		startPos = transform.position;
		startSize = cam.orthographicSize;
	}

	public void Shake(float time) {
		shakeTime = time;	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (shakeTime);
		if (shakeTime > 0.0f) {
			transform.position = startPos + Random.insideUnitSphere * 0.1f;
			cam.orthographicSize = startSize * 0.95f;
			shakeTime -= Time.deltaTime;
			if (shakeTime <= 0.0f) {
				transform.position = startPos;
				cam.orthographicSize = startSize;
			}
		}
	}
}
