using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketTutorial : MonoBehaviour
{
    public GameObject panel;
    public Text text;

    float timer = 0;


    public void hideTutorial()
    {
        panel.SetActive(false);
    }
}
