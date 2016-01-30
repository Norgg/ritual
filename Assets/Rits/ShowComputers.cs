using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowComputers : IRit {
    GameObject computers;

    public ShowComputers()
    {
        computers = GameObject.Find("computers");
    }

    public List<GameObject> GetSteps()
    {
        return new List<GameObject>()
        {
            GameObject.Find("thing2"),
            GameObject.Find("thing")
        };
    }

    public void OnComplete()
    {
        computers.SetActive(true);
    }
}
