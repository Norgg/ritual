using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HideComputers : AltarOrder {
	public HideComputers()
    {
        steps = new List<GameObject>() { GameObject.Find("thing"),  GameObject.Find("thing2") };
    }

    override public void OnComplete()
    {
		Debug.Log("hide things");
		//ritual.doSomething();
    }
}
