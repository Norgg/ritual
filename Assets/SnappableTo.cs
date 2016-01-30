using UnityEngine;
using System.Collections;

public class SnappableTo : MonoBehaviour {
    public GameObject Favoured;
    public Vector3 SnapOffset;

    [HideInInspector]
    public GameObject currentlySnapped;
    [HideInInspector]
    public Vector3 snapCenter;

    void Start()
    {
        snapCenter = GetComponent<SpriteRenderer>().bounds.center + SnapOffset;
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Mask")
        {
            Snappable otherSnappable = other.GetComponent<Snappable>();
            otherSnappable.SnapTo = this;
        }
    }

    void Update()
    {
        RitualManager rm = GameObject.FindGameObjectWithTag("RitualManager").GetComponent<RitualManager>();
        // if favoured present
        if (currentlySnapped && Favoured == currentlySnapped) {
            rm.ContributeProbability(0.1f);
        }
    }
}
