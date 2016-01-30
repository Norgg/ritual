using UnityEngine;
using System.Collections;

public class SnappableTo : MonoBehaviour {
    GameObject favoured;
    public Vector3 SnapOffset;

    [HideInInspector]
    public GameObject currentlySnapped;
    [HideInInspector]
    public Vector3 snapCenter;

    void Start()
    {
        snapCenter = GetComponent<Collider2D>().bounds.center + SnapOffset;
		GameObject[] masks = GameObject.FindGameObjectsWithTag("Mask");
		favoured = masks[Random.Range (0, masks.Length)];
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
        if (currentlySnapped && favoured == currentlySnapped) {
            rm.ContributeProbability(0.1f);
        }
    }
}
