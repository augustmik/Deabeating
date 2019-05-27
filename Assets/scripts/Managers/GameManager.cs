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

    public bool marketEventCompleted = false;
    public bool motherHelped = false;



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
