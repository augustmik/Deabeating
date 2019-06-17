using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{

    private static PlayerManager _instance;
    //private GameObject gameManager;

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
    public Image villageHealth;
    private float timer = 0.0f;
    private bool choiseCheck = false;
    public float waitAmount;
    private bool startTimer = false;

    void Start()
    {
        Scene current = SceneManager.GetActiveScene();
        GameManager.Instance.playerName = playernamestr;
        //charScript = GameObject.Find("CharacterCreation");
        if (current.name.ToString() == "Home")
        {
            
            if(GameManager.Instance.tutorialFinished == true )
            {
                thanks.text = "Good morning " + playernamestr + " I don't feel too good \n could you get me something to eat?";
                //add delay
                if (GameManager.Instance.choiceHelpMomFirst == -1) {
                    startTimer = true;
                }
                //GameManager.Instance.showC1CPanel = true;
            }
            
            if (GameManager.Instance.marketEventCompleted == true)
            {
                GameManager.Instance.motherHelped = true;
                GameManager.Instance.goalDone = true;
                thanks.text = "Thank you " + playernamestr + " for bringing me food \n I feel better already!";

                if(GameManager.Instance.lowRed == true)
                {
                    GameManager.Instance.motherHelped = false;
                    GameManager.Instance.C1SpecGoal = true;
                    GameManager.Instance.marketEventCompleted = false;
                    GameManager.Instance.lowRed = false;
                    thanks.text = "Thank you " + playernamestr + " for bringing me food \n but I am still feeling really tired \n maybe you could fetch me some more food";

                }
                else if (GameManager.Instance.lowOrange == true)
                {
                    GameManager.Instance.lowOrange = false;
                    thanks.text = "Thank you " + playernamestr + " for bringing me food \n but I am still feeling really tired but I will be fine";

                }
                else if (GameManager.Instance.lowYellow == true)
                {
                    GameManager.Instance.lowYellow = false;
                    thanks.text = "Thank you " + playernamestr + " for bringing me food \n I think I will be okay soon";

                }
                else if (GameManager.Instance.Green == true)
                {
                    GameManager.Instance.Green = false;
                    thanks.text = "Thank you " + playernamestr + " for bringing me food \n I feel better already!";

                }
                else if (GameManager.Instance.highYellow == true)
                {
                    GameManager.Instance.highYellow = false;
                    thanks.text = "Thank you " + playernamestr + " for bringing me food \n I feel better already, but maybe bit too much sugar!";

                }
                else if (GameManager.Instance.highOrange == true)
                {
                    GameManager.Instance.highOrange = false;
                    thanks.text = "Thank you " + playernamestr + " for bringing me food \n I feel better already, this was quite a lot of sugar!";

                }
                else if (GameManager.Instance.highRed == true)
                {
                    GameManager.Instance.highRed = false;
                    thanks.text = "Thank you " + playernamestr + " for bringing me food \n I dont feel too good, this was way to much sugar!";
                }

            }
            if (GameManager.Instance.marketEventCompleted == true && GameManager.Instance.schoolComplete != true)
            {
                thanks.text = "Now please go to School!";
            }
            //add delay
            if (GameManager.Instance.marketEventCompleted == true && GameManager.Instance.schoolComplete == true)
            {
                GameManager.Instance.chapter1Complete = true;
                GameManager.Instance.chapterScreenPlayed = false;
                if (GameManager.Instance.gotWater)
                {
                    GameManager.Instance.chapter2Complete = true;
                    SceneManager.LoadScene("Chapter3");
                }
                else
                {
                    GameManager.Instance.goalNumber = 14;       //adjust for chapter 2, no help mom goals tho at start
                    SceneManager.LoadScene("Chapter2");
                }

            }
        }

        if (current.name.ToString() == "Market")
        {
            GameManager.Instance.mTimes++;
        }

        if(current.name.ToString()== "Village")
        {
          
            if (GameManager.Instance.motherHelped == true)
            {
                villageHealth.fillAmount += 0.25f;
            }
        }

        
    }
    private void Update()
    {
        if (GameManager.Instance.choiceHelpMomFirst == -1)
        {
            timer += Time.deltaTime;
            if (timer > waitAmount)
            {
                ShowChoiseC1();
                timer -= waitAmount;
            }
        }
        if (choiseCheck)
        {
            if (GameManager.Instance.choiceHelpMomFirst == 0) //if helps mom first
            {
                thanks.text = "Thank you. That’s really kind of you. Go get some Food.";
            }
            else if (GameManager.Instance.choiceHelpMomFirst == 1)
            {
                thanks.text = "OK, I understand, but please get me food after school then.";
            }
        }
    }
    void ShowChoiseC1()
    {
        GameManager.Instance.showC1CPanel = true;
        choiseCheck = true;
    }
  
}

