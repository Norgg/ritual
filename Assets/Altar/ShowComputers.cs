using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowComputers : AltarOrder {
	public ShowComputers()
    {
		steps = new List<GameObject>() { GameObject.Find("thing2"), GameObject.Find("thing") };
    }

    override public void OnComplete()
    {
		ritual.ContributeProbability(0.1f);
    }
}
