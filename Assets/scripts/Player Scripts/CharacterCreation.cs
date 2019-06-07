using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{

    public static CharacterCreation instance { get; private set; }
    public Sprite boySprite;
    public Sprite girlSprite;
    public bool isBoy;

    void Awake()
    {
        Debug.Log(instance);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Sprite getSprite()
    {
        if (isBoy) { return boySprite; }
        else { return girlSprite; }
    }

    public void ChooseBoy()
    {
        isBoy = true;
        SceneManager.LoadScene("Boss");
        //SceneManager.LoadScene("CharacterCreation2");

    }

    public void ChooseGirl()
    {
        isBoy = false;
        SceneManager.LoadScene("Boss");
        //SceneManager.LoadScene("CharacterCreation2");
        
    }

}
