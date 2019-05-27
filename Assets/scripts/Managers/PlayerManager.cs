using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{

    private static PlayerManager _instance;


    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerManager();
            }
            return _instance;
        }
    }

    public static string playernamestr;

    public Text playername;
    public Text thanks;


    private void Start()
    {
        Scene current = SceneManager.GetActiveScene();
     
        if (current.name.ToString() == "Home")
        {
            GameManager.Instance.hTimes++;
            playername.text = "Welcome home " + playernamestr;
            if(GameManager.Instance.marketEventCompleted == true)
            {
                thanks.text = "Thank you " + playernamestr + " for bringing me food \n I feel better already!";
            }
        }

        if (current.name.ToString() == "Market")
        {
            
            GameManager.Instance.mTimes++;
            Debug.Log(GameManager.Instance.mTimes);
        }
    }

  
}

