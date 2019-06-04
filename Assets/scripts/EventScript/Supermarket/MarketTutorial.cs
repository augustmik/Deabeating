using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketTutorial : MonoBehaviour
{
    public GameObject panel;
    public Text text;

    float timer = 0;

   /* private void Update()
    {
        timer += Time.deltaTime;
        if(GameManager.Instance.marketEventCompleted == false)
        {
            panel.SetActive(true);

            if(timer > 10)
            {
                panel.SetActive(false);
            }
        }
    }*/

    public void hideTutorial()
    {
        panel.SetActive(false);
    }
}
