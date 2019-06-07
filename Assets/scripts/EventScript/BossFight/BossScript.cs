using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    private float timer = 0.0f;
    public GameObject attackPrefab;
    public GameObject locationObj;
    public float waitTime;
    public float hpDecrease;
    private int randomA;
    public Image bossHPBar;
    private Vector3 startPos;
    public GameObject losePanel;
    public GameObject preFightPanel;
    private bool startCheck = false;

    void Awake()
    {
        startPos = locationObj.transform.position;
        locationObj.SetActive(false);
    }

    void Update()
    {
        
        if (losePanel.activeSelf == false && startCheck == true && preFightPanel.activeSelf == false) 
        {
            timer += Time.deltaTime;

            if (timer > waitTime)
            {
                //timeNow = timer;
                Instantiate(attackPrefab, startPos, Quaternion.identity);

                timer = timer - waitTime;
            }
            bossHPBar.fillAmount -= hpDecrease * Time.deltaTime;
            if (bossHPBar.fillAmount <= 0.0f)
            {
                SceneManager.LoadScene("GameWin");
            }
        }
    }
    public void ResetScene()
    {
        SceneManager.LoadScene("Boss");
    }
    public void StartFight()
    {
        preFightPanel.SetActive(false);
        startCheck = true;
        locationObj.SetActive(true);
    }
}
