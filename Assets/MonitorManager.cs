using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonitorManager : MonoBehaviour
{

    public float intervalMin = 3;
    public float intervalMax = 10;

    private float currentInterval;
    private float currentTimer;

    private MonitorScreen[] monitors;
    RitualManager ritualManager;

	void Start ()
	{
	    ritualManager = GameObject.FindGameObjectWithTag("RitualManager").GetComponent<RitualManager>();
	    monitors = GetComponentsInChildren<MonitorScreen>();
        ResetTimerInterval();
	}

    void ResetTimerInterval()
    {
	    currentInterval = Random.Range(2, 5);
	    currentTimer = 0;
    }
	
	void Update ()
	{
	    currentTimer += Time.deltaTime;
	    if (currentTimer > currentInterval)
	    {
            ResetTimerInterval();
	        monitors[Random.Range(0, monitors.Length)].Toggle();
	    }

	    ritualManager.ContributeProbability(CalculateFavour());
	}

    float CalculateFavour()
    {
        //Should check whether hum is on or off in here too
        int numOn = 0;
        foreach (MonitorScreen screen in monitors)
        {
            if (screen.monitorOn)
            {
                numOn++;
            }
        }

        if (monitors[0].monitorOn && monitors[monitors.Length - 1].monitorOn)
        {
            return -0.05f;
        }
        else if (monitors[0].monitorOn)
        {
            if (numOn%2 == 0)
            {
                return 0.05f;
            }

            return 0;
        }
        else
        {
            if (numOn%2 != 0)
            {
                return 0.05f;
            }

            return 0;
        }
    }
}
