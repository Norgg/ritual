using UnityEngine;
using System.Collections;

public class SnappableTo : MonoBehaviour {
    GameObject favoured;
	RitualManager ritual;
	WifFiSignal wifi;

    public Vector3 SnapOffset;
    public GameObject currentlySnapped;

    [HideInInspector]
    public Vector3 snapCenter;

    void Start()
    {
        snapCenter = GetComponent<Collider2D>().bounds.center + SnapOffset;
		GameObject[] masks = GameObject.FindGameObjectsWithTag("Mask");
		favoured = masks[Random.Range (0, masks.Length)];
		ritual = GameObject.FindGameObjectWithTag("RitualManager").GetComponent<RitualManager>();
		wifi = GameObject.Find("WifiSignal").GetComponent<WifFiSignal> ();
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
        // if favoured present
        if (currentlySnapped && favoured == currentlySnapped) {
            ritual.ContributeProbability(0.1f);
			wifi.AddSignal();
        }
    }
}
