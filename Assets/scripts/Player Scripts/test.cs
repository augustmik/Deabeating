using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class test : MonoBehaviour
{

    private Vector3 position;
    private float width;
    private float height;

    public GameObject clone;
    public GameObject dialogue;

    void Awake()
    {
        width = (float)Screen.width /2;
        height = (float)Screen.height/2;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void OnGUI()
    {
        // Compute a fontSize based on the size of the screen width.
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

        GUI.Label(new Rect(20, 20, width, height * 0.25f),
            "x = " + position.x.ToString("f2") +
            ", y = " + position.y.ToString("f2"));
    }

    private void Update()
    {
        if(Input.touchCount != 1)
        {
             Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Vector2 pos = touch.position;

                pos.x = (pos.x - width/2)/100;
                pos.y = (pos.y - height/2)/100;

                Vector2 asd = transform.position;
                if(pos == asd)
                {
                 position = new Vector2(pos.x+2, pos.y+2);
                }

               
                //clone = Instantiate(dialogue, transform.position, transform.rotation) as GameObject;
               
               
                // Position the cube.
                transform.position = position;
            }

        }
    }

}
