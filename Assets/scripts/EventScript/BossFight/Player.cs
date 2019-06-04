using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image playerHPBar;
    public float reduceHPAmount;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //check if player is hit
    }

    public void reducePlayerHP()
    {
        playerHPBar.fillAmount -= reduceHPAmount;
    }
}
