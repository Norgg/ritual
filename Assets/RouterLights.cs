using UnityEngine;
using System.Collections;

public class RouterLights : MonoBehaviour {
	public GameObject light;
    public SpriteRenderer floodLight;

    public bool badOmen = false;
    public bool goodOmen = true;
	RitualManager ritual;

    private bool routerFinished = false;

	// Use this for initialization
	void Start () {
		light = transform.FindChild("light").gameObject;
		ritual = GameObject.Find("RitualManager").GetComponent<RitualManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (routerFinished)
	    {
	        return;
	    }

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

    public void EngulfScreen()
    {
        StartCoroutine(EngulfCoroutine());
    }

    IEnumerator EngulfCoroutine()
    {
        routerFinished = true;
        light.SetActive(true);
        Light lightComp = light.GetComponent<Light>();
        lightComp.color = Color.green;

        float initialWait = 15;
        float waitSoFar = 0;
        float timeStep = 0.02f;

        while (waitSoFar < initialWait)
        {
            waitSoFar += timeStep;
            yield return new WaitForSeconds(timeStep);
        }

        float engulfTime = 15;
        float engulfTimer = 0;
        lightComp.intensity = 8;
        while (engulfTimer < engulfTime)
        {
            engulfTimer += timeStep;
            lightComp.range = Mathf.Lerp(0.7f, 4, engulfTimer/engulfTime);
            floodLight.color = new Color(floodLight.color.r, floodLight.color.g, floodLight.color.b, Mathf.Lerp(0,1, engulfTimer / engulfTime));
            yield return new WaitForSeconds(timeStep);
        }

    }
}
