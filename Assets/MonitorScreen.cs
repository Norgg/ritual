using UnityEngine;
using System.Collections;

public class MonitorScreen : MonoBehaviour
{
    public bool monitorOn;
    SpriteRenderer spriteRenderer;
    AudioSource tvSwitchSound;
    new public GameObject light;

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
            light.gameObject.SetActive(false);
            monitorOn = false;
            spriteRenderer.color = Color.black;
        }
        else
        {
            light.gameObject.SetActive(true);
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
