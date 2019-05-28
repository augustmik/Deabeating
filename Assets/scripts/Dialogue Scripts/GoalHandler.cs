using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHandler : MonoBehaviour
{

    private string[] goal = new string[10];
    public Goal[] goals;
    //private var jsonTextFile;
    //Load text from a JSON file (Assets/Resources/Text/jsonFile01.json)

    //Then use JsonUtility.FromJson<T>() to deserialize jsonTextFile into an object


    // Given JSON input:
    // {"name":"Dr Charles","lives":3,"health":0.8}
    // this example will return a PlayerInfo object with
    // name == "Dr Charles", lives == 3, and health == 0.8f.

    void Start()
    {
        //goal = new string[10];
        var jsonTextFile = Resources.Load<TextAsset>("Goals");
        Debug.Log(jsonTextFile.ToString());
        goals = JsonUtility.FromJson<Goal[]>(jsonTextFile.ToString());
        //CreateFromJSON(jsonTextFile.ToString());
        Debug.Log(goals[0]);
        Debug.Log(goals[1].goalText);

    }

    public string[] GoalsToList()
    {

        return goal;
    }
    public static Goal CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Goal>(jsonString);
    }
}
