using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHandler : MonoBehaviour
{

    private string[] goal;
    public string jsonFile;



    // Given JSON input:
    // {"name":"Dr Charles","lives":3,"health":0.8}
    // this example will return a PlayerInfo object with
    // name == "Dr Charles", lives == 3, and health == 0.8f.

    void Start()
    {
        goal = new string[10];
    }

    public GoalHandler CreateFromJSON()
    {
        return JsonUtility.FromJson<GoalHandler>(jsonFile);
    }
}
