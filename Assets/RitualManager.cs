using UnityEngine;
using System.Collections;

public class RitualManager : MonoBehaviour
{

    private float successProbability = 0;

	void Start ()
	{
	    successProbability = 1;
	}

    void ContributeProbability(float probability)
    {
        successProbability += Mathf.Clamp(successProbability + probability, 0, 1);
    }


    public void Finish()
    {
        Judge();
    }

    void Judge()
    {
        print("You suck");
    }
}
