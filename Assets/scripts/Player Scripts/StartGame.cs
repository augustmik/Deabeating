using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public InputField playerName;
    public Image playerImage;
    public GameObject charScript;

    void Start()
    {
        charScript = GameObject.Find("CharacterCreation");
        playerImage.sprite = charScript.GetComponent<CharacterCreation>().getSprite();

    }
    public void StartuGame()
    {
        PlayerManager.playernamestr = playerName.text;
        SceneManager.LoadScene("Home_tutorial");
    }
    public void GoKitchen()
    {
        SceneManager.LoadScene("Home");
    }
}