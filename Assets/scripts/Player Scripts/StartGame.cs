using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public InputField playerName;
    public void StartuGame()
    {
        PlayerManager.playernamestr = playerName.text;
        SceneManager.LoadScene("Home_tutorial");
    }
}
