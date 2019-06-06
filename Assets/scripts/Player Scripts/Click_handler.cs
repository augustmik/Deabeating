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
            if(levelName != SceneManager.GetActiveScene().name && GameManager.Instance.tutorialFinished == true)
            {
                if(levelName == "Home" && GameManager.Instance.marketEventCompleted == false)
                {
                    NoAccess.text = "You have to go to the market first";
                } 
                    SceneManager.LoadScene(levelName);
            }

            if(GameManager.Instance.leftHome == false && SceneManager.GetActiveScene().name == "Home_tutorial")
            {
                levelName = "Village";
                GameManager.Instance.leftHome = true;
                SceneManager.LoadScene(levelName);
            }

            if (GameManager.Instance.leftHome == true && SceneManager.GetActiveScene().name == "Village" && GameManager.Instance.tutorialFinished == false)
            {
                SceneManager.LoadScene("Hospital_tutorial");
            }

            if(SceneManager.GetActiveScene().name == "Village" && GameManager.Instance.tutorialFinished == true && GameManager.Instance.test == false)
            {
                SceneManager.LoadScene("Chapter1");
                GameManager.Instance.test = true;
            }

            if(SceneManager.GetActiveScene().name == "Village" && GameManager.Instance.test == true && Clickable.name == "Market")
            {
                SceneManager.LoadScene("Market");
            }


            
        }
    }

    

}
