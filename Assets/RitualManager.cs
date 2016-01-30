using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RitualManager : MonoBehaviour
{

    private bool finished = false;
    private float successProbability = 0;
    public float initialProbabilityRange;
    public bool judged = false;

    public Text debugText;

	void Start ()
	{
	    successProbability = Random.value* initialProbabilityRange;
	}

    void LateUpdate()
    {
        debugText.text = "Ritual probability: " + successProbability;
        if (finished)
        {
            Judge();
        }

        successProbability = 0;
    }

    public void ContributeProbability(float probability)
    {
        successProbability += Mathf.Clamp(successProbability + probability, 0, 0.9f);
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
            if (Random.value < initialProbabilityRange)
            {
                print("You win");
            }
            else
            {
                print("You lose");
            }
        }
    }
}
