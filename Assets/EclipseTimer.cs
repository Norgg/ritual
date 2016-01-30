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
	    currentTime += Time.deltaTime;
		light.intensity = 1.0f - currentTime / eclipseLength;
	    if (!finished && currentTime > eclipseLength)
	    {
	        finished = true;
	        ritualManager.Finish();
            GetComponent<SpriteRenderer>().color = Color.red;
	    }
	}
}