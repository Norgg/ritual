using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AltarController : MonoBehaviour {
    List<GameObject> order;
    List<AltarOrder> valid;
	RitualManager ritual;
	float contribution = 0.0f;

	// Use this for initialization
	void Start () {
		ritual = GameObject.Find("RitualManager").GetComponent<RitualManager>();
        order = new List<GameObject>();
        valid = new List<AltarOrder>() {
            new ShowComputers(),
            new HideComputers()
        };
	}
	
	// Update is called once per frame
	void Update () {
		ritual.ContributeProbability(contribution);
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        Debug.Log("Touched Pedestal", otherObject);

        if (order.Count == 0 || order.Last() != otherObject)
        {
            order.Add(otherObject);
            Debug.Log("Added to order", otherObject);
        }

        foreach (AltarOrder altarOrder in valid) {
			if (altarOrder.GetSteps().SequenceEqual(order.Skip(order.Count - 3).Take(2)))
            {
                Debug.Log("DESIRED SEQUENCE ACHIEVED");
                contribution += altarOrder.contribution;

                // Reset ready for new sequence
                order = new List<GameObject>();
                break;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
