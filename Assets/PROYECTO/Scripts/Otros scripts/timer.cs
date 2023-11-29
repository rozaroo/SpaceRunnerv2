using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timer : MonoBehaviour
{
    public float Timer = 0;
    public Text textoTimer;
    void Update()
    {
        Timer += Time.deltaTime;
        textoTimer.text = "" + Timer.ToString("f0");
    }
}
