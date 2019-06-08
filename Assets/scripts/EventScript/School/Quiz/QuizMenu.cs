using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizMenu : MonoBehaviour
{

    // Load Scene 01 when start button is pressed
    public void StartGame()
    {
        SceneManager.LoadScene("Question1");
    }

}