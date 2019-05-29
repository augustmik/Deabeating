using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearningEvent : MonoBehaviour
{

    public Text SchoolText;
    public GameObject panel;


    public List<Text> facts = new List<Text>();

    private float test = 100f;

    //TODO: WRITE FACTS



    private void Start()
    {
        
        SchoolText.text = "Hi students, today we are going to learn about diabetes";

    }
}
