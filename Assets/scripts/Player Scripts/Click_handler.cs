using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.SceneManagement;



public class Click_handler : MonoBehaviour
{
    public GameObject Clickable;
    private GameObject callable;
    //public GameObject dialogue;
    private HealthBar hpBar;
    private Vector3 pos = new Vector3(0, 0, 0);
    private Quaternion quat;

    public string levelName;

    private void Awake()
    {

    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (levelName == "HandleMethod")
            {
                callable = GameObject.Find("HealthBar");
                hpBar = callable.GetComponent<HealthBar>();
                hpBar.SetSizeL();

            }
            else if (levelName != SceneManager.GetActiveScene().name)
            {
                SceneManager.LoadScene(levelName);
            }
            
        }
    }




}
