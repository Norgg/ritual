using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RitualManager : MonoBehaviour {
    private float successProbability = 0;

    public float initialProbability;
    private bool finished = false;
    public bool judged = false;

    //Winning stuff
	bool won = false;
    public AudioSource modemSound;
    public RouterLights routerLights;
    public MonitorManager monitorManager;
    public Heart heart;

    //Losing stuff
    public Goat goat;
    public CamShake shake;
    public GameObject blackScreen;

	void Start ()
	{
	    successProbability = initialProbability;
	}

    void LateUpdate()
    {
        if (finished)
        {
            Judge();
        }

        successProbability = initialProbability;
    }

    public void ContributeProbability(float probability)
    {
        successProbability = Mathf.Clamp(successProbability + probability, 0, 1);
    }

    public void Finish()
    {
        finished = true;
    }

    void Judge()
    {
        if (!judged)
        {
            judged = true;
            if (Random.value <= successProbability)
            {
                StartCoroutine(WinEnd());
            }
            else
            {
                StartCoroutine(LoseEnd());
            }
        }
    }

    IEnumerator WinEnd()
    {
        modemSound.Play();
        yield return new WaitForSeconds(2);
        heart.AscendHeart();
        yield return new WaitForSeconds(8);
        monitorManager.HeartScreens();
        yield return new WaitForSeconds(7);
        routerLights.EngulfScreen();
        yield return new WaitForSeconds(26);

        SceneManager.LoadScene("goodend");
    }

    IEnumerator LoseEnd()
    {
        goat.GoatFreakout();
        yield return new WaitForSeconds(4);
        shake.Shake(100);
        yield return new WaitForSeconds(4);
        monitorManager.PatrickScreens();
        yield return new WaitForSeconds(4);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("badend");
    }
}
