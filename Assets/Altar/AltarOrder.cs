using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AltarOrder {
	protected RitualManager ritual;
	protected List<GameObject> steps;

	public AltarOrder() {
		ritual = GameObject.Find("RitualManager").GetComponent<RitualManager>();
	}

	public List<GameObject> GetSteps() {
		return steps;
	}

	public abstract void OnComplete();
}
