using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private float timer = 0.0f;
    public GameObject attackPrefab;
    public GameObject locationObj;
    public float waitTime;
    private int randomA;
    private Vector3 startPos;

    void Start()
    {
        startPos = locationObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            //timeNow = timer;
            Instantiate(attackPrefab, startPos, Quaternion.identity);

            timer = timer - waitTime;
        }
    }
}
