using UnityEngine;
using System.Collections;

public class MonitorScreen : MonoBehaviour
{
    public bool monitorOn;
    SpriteRenderer spriteRenderer;
    AudioSource tvSwitchSound;
    new public GameObject light;

    bool heartScreen = false;
    public Sprite heartSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;
        monitorOn = false;
        tvSwitchSound = GetComponent<AudioSource>();
    }

    public void SetHeart()
    {
        heartScreen = true;
        light.gameObject.SetActive(true);
        spriteRenderer.color = Color.white;
        spriteRenderer.sprite = heartSprite;
        transform.localScale = new Vector3(1,1,1) * 0.1f;
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
        if (!heartScreen)
        {
            tvSwitchSound.Play();
            Toggle();
        }
    }
}
