using UnityEngine;
using System.Collections;

public class MonitorScreen : MonoBehaviour
{
    public bool monitorOn;
    SpriteRenderer spriteRenderer;
    AudioSource tvSwitchSound;
    new public GameObject light;

    bool heartScreen = false;
    bool patrickScreen = false;

    public Sprite heartSprite;
    public Sprite patrickSprite;

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

    public void SetPatrick()
    {
        patrickScreen = true;
        light.gameObject.SetActive(true);
        spriteRenderer.color = Color.white;
        spriteRenderer.sprite = patrickSprite;
        transform.localScale = new Vector3(1,1,1) * 0.05f;
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
        if (!heartScreen && !patrickScreen)
        {
            tvSwitchSound.Play();
            Toggle();
        }
    }
}
