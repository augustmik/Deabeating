using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalHandler : MonoBehaviour
{

    public static GoalRoot allGoals;
    private static int currentGoal = 0;
    public Text goalText;

    void Start()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Goals");
        //Debug.Log(jsonTextFile.ToString());
        allGoals = JsonUtility.FromJson<GoalRoot>(jsonTextFile.ToString());
        goalText.text = allGoals.Goal[1].goalText;

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
