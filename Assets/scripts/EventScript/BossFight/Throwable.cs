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
    private int randomA;
    private float timer = 0.0f;
    private float waitTime = 3.0f;
    public int cooldown;
    private bool colaCheck = false;
    bool failsafe = true;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        startPos = new Vector3(transform.position.x, transform.position.y);
        randomA = Random.Range(0, 2);
        switch (randomA)
        {
            case 0:
                ThrowChips(); //Chips attack shoots in an arch, dodgeable up
                break;
            case 1:
                ThrowCola(); //Cola attack shoots downwards onto the player, dodgeable left
                break;
            default:
                Debug.Log("Switch broke");
                break;
        }

    }


    void Update()
    {
        timer += Time.deltaTime;
        if (colaCheck && timer >= 0.2f)
        {
            rBody.velocity = new Vector2(0, 0);
            transform.Translate(new Vector3(750, 415, 0));    //Cola attack move Up
            colaCheck = false;
        }

        if (transform.position.y <= -400.0f)
        {
            Destroy(gameObject);
        }

    }
    public void ThrowChips()
    {
        sRend.sprite = chipsSprite;
        rBody.velocity = new Vector2(600, -50);
    }
    public void ThrowCola()
    {
        colaCheck = true;
        sRend.sprite = colaSprite;
        rBody.velocity = new Vector2(170, 700);
    }

}
