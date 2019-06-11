using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemScript : MonoBehaviour
{

    public GameObject item;

    public bool firstrow;

    public bool firstcolumn;
    public bool secondcolumn;
    public bool thirdcolumn;
    public bool fourthcolumn;

    public bool inCart;
    private List<GameObject> cart;
    public float sugar;
    private int returnS = 0;
    private int cSize = 0;

    private Vector3 newPos;
    private Vector3 orgPos;
    private Quaternion quat;

    private void Awake()
    {
        
        quat = item.transform.rotation;
        orgPos = item.transform.position;
    }


    private void Update()
    {
        if(GameManager.Instance.marketEventCompleted == false || GameManager.Instance.secCheckStranger == true)
        {

            CartScript cscript = item.transform.parent.GetComponent<CartScript>();
            cart = cscript.foods;
            returnS = cscript.returns+1;
            cSize = cscript.cartSize;

            if (firstcolumn == true )
            {
            
                newPos.x = item.transform.position.x+450;
                newPos.y = item.transform.position.y+250;
                newPos.z = item.transform.position.z;
            

                if (firstrow == false )
                {
                    newPos.x = item.transform.position.x + 450;
                    newPos.y = item.transform.position.y + 420;
                    newPos.z = item.transform.position.z;
                }
            }

            if (secondcolumn == true )
            {
                newPos.x = item.transform.position.x + 300;
                newPos.y = item.transform.position.y + 250;
                newPos.z = item.transform.position.z;

                if (firstrow == false )
                {
                    newPos.x = item.transform.position.x + 300;
                    newPos.y = item.transform.position.y + 420;
                    newPos.z = item.transform.position.z;
                }
            }

            if (thirdcolumn == true )
            {
                newPos.x = item.transform.position.x + 150;
                newPos.y = item.transform.position.y + 220;
                newPos.z = item.transform.position.z;

                if (firstrow == false )
                {
                    newPos.x = item.transform.position.x + 150;
                    newPos.y = item.transform.position.y + 420;
                    newPos.z = item.transform.position.z;
                }
            }

            if (fourthcolumn == true)
            {
                newPos.x = item.transform.position.x;
                newPos.y = item.transform.position.y + 220;
                newPos.z = item.transform.position.z;

                if (firstrow == false)
                {
                    newPos.x = item.transform.position.x+15;
                    newPos.y = item.transform.position.y + 420;
                    newPos.z = item.transform.position.z;
                }
            }
        }

    }

    private void OnMouseOver()
    {
        if(GameManager.Instance.marketEventCompleted == false || GameManager.Instance.secCheckStranger  == true)
        {
            if(Input.GetMouseButtonDown(0) && inCart == false && cart.Count <= cSize-1)
            {
                inCart = true;
                cart.Add(item);
                item.transform.SetPositionAndRotation(newPos, quat);
            }

            else if (Input.GetMouseButtonDown(0) && inCart == true && returnS <= 3)
            {
                inCart = false;
                cart.Remove(item);
                item.transform.SetPositionAndRotation(orgPos, quat);

                if(returnS == 3)
                {
                    // playsounds error
                }
            }
        }
    }



}
