using UnityEngine;
using System.Collections;

public class RouterLights : MonoBehaviour {
	GameObject light;
    public bool badOmen = false;
    public bool goodOmen = true;

	// Use this for initialization
	void Start () {
		light = transform.FindChild("light").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    if (badOmen)
	    {
	        light.GetComponent<Light>().color = Color.red;
	    }
        else
	    {
	        light.GetComponent<Light>().color = Color.green;
	    }


	    if (goodOmen)
	    {
	        light.SetActive(true);
	    }
		else if (Random.value < 0.1) {
			light.SetActive(!light.activeSelf);
		}
	}
}
