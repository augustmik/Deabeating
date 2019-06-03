using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{


    public InputField playerName;

    public bool Boy = false;
    public bool Girl = false;

    private Vector3 pos = new Vector3(0, 0, 0);
    private Quaternion quat;


    private void Update()
    {
      
    }



    public void ChooseBoy()
    {
        Boy = true;
        SceneManager.LoadScene("CharacterCreation2");
        
    }

    public void ChooseGirl()
    {
        Girl = true;
        SceneManager.LoadScene("CharacterCreation2");
        
    }

    public void StartGame()
    {
        PlayerManager.playernamestr = playerName.text;
        SceneManager.LoadScene("Home_tutorial");
    }

}
