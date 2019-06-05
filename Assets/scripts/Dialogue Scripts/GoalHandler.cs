using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalHandler : MonoBehaviour
{
    public static GoalRoot allGoals;
    private static int currentGoal = 0;
    public Text goalText;
    private float timer;

    void Start()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Goals");
        allGoals = JsonUtility.FromJson<GoalRoot>(jsonTextFile.ToString());
        //goalText.text = allGoals.Goal[1].goalText;
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().name == "Home_tutorial")
        {
            if (timer < 5.1f)
            {
               timer += Time.deltaTime;
                if (timer > 5f)
                {
                    goalText.text = allGoals.Goal[1].goalText;
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Village" && GameManager.Instance.leftHome == true)
        {
            goalText.text = allGoals.Goal[1].goalText;
        }
        else if(SceneManager.GetActiveScene().name == "Hospital_tutorial" && GameManager.Instance.tutorialFinished == true)
        {

            goalText.text = allGoals.Goal[2].goalText;
        }
        
    }
    public static GoalRoot CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<GoalRoot>(jsonString);
    }

    public void DisplayNextGoal()
    {
        goalText.text = allGoals.Goal[currentGoal].goalText;
        currentGoal++;
    }
}
