using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHandler : MonoBehaviour
{

    private string[] goal;
    private Goal goalO;
    //private var jsonTextFile;
    //Load text from a JSON file (Assets/Resources/Text/jsonFile01.json)

    //Then use JsonUtility.FromJson<T>() to deserialize jsonTextFile into an object


    // Given JSON input:
    // {"name":"Dr Charles","lives":3,"health":0.8}
    // this example will return a PlayerInfo object with
    // name == "Dr Charles", lives == 3, and health == 0.8f.

    void Start()
    {
        goal = new string[10];
        var jsonTextFile = Resources.Load<TextAsset>("Goals");
        Debug.Log(jsonTextFile.ToString());
        goalO = CreateFromJSON(jsonTextFile.ToString());
        Debug.Log(goalO.goal);

    }

    public static Goal CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Goal>(jsonString);
    }
}
