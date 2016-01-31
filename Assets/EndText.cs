using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndText : MonoBehaviour {
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		float brightness = Random.Range(0.3f, 0.5f);
		text.color = new Color (brightness, brightness, brightness, 1.0f);
	}
}
