using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AltarOrder {
	protected List<GameObject> steps;
	public float contribution = 0.0f;

	public List<GameObject> GetSteps() {
		return steps;
	}
}
