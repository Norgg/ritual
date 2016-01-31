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

	void OnGUI() {
        /*
		if (won) {
			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 60, 200, 50), "UPLOAD SUCCESSFUL");
		} else if (lost) {
			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 60, 200, 50), "UPLOAD INTERRUPTED");
		}
		if (won || lost) {
			if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 25, 100, 50), "PRAY AGAIN")) {
				SceneManager.LoadScene(0);
			}
		}
        */
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
                print("You win");
				won = true;
                modemSound.Play();
                heart.AscendHeart();
                //Heart on all tvs

                routerLights.EngulfScreen();
            }
            else
            {
                print("You lose");
				lost = true;
            }
        }
    }
}
