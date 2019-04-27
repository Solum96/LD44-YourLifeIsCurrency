using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text _text;
    void Start()
    {
        _text = GetComponent<Text>();
    }
    float Timer = 0.0f;
    void Update()
    {
        
        Timer += Time.deltaTime; //Time.deltaTime will increase the value with 1 every second.
        _text.text = Timer.ToString("0.00");
    }
}
