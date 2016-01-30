using UnityEngine;
using System.Collections;

public class RitualManager : MonoBehaviour {
    private float successProbability = 0;
    public float initialProbabilityRange;

	void Start ()
	{
	    successProbability = Random.value* initialProbabilityRange;
	}

    public void ContributeProbability(float probability)
    {
        successProbability += Mathf.Clamp(successProbability + probability, 0, 0.9f);
    }


    public void Finish()
    {
        Judge();
    }

    void Judge()
    {
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
