using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDecay : MonoBehaviour
{
    private SpriteRenderer shotRenderer;
    private float timeSeconds;
    public float BaseLengthSeconds;
    public float decayLengthSeconds;
    public Color baseColor;
    public Color endColor;

    // Start is called before the first frame update
    void Start()
    {
        shotRenderer = GetComponent<SpriteRenderer>();
        shotRenderer.color = baseColor;
    }

    // Update is called once per frame
    void Update()
    {
        timeSeconds += Time.deltaTime;
        float decayPos = (timeSeconds - BaseLengthSeconds)/decayLengthSeconds;
        if (decayPos > 0)
        {
            shotRenderer.color = endColor * decayPos + baseColor * (1 - decayPos);
        }

        if(decayPos > 1)
        {
            Destroy(gameObject);
        }
    }
}
