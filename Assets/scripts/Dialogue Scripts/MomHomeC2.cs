using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomHomeC2 : MonoBehaviour
{
    public Text momWords;
    private string playerName;
    private GameObject charScript;

    void Start()
    {
        charScript = GameObject.Find("CharacterCreation");
        playerName = GameManager.Instance.playerName;
        if (GameManager.Instance.gotWater != true)
        {
            momWords.text = "Good morning " + playerName + ". We don’t have water anymore and I really need some, could you go to the Market and get me some?";
        }
        else EndChapter2();
            //update goals here
    }

    void EndChapter2()
    {
        momWords.text = "Thank you for bringing me water, I feel so much better now.";
        GameManager.Instance.chapter2Complete = true;
    }
}
