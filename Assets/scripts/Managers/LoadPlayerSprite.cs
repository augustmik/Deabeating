using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerSprite : MonoBehaviour
{
    private GameObject charScript;

    void Start()
    {
        charScript = GameObject.Find("CharacterCreation");
        gameObject.GetComponent<SpriteRenderer>().sprite = charScript.GetComponent<CharacterCreation>().getSprite();
    }
}
