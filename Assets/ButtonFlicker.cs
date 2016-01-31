using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonFlicker : MonoBehaviour {
	Button button;
	Text text;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button>();
		text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		ColorBlock colors = button.colors;

		float brightness = Random.Range(0.3f, 0.5f);
		colors.normalColor = new Color (brightness, brightness, brightness, 1.0f);
		brightness = Random.Range(0.0f, 0.2f);
		colors.highlightedColor = new Color (brightness, brightness, brightness, 1.0f);
		button.colors = colors;

		brightness = Random.Range(0.6f, 0.7f);
		text.color = new Color (brightness, brightness, brightness, 1.0f);
	}
}
