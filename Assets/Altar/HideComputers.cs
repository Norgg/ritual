using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HideComputers : AltarOrder {
	public HideComputers()
    {
        steps = new List<GameObject>() { GameObject.Find("thing"),  GameObject.Find("thing2") };
		contribution = 0.05f;
    }
}
