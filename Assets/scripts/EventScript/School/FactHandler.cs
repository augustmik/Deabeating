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
    private bool checker;
    void Start()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Facts");
        allFacts = JsonUtility.FromJson<FactsRoot>(jsonTextFile.ToString());
        if (GameManager.Instance.chapter2Complete == true)
        {
            teacherText.text = "Good morning, today we will do a quiz about diabetes.";
        }

        //goalText.text = allFacts.Facts[1].factText;

    }

    public static FactsRoot CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<FactsRoot>(jsonString);
    }
    public void LoadNextFact()
    {
        if (GameManager.Instance.chapter2Complete == true)
        {
            Debug.Log("Load Quiz");
            checker = true;
            //SceneManager.LoadScene("School_Quiz");
        }
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
        GameManager.Instance.schoolComplete = true;
        Debug.Log("Event End");
        if (checker) { SceneManager.LoadScene("School_Quiz"); }
        else SceneManager.LoadScene("Village");
    }
}
