using UnityEngine;
using System.Collections;

public class Snappable : MonoBehaviour {

    public float tolerance;
    [HideInInspector]
    public SnappableTo SnapTo;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (rb.constraints == RigidbodyConstraints2D.FreezeAll)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			if (SnapTo != null) {
				SnapTo.currentlySnapped = null;
			}
        }
    }

    void OnMouseUp()
    {
        if (SnapTo)
        {
            // SnapTo will be set by the trigger on the SnappableTo object
            Vector3 position = transform.position;
            float dist = Vector3.Distance(position, SnapTo.snapCenter);
            if (dist < tolerance)
            {
                // Snap into place
                transform.position = SnapTo.snapCenter;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                SnapTo.currentlySnapped = gameObject;
            }
        }
    }
}
