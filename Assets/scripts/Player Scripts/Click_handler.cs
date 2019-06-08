using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Click_handler : MonoBehaviour
{
    public GameObject Clickable;
    //public GameObject dialogue;

    private Vector3 pos = new Vector3(0, 0, 0);
    private Quaternion quat;
    

    public string levelName;
    public Text NoAccess;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SceneManager.GetActiveScene().name == "Village")
            {
                if (GameManager.Instance.chapter2Complete == true)
                {
                    Chapter3();
                }
                else if (GameManager.Instance.chapter1Complete == true)
                {
                    Chapter2();
                }
                else if (GameManager.Instance.tutorialFinished == true)
                {
                    Chapter1();
                }
                else Chapter0();
            }
            else SceneManager.LoadScene(levelName);







            /*if (SceneManager.GetActiveScene().name == "Village" && GameManager.Instance.chapterScreenPlayed == true && Clickable.name == "Market")
            {
                SceneManager.LoadScene("Market");
            }*/


            
        }
    }

    public void Chapter0()
    {
        if (GameManager.Instance.leftHome == false && levelName == "Hospital")//SceneManager.GetActiveScene().name == "Home_tutorial")
        {
            GameManager.Instance.leftHome = true;
            SceneManager.LoadScene("Hospital_tutorial");
        }

        if (GameManager.Instance.leftHome == true && levelName == "Hospital")
        {
            SceneManager.LoadScene("Hospital_tutorial");
        }
        //SceneManager.LoadScene(levelName);
    }
    public void Chapter1()
    {
        if (GameManager.Instance.chapterScreenPlayed == false)
        {
            SceneManager.LoadScene("Chapter1");
            GameManager.Instance.chapterScreenPlayed = true;
        }

        if (levelName != SceneManager.GetActiveScene().name)
        {
            if (GameManager.Instance.choiceHelpMomFirst == 0)
            {
                if (levelName == "Home" && GameManager.Instance.marketEventCompleted == false)
                {
                    NoAccess.text = "I Better go to the Market before returning Home";
                }
                else if (levelName == "School" && GameManager.Instance.motherHelped == false)
                {
                    NoAccess.text = "I Have chosen to go Help my Mom first.";
                }
                else if (levelName == "Hospital")
                {
                    NoAccess.text = "I Have no business here.";
                }
                else
                {
                    SceneManager.LoadScene(levelName);
                }
            } else if (GameManager.Instance.choiceHelpMomFirst == 1)
            {
                if (levelName == "Home" && GameManager.Instance.marketEventCompleted == false)
                {
                    NoAccess.text = "I Better go to the Market before returning Home";
                }
                else if (levelName == "Market" && GameManager.Instance.schoolComplete == false)
                {
                    NoAccess.text = "I Have chosen to Rush to School.";
                }
                else if (levelName == "Hospital")
                {
                    NoAccess.text = "I Have no business here.";
                }
                else
                {
                    SceneManager.LoadScene(levelName);
                }
            }
        }
        
        
    }
    public void Chapter2()
    {
        if (GameManager.Instance.chapterScreenPlayed == false)
        {
            SceneManager.LoadScene("Chapter2");
            GameManager.Instance.chapterScreenPlayed = true;
        }

        //GameManager.Instance.chapter2Complete = true; //change this when there's material
        //Chapter3();
    }
    public void Chapter3()
    {
        if (GameManager.Instance.chapterScreenPlayed == false)
        {
            SceneManager.LoadScene("Chapter3");
            GameManager.Instance.chapterScreenPlayed = true;
        }
        
        if (levelName == "Market")
        {
            NoAccess.text = "I need to go to School";
        }
        else if (levelName == "Home")
        {
            NoAccess.text = "I better go to School";
        }
        else if (levelName == "Hospital")
        {
            NoAccess.text = "I Have no business here.";
        }
        else
        {
            SceneManager.LoadScene(levelName);
        }
        
    }
}
