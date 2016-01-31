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

    public AudioSource humSound;
    public AudioSource crackleSound;
    public AudioSource weirdStartupSound;

    private bool heartScreens = false;
    private bool patrickScreens = false;

	void Start ()
	{
	    ritualManager = GameObject.FindGameObjectWithTag("RitualManager").GetComponent<RitualManager>();
	    monitors = GetComponentsInChildren<MonitorScreen>();
        ResetTimerInterval();
	}

    void ResetTimerInterval()
    {
	    currentInterval = Random.Range(intervalMin, intervalMax);
	    currentTimer = 0;
    }

    public void HeartScreens()
    {
        StartCoroutine(StartHeartScreens());
    }

    public void PatrickScreens()
    {
        StartCoroutine(StartPatrickScreens());
    }

    IEnumerator StartPatrickScreens()
    {
        patrickScreens = true;
        weirdStartupSound.Play();
        humSound.Play();
        crackleSound.Stop();
        foreach (MonitorScreen monitor in monitors)
        {
            monitor.SetPatrick();
            yield return new WaitForSeconds(0.25f);
        }
    }

    IEnumerator StartHeartScreens()
    {
        heartScreens = true;
        crackleSound.Play();
        humSound.Stop();

        foreach(MonitorScreen monitor in monitors)
        {
            monitor.SetHeart();
            yield return new WaitForSeconds(0.5f);
        }
    }
	
	void Update ()
	{
	    if (heartScreens || patrickScreens)
	    {
	        return;
	    }
	    currentTimer += Time.deltaTime;
	    if (currentTimer > currentInterval)
	    {
            ResetTimerInterval();
	        monitors[Random.Range(0, monitors.Length)].Toggle();
	    }

	    float favour = CalculateFavour();
	    ritualManager.ContributeProbability(favour);

        //Playing appropriate sound
        int numOn = 0;
        foreach (MonitorScreen screen in monitors)
        {
            if (screen.monitorOn)
            {
                numOn++;
            }
        }

	    if (favour <= 0 && numOn > 0)
	    {
            crackleSound.Stop();
	        if (!humSound.isPlaying)
	        {
	            humSound.Play();
	        }
	    }
	    else if (numOn > 0)
	    {
            humSound.Stop();
	        if (!crackleSound.isPlaying)
	        {
	            crackleSound.Play();
	        }
	    }
	    else
	    {
	        humSound.Stop();
            crackleSound.Stop();
	    }

        humSound.volume = 0.02f * numOn;
    }

    float CalculateFavour()
    {
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
