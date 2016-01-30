using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IRit {
    List<GameObject> GetSteps();

    void OnComplete();
}
