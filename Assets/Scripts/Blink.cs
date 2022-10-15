using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour
{
    public float blinkSpeed;
    public float logBase;
    private TextMeshProUGUI textMeshPro;
    private float currentAlpha;


    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        currentAlpha = -1;
    }

    // Update is called once per frame
    void Update()
    {
        currentAlpha += Time.deltaTime / blinkSpeed;
        if( currentAlpha > 1)
        {
            currentAlpha = -1;
        }
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, Mathf.Pow(Mathf.Abs(currentAlpha), logBase));

    }
   

}
