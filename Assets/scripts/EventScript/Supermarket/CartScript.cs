using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CartScript : MonoBehaviour
{


    private float sugarlevel = 0f;
    public int returns = 0;

    //public Image returnsI;
    public Image sugarLevel;
    public List<GameObject> foods = new List<GameObject>();
    public Text sugar;
    public Text Mom;
    public Text returnText;
    public Text cartText;

    public int cartSize = 4;

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

        sugarLevel.fillAmount = 0;

    }

    private void Update()
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
            sugarlevel += bananaS.sugar/20;
            sugarLevel.fillAmount += sugarlevel;
            onetime1 = true;
            onetime9 = false;
        }else if(!foods.Contains(banana) && onetime1 && returns <= 3)
        {
            returns++;
            sugarlevel -= bananaS.sugar / 20;
            sugarLevel.fillAmount -= bananaS.sugar / 20;
            onetime1 = false;}

        if (foods.Contains(coke) && !onetime2)
        {
            sugarlevel += cokeS.sugar / 20;
            sugarLevel.fillAmount += sugarlevel;
            onetime2 = true;
            onetime9 = false;
        }else if (!foods.Contains(coke) && onetime2 && returns <= 3)
        {
            returns++;
            sugarlevel -= cokeS.sugar / 20;
            sugarLevel.fillAmount -= cokeS.sugar / 20;
            onetime2 = false;}

        if (foods.Contains(chips) && !onetime3)
        {
            sugarlevel += chipsS.sugar / 20;
            sugarLevel.fillAmount += sugarlevel;
            onetime3 = true;
            onetime9 = false;
        }else if (!foods.Contains(chips) && onetime3 && returns <= 3)
        {
            returns++;
            sugarlevel -= chipsS.sugar / 20;
            sugarLevel.fillAmount -= chipsS.sugar / 20;
            onetime3 = false;}

        if (foods.Contains(orange) && !onetime4)
        {
            sugarlevel += orangeS.sugar / 20;
            sugarLevel.fillAmount += sugarlevel;
            onetime4 = true;
            onetime9 = false;
        }else if (!foods.Contains(orange) && onetime4 && returns <= 3)
        {
            returns++;
            sugarlevel -= orangeS.sugar / 20;
            sugarLevel.fillAmount -= orangeS.sugar / 20;
            onetime4 = false;}

        if (foods.Contains(apple) && !onetime5)
        {
            sugarlevel += appleS.sugar / 20;
            sugarLevel.fillAmount += sugarlevel;
            onetime5 = true;
            onetime9 = false;
        }else if (!foods.Contains(apple) && onetime5 && returns <= 3)
        {
            returns++;
            sugarlevel -= appleS.sugar / 20;
            sugarLevel.fillAmount -= appleS.sugar / 20;
            onetime5 = false;}

        if (foods.Contains(water) && !onetime6)
        {
            sugarlevel += waterS.sugar / 20;
            sugarLevel.fillAmount += sugarlevel;
            onetime6 = true;
            onetime9 = false;
        }else if (!foods.Contains(water) && onetime6 && returns <= 3)
        {
            returns++;
            sugarlevel -= waterS.sugar / 20;
            sugarLevel.fillAmount -= waterS.sugar / 20;
            onetime6 = false;}

        if (foods.Contains(beer) && !onetime7)
        {
            sugarlevel += beerS.sugar / 20;
            sugarLevel.fillAmount += sugarlevel;
            onetime7 = true;
            onetime9 = false;
        }else if (!foods.Contains(beer) && onetime7 && returns <= 3)
        {
            returns++;
            sugarlevel -= beerS.sugar / 20;
            sugarLevel.fillAmount -= beerS.sugar / 20;
            onetime7 = false;}

        if (foods.Contains(honey) && !onetime8)
        {
            sugarlevel += honeyS.sugar / 20;
            sugarLevel.fillAmount += sugarlevel;
            onetime8 = true;
            onetime9 = false;
        }else if (!foods.Contains(honey) && onetime8 && returns <= 3)
        {
            returns++;
            sugarlevel -= honeyS.sugar / 20;
            sugarLevel.fillAmount -= honeyS.sugar / 20;
            onetime8 = false;}


        switch(returns)
        {
            case 1:
                returnText.text = "You have used one out of three returns";
                break;

            case 2:
                returnText.text = "You have used two out of three returns";
                break;

            case 3:
                returnText.text = "You have used three out of three returns";
                break;
        }

        if(foods.Count == cartSize)
        {
           cartText.text = "Your cart is full";
        }else if (foods.Count !=cartSize)
        {
            cartText.text = "";
        }
     
        sugar.text = "Sugarlevel: " + sugarlevel.ToString();
       



    }

  

}
