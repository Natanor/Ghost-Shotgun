using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlowText : MonoBehaviour
{
    [TextArea(10,10)]
    public string text;
    public float textSpeed;
    public string nextScene;

    private string[] lines;
    private int lineNumber;
    private int charNumber;
    private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        lines = text.Split("\n\n");
        textMeshPro = GetComponent<TextMeshProUGUI>();
        lineNumber = -1;
        textMeshPro.text = "";

        GoToNextLine();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Skip();
        }
    }

    private void Skip()
    {
        if (charNumber < lines[lineNumber].Length)
        {
            charNumber = lines[lineNumber].Length;
            UpdateText();
        }
        else
        {
            GoToNextLine();
        }
    }

    private void GoToNextLine()
    {
        lineNumber++;

        if(lineNumber < lines.Length)
        {
            StartCoroutine(addChar(lineNumber));
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }

    }

    private void UpdateText()
    {
        textMeshPro.text = lines[lineNumber].Substring(0, charNumber);
    }

    IEnumerator addChar(int coLineNumber)
    {
        charNumber = 0;

        while (charNumber < lines[coLineNumber].Length && lineNumber == coLineNumber)
        {
            yield return new WaitForSeconds(1 / textSpeed);
            if(charNumber < lines[coLineNumber].Length && lineNumber == coLineNumber)
            {
                charNumber++;
                UpdateText();
            }
        }
    }

}
