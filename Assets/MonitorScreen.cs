using UnityEngine;
using System.Collections;

public class MonitorScreen : MonoBehaviour
{
    public bool monitorOn;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;
        monitorOn = false;
    }

    public void Toggle()
    {
        if (monitorOn)
        {
            monitorOn = false;
            spriteRenderer.color = Color.black;
        }
        else
        {
            monitorOn = true;
            spriteRenderer.color = Color.white;
        }
    }
}
