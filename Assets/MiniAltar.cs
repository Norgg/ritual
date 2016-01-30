using UnityEngine;
using System.Collections;

public class MiniAltar : MonoBehaviour
{

    public RouterLights routerLights;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Heart")
        {
            routerLights.badOmen = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Heart")
        {
            routerLights.badOmen = false;
        }
    }
}
