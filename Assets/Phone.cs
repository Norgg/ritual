using UnityEngine;
using System.Collections;

public class Phone : MonoBehaviour
{

    public bool phoneRinging = false;
    public GameObject phoneTop;
    AudioSource ringSound;
    RitualManager ritualManager;

    private Vector3 phoneTopOrigin;

    void Start()
    {
        ringSound = GetComponent<AudioSource>();
        ritualManager = GameObject.FindGameObjectWithTag("RitualManager").GetComponent<RitualManager>();
        phoneTopOrigin = phoneTop.transform.position;
    }

	void Update () {
	    if (phoneRinging)
	    {
            ritualManager.ContributeProbability(0.1f);

            Vector3 phonePeturb = Random.insideUnitCircle * 0.05f;
            phoneTop.transform.position = phoneTopOrigin + phonePeturb;

            if (!ringSound.isPlaying)
            {
                ringSound.Play();
            }
        }
        else
	    {
	        ringSound.Stop();
	    }
    }
}
