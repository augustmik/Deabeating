using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    public Sprite colaSprite;
    public Sprite chipsSprite;
    private Vector3 startPos;
    public GameObject attackObj;
    public Camera cam;
    public int cooldown;
    private int randomA;
    bool failsafe = true;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>(); //onBecameinvisible
        startPos = new Vector3(-252, 266);//attackObj.transform.position;

        StartCoroutine(MyCoroutine(cooldown));


        //From: -263, 266; To: 544, -261
    }


    IEnumerator MyCoroutine(int duration)
    {
        while (true)
        {
            failsafe = true;
            randomA =  Random.Range(0, 2);
            switch (randomA)
            {
                case 0:
                    ThrowChips();
                    break;
                case 1:
                    ThrowCola();
                    break;
                default:
                    Debug.Log("Switch broke");
                    break;
            }
            //public static Object Instantiate(Object original);

            Resets();
            yield return new WaitForSeconds(duration);    //Wait one frame
        }
    }

    void Update()
    {
        if (failsafe == true)
        {
            if (attackObj.transform.position.y >= 2f * cam.orthographicSize) //reset for cola
            {
                //Debug.Log("Resets");
                rBody.velocity = new Vector2(0, 0);
                attackObj.transform.Translate(new Vector3(750, 415, 0));
                failsafe = false;
            }
        }
    }
    public void ThrowChips()
    {
        sRend.sprite = chipsSprite;
        rBody.velocity = new Vector2(600, -50);
    }
    public void ThrowCola()
    {
        sRend.sprite = colaSprite;
        rBody.velocity = new Vector2(170, 700);
    }
    public void Resets()
    {
        //GameObject penis = gameObject;
        Instantiate(gameObject);
        Destroy(gameObject);
    }
}
