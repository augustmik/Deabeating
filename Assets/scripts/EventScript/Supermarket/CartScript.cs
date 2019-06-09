using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CartScript : MonoBehaviour
{

    private float sugarlevel = 0f;
    public int returns = 0;


    
    public Image returnIcon1;
    public Image returnIcon2;
    public Image returnIcon3;

    //public Image returnsI;

    public Image sugarLevel;
    public List<GameObject> foods = new List<GameObject>();
    public Text sugar;
    public Text Mom;
    public Text returnText;
    public Text cartText;
    public GameObject arrow;
    public Button finish;

    public int cartSize = 4;

    Vector3 arrowPos;
    Quaternion quat;


    private bool onetime1 = false;
    private bool onetime2 = false;
    private bool onetime3 = false;
    private bool onetime4 = false;
    private bool onetime5 = false;
    private bool onetime6 = false;
    private bool onetime7 = false;
    private bool onetime8 = false;
    private bool onetime9 = false;



    private bool removed = false;


    private void Start()
    {
        if (GameManager.Instance.secCheckStranger) { C2EndEvent(); } //Check hook, this works, now it just skips the event
        arrowPos = arrow.transform.position;
        quat = arrow.transform.rotation;
        sugarLevel.fillAmount = 0;


    }

    private void Update()
    {

        marketHandler();

    }

    public void Finish()
    {
        if (arrowPos.x > -990 - 460f && arrowPos.x < -940 - 460f)
        {
            GameManager.Instance.lowRed = true;
            
        }
        else if (arrowPos.x > -940 - 460f && arrowPos.x < -905 - 460f)
        {
            GameManager.Instance.lowOrange = true;
            
        }
        else if (arrowPos.x > -905 - 460f && arrowPos.x < -885 - 460f)
        {
            GameManager.Instance.lowYellow = true;
           

        }
        else if (arrowPos.x > -885 - 460f && arrowPos.x < -860 - 460f)
        {
            GameManager.Instance.Green = true;
         

        }
        else if (arrowPos.x > -860 - 460f && arrowPos.x < -840 - 460f)
        {
            GameManager.Instance.highYellow = true;
            

        }
        else if (arrowPos.x > -840 - 460f && arrowPos.x < -805 - 460f)
        {
            GameManager.Instance.highOrange = true;
          

        }
        else if (arrowPos.x > -805 - 460f)
        {
            GameManager.Instance.highRed = true;
           
        }

        GameManager.Instance.marketEventCompleted = true;
        returnText.text = "YOU CAN GO HOME NOW";
    }

    public void BacktoVillage()
    {
        SceneManager.LoadScene("Village");
    }

    //Event is accessible when GameManager.Instance.secCheckStranger == true, need water for mom and something sweet for welldigger
    public void C2EndEvent()
    {
        GameObject banana = GameObject.Find("Banana");
        GameObject coke = GameObject.Find("Coke");
        GameObject chips = GameObject.Find("Chips");
        GameObject apple = GameObject.Find("Apple");
        GameObject water = GameObject.Find("Water");
        GameObject beer = GameObject.Find("Beer");
        GameObject honey = GameObject.Find("Honey");
        GameObject orange = GameObject.Find("Orange");

        ItemScript bananaS = banana.GetComponent<ItemScript>();
        ItemScript cokeS = coke.GetComponent<ItemScript>();
        ItemScript chipsS = chips.GetComponent<ItemScript>();
        ItemScript appleS = apple.GetComponent<ItemScript>();
        ItemScript waterS = water.GetComponent<ItemScript>();
        ItemScript beerS = beer.GetComponent<ItemScript>();
        ItemScript honeyS = honey.GetComponent<ItemScript>();
        ItemScript orangeS = orange.GetComponent<ItemScript>();

        marketHandler();
        if(foods.Contains(water) && foods.Contains(honey) && foods.Contains(coke))
        {
        GameManager.Instance.gotWater = true;
        SceneManager.LoadScene("Well");
        }
    }

    public void marketHandler()
    {
        if (GameManager.Instance.marketEventCompleted == false)
        {

            GameObject banana = GameObject.Find("Banana");
            GameObject coke = GameObject.Find("Coke");
            GameObject chips = GameObject.Find("Chips");
            GameObject apple = GameObject.Find("Apple");
            GameObject water = GameObject.Find("Water");
            GameObject beer = GameObject.Find("Beer");
            GameObject honey = GameObject.Find("Honey");
            GameObject orange = GameObject.Find("Orange");

            ItemScript bananaS = banana.GetComponent<ItemScript>();
            ItemScript cokeS = coke.GetComponent<ItemScript>();
            ItemScript chipsS = chips.GetComponent<ItemScript>();
            ItemScript appleS = apple.GetComponent<ItemScript>();
            ItemScript waterS = water.GetComponent<ItemScript>();
            ItemScript beerS = beer.GetComponent<ItemScript>();
            ItemScript honeyS = honey.GetComponent<ItemScript>();
            ItemScript orangeS = orange.GetComponent<ItemScript>();

            if (foods.Contains(banana) && !onetime1)
            {
                sugarlevel += bananaS.sugar / 20;
                sugarLevel.fillAmount += sugarlevel;
                arrowPos.x = arrowPos.x + bananaS.sugar * 5;
                onetime1 = true;
                onetime9 = false;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
            }
            else if (!foods.Contains(banana) && onetime1 && returns <= 3)
            {
                returns++;
                sugarlevel -= bananaS.sugar / 20;
                sugarLevel.fillAmount -= bananaS.sugar / 20;
                arrowPos.x = arrowPos.x - bananaS.sugar * 5;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
                onetime1 = false;
            }

            if (foods.Contains(coke) && !onetime2)
            {
                sugarlevel += cokeS.sugar / 20;
                sugarLevel.fillAmount += sugarlevel;
                arrowPos.x = arrowPos.x + cokeS.sugar * 9;
                onetime2 = true;
                onetime9 = false;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
            }
            else if (!foods.Contains(coke) && onetime2 && returns <= 3)
            {
                returns++;
                sugarlevel -= cokeS.sugar / 20;
                sugarLevel.fillAmount -= cokeS.sugar / 20;
                arrowPos.x = arrowPos.x - cokeS.sugar * 9;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
                onetime2 = false;
            }

            if (foods.Contains(chips) && !onetime3)
            {
                sugarlevel += chipsS.sugar / 20;
                sugarLevel.fillAmount += sugarlevel;
                arrowPos.x = arrowPos.x + chipsS.sugar * 4;
                onetime3 = true;
                onetime9 = false;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
            }
            else if (!foods.Contains(chips) && onetime3 && returns <= 3)
            {
                returns++;
                sugarlevel -= chipsS.sugar / 20;
                sugarLevel.fillAmount -= chipsS.sugar / 20;
                arrowPos.x = arrowPos.x - chipsS.sugar * 4;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
                onetime3 = false;
            }

            if (foods.Contains(orange) && !onetime4)
            {
                sugarlevel += orangeS.sugar / 20;
                sugarLevel.fillAmount += sugarlevel;
                arrowPos.x = arrowPos.x + orangeS.sugar * 7;
                onetime4 = true;
                onetime9 = false;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
            }
            else if (!foods.Contains(orange) && onetime4 && returns <= 3)
            {
                returns++;
                sugarlevel -= orangeS.sugar / 20;
                sugarLevel.fillAmount -= orangeS.sugar / 20;
                arrowPos.x = arrowPos.x - orangeS.sugar * 7;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
                onetime4 = false;
            }

            if (foods.Contains(apple) && !onetime5)
            {
                sugarlevel += appleS.sugar / 20;
                sugarLevel.fillAmount += sugarlevel;
                arrowPos.x = arrowPos.x + appleS.sugar * 5;
                onetime5 = true;
                onetime9 = false;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
            }
            else if (!foods.Contains(apple) && onetime5 && returns <= 3)
            {
                returns++;
                sugarlevel -= appleS.sugar / 20;
                sugarLevel.fillAmount -= appleS.sugar / 20;
                arrowPos.x = arrowPos.x - appleS.sugar * 5;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
                onetime5 = false;
            }

            if (foods.Contains(water) && !onetime6)
            {
                sugarlevel += waterS.sugar / 20;
                sugarLevel.fillAmount += sugarlevel;
                arrowPos.x = arrowPos.x + waterS.sugar * 5;
                onetime6 = true;
                onetime9 = false;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
            }
            else if (!foods.Contains(water) && onetime6 && returns <= 3)
            {
                returns++;
                sugarlevel -= waterS.sugar / 20;
                sugarLevel.fillAmount -= waterS.sugar / 20;
                arrowPos.x = arrowPos.x - waterS.sugar * 5;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
                onetime6 = false;
            }

            if (foods.Contains(beer) && !onetime7)
            {
                sugarlevel += beerS.sugar / 20;
                sugarLevel.fillAmount += sugarlevel;
                arrowPos.x = arrowPos.x + beerS.sugar * 5;
                onetime7 = true;
                onetime9 = false;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
            }
            else if (!foods.Contains(beer) && onetime7 && returns <= 3)
            {
                returns++;
                sugarlevel -= beerS.sugar / 20;
                sugarLevel.fillAmount -= beerS.sugar / 20;
                arrowPos.x = arrowPos.x - beerS.sugar * 5;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
                onetime7 = false;
            }

            if (foods.Contains(honey) && !onetime8)
            {
                sugarlevel += honeyS.sugar / 20;
                sugarLevel.fillAmount += sugarlevel;
                arrowPos.x = arrowPos.x + honeyS.sugar * 10;
                onetime8 = true;
                onetime9 = false;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
            }
            else if (!foods.Contains(honey) && onetime8 && returns <= 3)
            {
                returns++;
                sugarlevel -= honeyS.sugar / 20;
                sugarLevel.fillAmount -= honeyS.sugar / 20;
                arrowPos.x = arrowPos.x - honeyS.sugar * 10;
                arrow.transform.SetPositionAndRotation(arrowPos, quat);
                onetime8 = false;
            }


            switch (returns)
            {
                case 1:
                    returnText.text = "You have used one out of three returns";
                    returnIcon1.color = Color.red;
                    break;

                case 2:
                    returnText.text = "You have used two out of three returns";
                    returnIcon2.color = Color.red;
                    break;

                case 3:
                    returnText.text = "You have used three out of three returns";
                    returnIcon3.color = Color.red;
                    break;
            }

            if (foods.Count == cartSize)
            {
                cartText.text = "Your cart is full";
                if (returns == 3)
                {
                    returnText.text = "Go home to give items to mommy";
                    GameManager.Instance.marketEventCompleted = true;


                    if (arrowPos.x > -970 - 460f && arrowPos.x < -940 - 460f)
                    {
                        GameManager.Instance.lowRed = true;

                    }
                    else if (arrowPos.x > -940 - 460f && arrowPos.x < -905 - 460f)
                    {
                        GameManager.Instance.lowOrange = true;

                    }
                    else if (arrowPos.x > -905 - 460f && arrowPos.x < -885 - 460f)
                    {
                        GameManager.Instance.lowYellow = true;

                    }
                    else if (arrowPos.x > -885 - 460f && arrowPos.x < -860 - 460f)
                    {
                        GameManager.Instance.Green = true;

                    }
                    else if (arrowPos.x > -860 - 460f && arrowPos.x < -840 - 460f)
                    {
                        GameManager.Instance.highYellow = true;

                    }
                    else if (arrowPos.x > -840 - 460f && arrowPos.x < -805 - 460f)
                    {
                        GameManager.Instance.highOrange = true;

                    }
                    else if (arrowPos.x > -805 - 460f)
                    {
                        GameManager.Instance.highRed = true;
                    }


                }
            }
            else if (foods.Count != cartSize)
            {
                cartText.text = "";
            }

            sugar.text = "Sugarlevel: " + sugarlevel.ToString();
        }

        /*else if (GameManager.Instance.mTimes != 1 && GameManager.Instance.marketEventCompleted == true)
        {
            returnText.text = "YOU HAVE NO BUSINESS HERES";
        }*/
    }

}
