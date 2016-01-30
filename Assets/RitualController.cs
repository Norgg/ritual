using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RitualController : MonoBehaviour {

    GameObject computers;
    List<GameObject> order;
    List<IRit> valid;

	// Use this for initialization
	void Start () {
        computers = GameObject.Find("computers");
        order = new List<GameObject>();
        valid = new List<IRit>() {
            new ShowComputers(),
            new HideComputers()
        };
	}
	
	// Update is called once per frame
	void Update () {
	
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

        foreach (IRit rit in valid) {
            if (rit.GetSteps().SequenceEqual(order))
            {
                Debug.Log("DESIRED SEQUENCE ACHIEVED");
                rit.OnComplete();

                // Reset ready for new sequence
                order = new List<GameObject>();
                break;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        
    }

    public void ResetState()
    {
        Debug.Log("Resetting State");
        computers.SetActive(true);
        order = new List<GameObject>();
    }
}
