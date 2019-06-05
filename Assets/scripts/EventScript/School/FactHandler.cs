using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactHandler : MonoBehaviour
{
    public static FactsRoot allFacts;

    void Start()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Facts");
        allFacts = JsonUtility.FromJson<FactsRoot>(jsonTextFile.ToString());
        //goalText.text = allFacts.Fact[1].factText;

    }

    void Update()
    {
        
    }
    public static FactsRoot CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<FactsRoot>(jsonString);
    }
}
