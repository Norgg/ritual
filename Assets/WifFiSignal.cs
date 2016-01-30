using UnityEngine;
using System.Collections;

public class WifFiSignal : MonoBehaviour
{
    public Sprite[] signalSprites;
    SpriteRenderer spriteRenderer;

	int signal;

	void Start ()
	{
	    spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void LateUpdate ()
	{
		spriteRenderer.sprite = signalSprites[Mathf.Min(signal, 3)];
		signal = 0;
	}

    public void AddSignal()
    {
		signal += 1;
    }
}
