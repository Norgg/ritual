using UnityEngine;
using System.Collections;

public class Snappable : MonoBehaviour {

    public string SnapToObjectName;
    public float tolerance;
    private SnappableTo SnapTo;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        SnapTo = GameObject.Find(SnapToObjectName).GetComponent<SnappableTo>();
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
        }
    }

    void OnMouseUp()
    {
        // Finished Dragging, see if there's a snappable point ~nearby~
        // Get the element's current location
        Vector3 position = transform.position;
        float dist = Vector3.Distance(position, SnapTo.snapCenter);
        Debug.Log(dist);
        if (dist < tolerance)
        {
            // Snap into place
            transform.position = SnapTo.snapCenter;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
