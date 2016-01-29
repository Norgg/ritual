using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Pedestal : MonoBehaviour {

    GameObject computers;
    List<GameObject> order;
    List<GameObject> desired;

	// Use this for initialization
	void Start () {
        computers = GameObject.Find("computers");
        order = new List<GameObject>();
        desired = new List<GameObject>()
        {
            GameObject.Find("thing"),
            GameObject.Find("thing2")
        };
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        Debug.Log("Touched Pedestal", otherObject);

        if (order.Count > 0 && order[order.Count - 1] != otherObject)
        {
            order.Add(otherObject);
            Debug.Log("Added to order", otherObject);
        }

        Debug.Log("Starting desired dump");
        foreach (GameObject d in desired)
        {
            Debug.Log(d);
        }
        if (desired.SequenceEqual(order))
        {
            Debug.Log("DESIRED SEQUENCE ACHIEVED");
            computers.SetActive(false);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
