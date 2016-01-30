using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AltarOrder {
	RitualManager ritual;
	protected List<GameObject> steps;

	public void Awake() {
		ritual = GameObject.Find("RitualManager").GetComponent<RitualManager>();
	}

	public List<GameObject> GetSteps() {
		return steps;
	}

	public abstract void OnComplete();
}
