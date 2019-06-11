using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalHandler : MonoBehaviour
{

    public static GoalRoot allGoals;
    public Text goalText;
    private int adjustBy = 3;
    private int specGoal = 10;

    void Start()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Goals");
        allGoals = JsonUtility.FromJson<GoalRoot>(jsonTextFile.ToString());
        if (GameManager.Instance.goalDone)
        {
            if (GameManager.Instance.choiceHelpMomFirst != -1 && !GameManager.Instance.chapter1Complete) { AdjustForC1Choice(); }
            if (GameManager.Instance.C1SpecGoal) { DisplayGoal(specGoal); }
            else if (GameManager.Instance.C1SpecGoal2) { DisplayGoal(specGoal+1);}
            else DisplayNextGoal();
        }
        else DisplaySameGoal();

    }
    public void DisplayGoal(int goal)
    {
        goalText.text = allGoals.Goal[goal].goalText;
        GameManager.Instance.goalDone = false;
        if (goal == specGoal)
        {
            GameManager.Instance.C1SpecGoal = false;
            GameManager.Instance.C1SpecGoal2 = true;
        } else if (goal == specGoal + 1)
        {
            GameManager.Instance.C1SpecGoal2 = false;
        }
    }
    public void DisplaySameGoal()
    {
        goalText.text = allGoals.Goal[GameManager.Instance.goalNumber].goalText;
    }
    private void Update()
    {
        
        /*
       if(SceneManager.GetActiveScene().name.ToString() == "Village" && GameManager.Instance.tutorialFinished == false)
        {
            goalText.text = allGoals.Goal[1].goalText;
        }
        */
    }
    public static GoalRoot CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<GoalRoot>(jsonString);
    }

    public void DisplayNextGoal()
    {
        GameManager.Instance.goalNumber++;

        goalText.text = allGoals.Goal[GameManager.Instance.goalNumber].goalText;
        GameManager.Instance.goalDone = false;
    }
    public string ReturnGoal()
    {
        //GameManager.Instance.goalNumber++;
        return "* " + allGoals.Goal[GameManager.Instance.goalNumber].goalText;
    }
    public void AdjustForC1Choice()
    {
        if (GameManager.Instance.choiceHelpMomFirst == 0) {
            if (!GameManager.Instance.skipped)
            {
                GameManager.Instance.goalNumber += adjustBy;
                GameManager.Instance.skipped = true;
            }
        }
        else
        {
            if (GameManager.Instance.goalCounter == 3)
            {
                GameManager.Instance.goalNumber += 3;
            }
            GameManager.Instance.goalCounter++;

        }
    }
}
