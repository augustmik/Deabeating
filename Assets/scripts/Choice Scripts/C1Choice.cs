using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1Choice : MonoBehaviour
{
    public GameObject choicePanel;
    void Awake()
    {
        choicePanel.SetActive(false);
    }
    void Update()
    {
        if (GameManager.Instance.showC1CPanel == true && GameManager.Instance.choiceHelpMomFirst == -1)
        {
            choicePanel.SetActive(true);
            GameManager.Instance.showC1CPanel = false;
        }

    }
    public void Chapter1Choice(int choice) //if help mom First then 0
    {
        //Debug.Log(choice);
        GameManager.Instance.choiceHelpMomFirst = choice;
        choicePanel.SetActive(false);
    }
}
