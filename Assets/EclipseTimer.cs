using UnityEngine;
using System.Collections;

public class EclipseTimer : MonoBehaviour {

    private bool finished = false;
    public float eclipseLength = 10f;
    private float currentTime = 0f;
    private RitualManager ritualManager;

    void Start()
    {
        ritualManager = GameObject.FindGameObjectWithTag("RitualManager").GetComponent<RitualManager>();
    }
	
	void Update ()
	{
	    currentTime += Time.deltaTime;
	    if (!finished && currentTime > eclipseLength)
	    {
	        finished = true;
	        ritualManager.Finish();
            GetComponent<SpriteRenderer>().color = Color.red;
	    }
	}
}