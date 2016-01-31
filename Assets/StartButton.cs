using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void StartRitual() {
		SceneManager.LoadScene("ritual");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
