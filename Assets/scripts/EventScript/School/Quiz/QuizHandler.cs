using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizHandler : MonoBehaviour
{

    // Get references to game objects that should be disabled and enabled
    // at the start
    GameObject[] toEnable, toDisable;

    // References to game objects that should be enabled
    // when correct or incorrect answer is given
    public GameObject correctSign, incorrectSign;

    // Variable to contain current scene build index
    int currentSceneIndex;

    public Text score;
    public GameObject panel;
    
    // Use this for initialization
    void Start()
    {
        panel.SetActive(false);
        // Getting current scene build index
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Finding game objects with tags "ToEnable" and "ToDisable"
        toEnable = GameObject.FindGameObjectsWithTag("ToEnable");
        toDisable = GameObject.FindGameObjectsWithTag("ToDisable");

        // Disabling game objects with tag "ToEnable"
        foreach (GameObject element in toEnable)
        {
            element.gameObject.SetActive(false);
        }

    }

    // Method is invoked when correct answer is given
    public void RightAnswer()
    {
        // Disabling game objects that are no longer needed
        foreach (GameObject element in toDisable)
        {
            element.gameObject.SetActive(false);
        }
        GameManager.Instance.Score += 1;
        correctSign.SetActive(true);
        panel.SetActive(true);
        Invoke("LoadNextLevel", 1.5f);
        score.text = "Score: " + GameManager.Instance.Score.ToString();
        //SceneManager.LoadScene(currentSceneIndex + 1);


    }

    
    public void WrongAnswer()
    {
        // Disabling game objects that are no longer needed
        foreach (GameObject element in toDisable)
        {
            element.gameObject.SetActive(false);
        }

        incorrectSign.SetActive(true);
        panel.SetActive(true);
        score.text = "Score: " + GameManager.Instance.Score.ToString();
        Invoke("GotoQuizMenu", 1.5f);
    }


    // Method loads next level depending on current scenes build index
    void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadBossLevel()
    {
        SceneManager.LoadScene("Boss");
    }

    // Method loads MainMenu scene
    void GotoQuizMenu()
    {
        SceneManager.LoadScene("School_quiz");
    }

}
