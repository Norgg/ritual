using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundClick : MonoBehaviour {

    private AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}

    void OnMouseDown()
    {
        audio.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
