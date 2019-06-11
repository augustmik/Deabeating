using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("CharacterCreation");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BeginChapter()
    {
        GameManager.Instance.goalDone = true;
        SceneManager.LoadScene("Room");
    }
    public void BeginChapter2()
    {
        GameManager.Instance.goalDone = true;
        SceneManager.LoadScene("RoomC2");
    }
    public void BeginChapter3()
    {
        GameManager.Instance.goalDone = true;
        SceneManager.LoadScene("RoomC3");
    }
}
