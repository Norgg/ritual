using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HideComputers : IRit {
    GameObject computers;

    public HideComputers()
    {
        computers = GameObject.Find("computers");
    }

    public List<GameObject> GetSteps()
    {
        return new List<GameObject>()
        {
            GameObject.Find("thing"),
            GameObject.Find("thing2")
        };
    }

    public void OnComplete()
    {
        GameObject computers = GameObject.Find("computers");
        computers.SetActive(false);
    }
}
