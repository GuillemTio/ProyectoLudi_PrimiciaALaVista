using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorDePuntuació : MonoBehaviour
{
    public TMP_Text pointsTMP;
    public float startPoints = 100;
    public float startErrorPoints = -10;
    private float currentErrorPoints;
    public float errorMultiplier = 1.1f;
    public float correctPoints = 100;
    private float currentPoints;

    // Start is called before the first frame update
    void Start()
    {
        currentPoints = startPoints;
        SetText();
        currentErrorPoints = startErrorPoints;
    }

    public void WrongAnswer()
    {
        currentPoints += currentErrorPoints;
        currentErrorPoints *= errorMultiplier;
        SetText();
    }

    public void CorrectAnswer()
    {
        currentPoints += correctPoints;
        SetText();
    }

    private void SetText()
    {
        pointsTMP.text = currentPoints.ToString();
    }

    
}
