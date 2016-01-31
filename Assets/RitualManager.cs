using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RitualManager : MonoBehaviour {
    private float successProbability = 0;

    public float initialProbability;
    private bool finished = false;
    public bool judged = false;

    public Text debugText;


    //Winning stuff
	bool won = false;
    public AudioSource modemSound;
    public RouterLights routerLights;
    public MonitorManager monitorManager;
    public Heart heart;

	bool lost = false;

	void Start ()
	{
	    successProbability = initialProbability;
	}

    void LateUpdate()
    {
        debugText.text = "Ritual probability: " + successProbability;
        if (finished)
        {
            Judge();
        }

        successProbability = initialProbability;
    }

    public void ContributeProbability(float probability)
    {
        successProbability = Mathf.Clamp(successProbability + probability, 0, 0.9f);
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
                print("You lose");
				lost = true;
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

        SceneManager.LoadScene("end");
    }
}
