using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click_handler : MonoBehaviour
{
    public GameObject Clickable;
    //public GameObject dialogue;

    private Vector3 pos = new Vector3(0, 0, 0);
    private Quaternion quat;

    public string levelName;
    public Text NoAccess;

    

   

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(levelName != SceneManager.GetActiveScene().name)
            {
                if(levelName == "Home" && GameManager.Instance.marketEventCompleted == false)
                {
                    NoAccess.text = "You have to go to the market first";
                }
             SceneManager.LoadScene(levelName);
              
            }
            
        }
    }


    

}
