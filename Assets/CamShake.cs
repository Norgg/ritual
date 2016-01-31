using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour {
	float shakeTime = 0.0f;
	Camera cam;
    public AudioSource rumbleSound;

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
        rumbleSound.Play();
	}
	
	// Update is called once per frame
	void Update () {
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
