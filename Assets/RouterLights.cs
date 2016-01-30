using UnityEngine;
using System.Collections;

public class RouterLights : MonoBehaviour {
	GameObject light;

	// Use this for initialization
	void Start () {
		light = transform.FindChild("light").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.value < 0.01) {
			light.SetActive(!light.activeSelf);
		}
	}
}
