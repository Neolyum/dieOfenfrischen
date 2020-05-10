using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatFromTxt : MonoBehaviour
{
    
    public TextAsset textFile;

    private string[] beatArray;
    
    // Start is called before the first frame update
    void Start()
    {
        string text = textFile.text;
        text = text.Replace("[", "");
        text = text.Replace("]", "");
        char[] separator = { ' ' };
        beatArray = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
    }
}
