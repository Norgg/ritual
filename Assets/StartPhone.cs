using UnityEngine;
using System.Collections;

public class StartPhone : MonoBehaviour {
	bool ringing = false;
	public GameObject phoneTop;
	AudioSource ringSound;
	AudioSource answerSound;
	private Vector3 phoneTopOrigin;

	// Use this for initialization
	void Start () {
		ringSound = GetComponents<AudioSource>()[0];
		answerSound = GetComponents<AudioSource>()[1];
		phoneTopOrigin = phoneTop.transform.position;
	}

	public void OnMouseDown() {
		if (ringing) {
			ringing = false;
			ringSound.Stop();
			answerSound.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.value < 0.0001 && !answerSound.isPlaying) {
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
