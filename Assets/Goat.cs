using UnityEngine;
using System.Collections;

public class Goat : MonoBehaviour
{

    public Transform goatJaw;
    public AudioSource furbySound;

    public SpriteRenderer goatEyeRenderer;
    public GameObject goatEyeLight;
    bool goatFreakout = false;

	void Update () {
	    if (goatFreakout)
	    {
	        goatJaw.localEulerAngles = new Vector3(goatJaw.localEulerAngles.x, goatJaw.localEulerAngles.y, Random.value * 4);
	    }
	
	}

    public void GoatFreakout()
    {
        goatFreakout = true;
        furbySound.Play();
        goatEyeRenderer.color = Color.red;
        goatEyeLight.SetActive(true);
    }
}
