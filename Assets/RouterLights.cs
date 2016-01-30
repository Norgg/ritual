using UnityEngine;
using System.Collections;

public class RouterLights : MonoBehaviour {
	new GameObject light;
    public bool badOmen = false;
    public bool goodOmen = true;
	RitualManager ritual;

	// Use this for initialization
	void Start () {
		light = transform.FindChild("light").gameObject;
		ritual = GameObject.Find("RitualManager").GetComponent<RitualManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (badOmen)
	    {
	        light.GetComponent<Light>().color = Color.red;
			ritual.ContributeProbability(-0.1f);
	    }
        else
	    {
	        light.GetComponent<Light>().color = Color.green;
	    }


	    if (goodOmen)
	    {
	        light.SetActive(true);
			ritual.ContributeProbability(0.1f);
	    }
		else if (Random.value < 0.1) {
			light.SetActive(!light.activeSelf);
		}
	}
}
