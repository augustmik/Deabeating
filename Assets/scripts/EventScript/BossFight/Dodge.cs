using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    public bool playerMove = false;
    public GameObject playerObject;
    public float dodgeAmount;
    public float waitTime;
    DodgeUp otherScript;
    private float timer = 0.0f;
    void Start()
    {
        GameObject otherGO = GameObject.Find("DodgeArrowUp");
        otherScript = otherGO.GetComponent<DodgeUp>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime && playerMove == true)
        {
            playerObject.transform.Translate(dodgeAmount*-1, 0, 0);
            timer = timer - waitTime;
            playerMove = false;
        }

        if (timer > waitTime * 2) { timer -= waitTime * 2; }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && playerMove == false && otherScript.playerMove == false)
        {
            playerMove = true;
            playerObject.transform.Translate(dodgeAmount,0,0);
            timer = 0.0f;
        }
    }
}
