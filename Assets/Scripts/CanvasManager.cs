using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject guide;

    public TextMeshProUGUI counterText;

    public TextMeshProUGUI levelText;

    public GameObject progressBarRoot;

    public Image progressBar;

    private void Awake() {
        instance = this;
    }

    
    void Start()
    {
        
    }


    public void SetCounterText(int value) {
        counterText.SetText(value.ToString());
    }
}
