using UnityEngine;
using System.Collections;

public class MonitorScreen : MonoBehaviour
{
    public bool monitorOn;
    SpriteRenderer spriteRenderer;
    AudioSource tvSwitchSound;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;
        monitorOn = false;
        tvSwitchSound = GetComponent<AudioSource>();
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

    public void OnMouseDown()
    {
        tvSwitchSound.Play();
        Toggle();
    }
}
