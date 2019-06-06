using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FactHandler : MonoBehaviour
{
    public static FactsRoot allFacts;
    private static int currentFact = 0;
    public Text teacherText;
    void Start()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Facts");
        allFacts = JsonUtility.FromJson<FactsRoot>(jsonTextFile.ToString());
        //goalText.text = allFacts.Facts[1].factText;

    }

    void Update()
    {
        
    }
    public static FactsRoot CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<FactsRoot>(jsonString);
    }
    public void LoadNextFact()
    {
        try
        {
            teacherText.text = allFacts.Facts[currentFact].factText;
            //do something with facts if (currentFact==n) show something?
            currentFact++;
        }
        catch (System.ArgumentOutOfRangeException e) { EndSchoolEvent(); }
    }
    public void EndSchoolEvent()
    {
        teacherText.text = "That would be all kids. You are free to go.";
        Debug.Log("Event End");
        //Hook this to some scene
    }
}
