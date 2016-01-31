using UnityEngine;
using System.Collections;

public class EclipseTimer : MonoBehaviour {

    private bool finished = false;
    public float eclipseLength = 10f;
    private float currentTime = 0f;
    private RitualManager ritualManager;
	public Light directionalLight;
    public Light pointMoonLight;
    public GameObject lunarCover;

    void Start()
    {
        ritualManager = GameObject.FindGameObjectWithTag("RitualManager").GetComponent<RitualManager>();
    }
	
	void Update ()
	{
	    directionalLight.intensity = Mathf.Lerp(0.35f, 0.1f, currentTime/eclipseLength);
	    if (currentTime/eclipseLength < 1)
	    {
	        pointMoonLight.intensity = Mathf.Lerp(2f, 0.2f, currentTime/eclipseLength);
	    }
        lunarCover.transform.localPosition = new Vector3(Mathf.Lerp(-0.9f, 0, currentTime/eclipseLength),
	        lunarCover.transform.localPosition.y, lunarCover.transform.localPosition.z);

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