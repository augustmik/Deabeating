using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    //first letter of the scene
    public int mTimes = 0;
    public int hTimes = 0;
    public int sTimes = 0;

    //Event booleans
    public bool marketEventCompleted = false;
    public bool motherHelped = false;
    public bool leftHome = false;
    public bool backHome = false;
    public bool tutorialFinished = false;

    //Player choices
    public bool helpMother = false;
    public bool rushToSchool = false;
    public bool helpStranger = false;

    //Sugarlevel after market
    public bool lowRed = false;
    public bool lowYellow = false;
    public bool lowOrange = false;
    public bool Green = false;
    public bool highRed = false;
    public bool highOrange = false;
    public bool highYellow = false;

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


}
