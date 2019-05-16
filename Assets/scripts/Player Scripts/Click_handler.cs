using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.SceneManagement;



public class Click_handler : MonoBehaviour
{
    public GameObject Clickable
        ;
    //public GameObject dialogue;

    private Vector3 pos = new Vector3(0, 0, 0);
    private Quaternion quat;

    public string levelName;
   

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(levelName != SceneManager.GetActiveScene().name)
            {
             SceneManager.LoadScene(levelName);
            }
            
        }
    }




}
