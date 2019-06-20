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
    public GameObject ScorePanel;
    
    // Use this for initialization
    void Start()
    {
        ScorePanel.SetActive(false);
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

        correctSign.SetActive(true);
        ScorePanel.SetActive(true);
        GameManager.Instance.Score += 1;
        score.text = "Score: " + GameManager.Instance.Score.ToString();
        
        Invoke("LoadNextLevel", 2f);
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
        ScorePanel.SetActive(true);
        score.text = "Score: " + GameManager.Instance.Score.ToString();
        GameManager.Instance.Score = 0;
        
        Invoke("GotoQuizMenu", 2f);
    }


    // Method loads next level depending on current scenes build index
    void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadChapter4()
    {
        SceneManager.LoadScene("Chapter4");
    }

    // Method loads MainMenu scene
    void GotoQuizMenu()
    {
        SceneManager.LoadScene("School_quiz");
    }

}
