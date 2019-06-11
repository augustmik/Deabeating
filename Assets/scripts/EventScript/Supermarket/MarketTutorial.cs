using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketTutorial : MonoBehaviour
{
    public GameObject panel1,panel2,panel3;
    //public Text text;
    public Button OK, next;

    float timer = 0;

    private void Awake()
    {
        if(GameManager.Instance.secCheckStranger == false)
        {
     
            panel1.SetActive(true);
            panel2.SetActive(false);
            panel3.SetActive(false);

            next.gameObject.SetActive(true);
            OK.gameObject.SetActive(false);

        }
       
    }

   public void hideTutorial()
    {
         panel3.SetActive(false);
         OK.gameObject.SetActive(false);
    }

    public void nextPanel()
    {
        Invoke("activePanel1", 0);

        if(panel2.activeSelf == true)
        {
            Invoke("activePanel2", 0);
            next.gameObject.SetActive(false);
            OK.gameObject.SetActive(true);
        }
    }

    private void activePanel1()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    private void activePanel2()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
    }
    
}
