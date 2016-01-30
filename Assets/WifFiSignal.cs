using UnityEngine;
using System.Collections;

public class WifFiSignal : MonoBehaviour
{

    public float intervalMin;
    public float intervalMax;
    private float currentTime = 0;
    private float currentInterval;

    public Sprite[] signalSprites;
    SpriteRenderer spriteRenderer;

	void Start ()
	{
	    spriteRenderer = GetComponent<SpriteRenderer>();
	    currentInterval = Random.Range(intervalMin, intervalMax);
	}
	
	void Update ()
	{
	    currentTime += Time.deltaTime;
	    if (currentTime > currentInterval)
	    {
	        currentTime = 0;
	        ChangeWifiSignal();
	    }
	}

    void ChangeWifiSignal()
    {
        spriteRenderer.sprite = signalSprites[Random.Range(0, signalSprites.Length)];
    }
}
