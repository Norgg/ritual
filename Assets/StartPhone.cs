using UnityEngine;
using System.Collections;

public class StartPhone : MonoBehaviour {
	bool ringing = false;
	public GameObject phoneTop;
	AudioSource ringSound;
	private Vector3 phoneTopOrigin;

	// Use this for initialization
	void Start () {
		ringSound = GetComponent<AudioSource>();
		phoneTopOrigin = phoneTop.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.value < 0.0001) {
			ringing = true;
		}

		if (ringing) {
			Vector3 phonePeturb = Random.insideUnitCircle * 0.05f;
			phoneTop.transform.position = phoneTopOrigin + phonePeturb;

			if (!ringSound.isPlaying)
			{
				ringSound.Play();
			}

			if (Random.value < 0.001) {
				ringing = false;
			}
		}
	
	}
}
