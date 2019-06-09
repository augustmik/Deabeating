using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    //first letter of the scene
    public string playerName;
    public int mTimes = 0;
    public int hTimes = 0;  //Debug reasons
    public int sTimes = 0;

    public int Score = 0;


    //C1 Tracking until choice
    public bool leftHome = false;
    public bool backHome = false;
    public bool tutorialFinished = false;

    //Event booleans
    public bool marketEventCompleted = false;
    public bool schoolComplete = false;

    public bool chapterScreenPlayed = false;

    //C1 Player choices
    public bool motherHelped = false;
    public int choiceHelpMomFirst = -1; // 0 - help mom, 1 - rush school
    public bool showC1CPanel = false;

    public bool chapter1Complete = false;
    public bool chapter2Complete = false;
    public bool chapter3Complete = false;


    //Sugarlevel after market
    //public int supermarketValue = -1;
    public bool lowRed = false;
    public bool lowYellow = false;
    public bool lowOrange = false;
    public bool Green = false;
    public bool highRed = false;
    public bool highOrange = false;
    public bool highYellow = false;

    //C2
    public bool helpStranger = false;

    public bool firstCheckStranger = true;
    public bool secCheckStranger = false;
    public bool seenNurse = false;
    public bool gotWater = false;

    //C3


    private void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    //public void C1Choice

}
