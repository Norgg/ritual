using UnityEngine;
using System.Collections;

public class RouterAltar : MonoBehaviour
{

    public RouterLights routerLights;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Heart")
        {
            routerLights.goodOmen = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Heart")
        {
            routerLights.goodOmen = false;
        }
    }
}
