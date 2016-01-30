using UnityEngine;
using System.Collections;

public class EclipseTimer : MonoBehaviour {

    private bool finished = false;
    public float eclipseLength = 10f;
    private float currentTime = 0f;
    private RitualManager ritualManager;
	private Light light;

    void Start()
    {
        ritualManager = GameObject.FindGameObjectWithTag("RitualManager").GetComponent<RitualManager>();
		light = GetComponent<Light>();
    }
	
	void Update ()
	{
		light.intensity = (1.0f - currentTime / eclipseLength) * 0.5f + (currentTime / eclipseLength) * 0.10f;

	    if (currentTime > eclipseLength)
	    {
	        if (!finished)
	        {
                finished = true;
                ritualManager.Finish();
	        }
	    }
	    else
	    {
            currentTime += Time.deltaTime;
        }
    }
}