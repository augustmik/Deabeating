using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image playerHPBar;
    public float reduceHPAmount;
    public GameObject losePanel;
    private GameObject charScript;

    void Awake()
    {
        charScript = GameObject.Find("CharacterCreation");
        losePanel.SetActive(false);

    }
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = charScript.GetComponent<CharacterCreation>().getSprite();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AttackTag")
        {
            reducePlayerHP();
        }
    }

    public void reducePlayerHP()
    {
        playerHPBar.fillAmount -= reduceHPAmount;
        if (playerHPBar.fillAmount <= 0.1f)
        {
            losePanel.SetActive(true);
        }
    }
}
