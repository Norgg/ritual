using UnityEngine;
using System.Collections;

public class SnappableTo : MonoBehaviour {
    public Vector3 SnapOffset;
    [HideInInspector]
    public Vector3 snapCenter;

    void Start()
    {
        snapCenter = GetComponent<SpriteRenderer>().bounds.center + SnapOffset;
    }
}
