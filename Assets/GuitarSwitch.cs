using UnityEngine;
using System.Collections;

public class GuitarSwitch : MonoBehaviour
{
    public bool switchOn = false;

    void OnMouseDown()
    {
        if (switchOn)
        {
            switchOn = false;
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else
        {
            switchOn = true;
            transform.eulerAngles = new Vector3(0,0,180);
        }

        GetComponent<AudioSource>().Play();
    }
}
