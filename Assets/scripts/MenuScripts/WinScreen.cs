using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    private float interval = 3.0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interval>0)
        {
            interval -= Time.deltaTime;
        } else
        {
            SceneManager.LoadScene("Credits");
        }

    }

    //right now we don't need this
    //public void RestartGame()
    //{
    //    SceneManager.LoadScene("Credits");
    //}
}
