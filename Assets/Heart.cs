using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Light heartLight;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        heartLight = GetComponentInChildren<Light>();
    }

    public void AscendHeart()
    {
        StartCoroutine(GradualDestroy());
    }

    IEnumerator GradualDestroy()
    {
        float destructionTime = 8;
        float destructionTimer = 0;
        float interval = 0.1f;
        heartLight.intensity = 1;
        while (destructionTimer < destructionTime)
        {
            Color invisibleRed = new Color(1,0,0,0);
            spriteRenderer.color = Color.Lerp(Color.white, invisibleRed, destructionTimer / destructionTime);
            heartLight.range = Mathf.Lerp(3, 0, destructionTimer/destructionTime);
            destructionTimer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
    }
}
