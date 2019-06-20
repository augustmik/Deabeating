using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public GameObject BG;
    public GameObject panel;
    public GameObject text;
    public GameObject TutorialPanel;
    public GameObject back;
    public GameObject villageArrow;
    public GameObject button; // -Annika

    private string msg1 = " \n  Hello, \n \n  Don't forget your screening in the hospital today! \n \n  -Nurse";

    private string msg2 = "    Nurse: \nHey, you are right on time for the appointment! \nPlease sit down!";
    private string msg3 = "    Nurse: \nNext I will measure your blood sugar. \nAnd don’t be afraid. \nIt may sting a bit, but it won’t hurt.";
    private string msg4 = "    Nurse: \nSoon we will see a value. \nIf you haven’t eaten anything for 8-10,\nhours the normal value is 5,6. \nSo if your value is higher we know you might have diabetes.";
    private string msg5 = "    Nurse: \nSo now we know that you have diabetes.";
    private string msg6 = "    Mother: \nHow could I have discovered this myself?";
    private string msg7 = "    Nurse: \nA few symptoms could be that you have blurry vision or that you are tired.\nBut it is always important to get screened\nif you suspect you might have diabetes.";
    private string msg8 = "    Mother: \nSo this means if my son gets for example blurry vision he has diabetes as well?";
    private string msg9 = "    Nurse: \nNo, this is not always the case.\nSo when something like this happens, \nalways be sure to see a a doctor as soon as possible";
    private string msg10 = "   Mother: \nThank you for your help! ";

    public GameObject GoalBG;

    public GameObject Nurse;
    public GameObject NurseSitting;
    public GameObject MotherSitting;
    public GameObject Mother;
    public GameObject MotherHoldingPhone;
    
   

    public GameObject bubbleNurse;
    public GameObject bubbleMother;

    public Text TutorialText;
    public Text MessageNurse;
    public Text MessageMother;

    

    public Sprite view2;
    public Sprite view3;
    public Sprite view3_w_number;
    public Sprite view4;

    private float timer;
  
    private float heightT;
    private float heightP;

    private RectTransform rectP;
    private RectTransform rectT;

    private Vector3 panelorgPos;

    private Vector3 view2Pos;
    private Quaternion rot;
    private float nurseposy;
    private SpriteRenderer renderer;

    //For Mother - Annika
    private Vector3 view1Pos;
    private Quaternion dontknow;
    private float motherposy;
    private SpriteRenderer rend;

    private List<string> messages;
    private bool done = false;

    private void Start()
    {
        //MotherHoldingPhone.SetActive(false);
        bubbleMother.SetActive(false);
        messages = new List<string>();
        villageArrow.SetActive(false);
        panelorgPos = panel.transform.position;
        back.SetActive(false);
        GoalBG.transform.SetPositionAndRotation(new Vector3(0, 1000, 0), rot);
        renderer = BG.GetComponent<SpriteRenderer>();
        view2Pos = Nurse.transform.position;
        nurseposy = Nurse.transform.position.y - 300f;
        view2Pos.y = nurseposy;

        rectP = panel.GetComponent<RectTransform>();
        rectT = text.GetComponent<RectTransform>();

        heightP = rectP.sizeDelta.y + 75f;
        heightT = rectT.sizeDelta.y + 75f;

        messages.Add(msg1);
        messages.Add(msg2);
        messages.Add(msg3);
        messages.Add(msg4);
        messages.Add(msg5);
        messages.Add(msg6);
        messages.Add(msg7);
        messages.Add(msg8);
        messages.Add(msg9);
        messages.Add(msg10);

        MessageMother.fontSize = 27;
        MessageNurse.fontSize = 23;
    }

    private void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "Home_tutorial")
        {
           
            if (done == false)
            {
                bubbleMother.SetActive(true);
                 MessageMother.text = msg1;
                 TutorialText.text = "Hello " + PlayerManager.playernamestr + " and welcome to Diabeating!\nIn this game you are going to learn about Diabetes.\n" +
                                "In the top left you will see your current goal \nFrom the bottom right button, you will get to the village. \n" +
                                "Dialogue boxes will display the name of the speaker\nso you always know who is talking.";
            }
           
        }

       if (SceneManager.GetActiveScene().name == "Hospital_tutorial" && GameManager.Instance.leftHome == true)
        {
            NurseSitting.SetActive(false);
            MotherSitting.SetActive(false);
           timer += Time.deltaTime;
            if (timer > 0f && timer < 5f)
            {
                MessageNurse.text = msg2;
            }

            if (timer > 5f && timer < 10f)
            {
                NurseSitting.SetActive(true); // -Annika
                //NurseSitting.transform.localScale = new Vector3(111, 111, 0);
                //NurseSitting.transform.SetPositionAndRotation(view2Pos, rot);
                Destroy(Mother);
                //Nurse.SetActive(false);
                
                Nurse.SetActive(false); //-Annika
                renderer.sprite = view2;

                MessageNurse.text = msg3;
            }

            if (timer > 10f)
            {
                NurseSitting.SetActive(false); // -Annika
                //Nurse.transform.SetPositionAndRotation(new Vector3(0, -400, 0), rot);
                renderer.sprite = view3;
                bubbleNurse.SetActive(true); //-Annika
                //rectP.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightP);
                //rectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightT);
                MessageNurse.text = msg4;
            }

            if (timer > 13f)
            {
             
                renderer.sprite = view3_w_number;
                
            }


            if (timer >17f)
            {
                NurseSitting.SetActive(true); // -Annika
                renderer.sprite = view2;
                //Nurse.transform.SetPositionAndRotation(view2Pos, rot);
                MessageNurse.text = msg5;
            }

            if (timer > 25f)
            {
                NurseSitting.SetActive(false); // -Annika
                MotherSitting.SetActive(true); //Annika
                renderer.sprite = view4; // -Annika
                bubbleMother.SetActive(true);
                bubbleNurse.SetActive(false);


                //rectP.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightP-80f);
                //rectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightT-80f);
                //rectP.SetPositionAndRotation(new Vector3(1000,500,0),rot);
                //rectT.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);
                MessageMother.text = msg6;
            }

            if (timer > 32f)
            {
                NurseSitting.SetActive(true); // -Annika
                MotherSitting.SetActive(false); //Annika
                renderer.sprite = view2; //-Annika
                bubbleMother.SetActive(false);
                bubbleNurse.SetActive(true);

                //rectP.SetPositionAndRotation(panelorgPos, rot);
                //rectT.SetPositionAndRotation(panelorgPos, rot);

                //rectP.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightP - 80f);
                //rectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightT - 80f);
                //rectP.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);
                //rectT.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);

                MessageNurse.text = msg7;
            }

            if (timer > 41f)
            {
                MotherSitting.SetActive(true); //Annika
                NurseSitting.SetActive(false); // -Annika
                renderer.sprite = view4; //-Annika
                bubbleMother.SetActive(true);
                bubbleNurse.SetActive(false);

                //rectP.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);
                //rectT.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);
                MessageMother.text = msg8;
            }

            if (timer > 48f)
            {
                MotherSitting.SetActive(false); //Annika
                NurseSitting.SetActive(true); // -Annika
                renderer.sprite = view2;//-Annika
                bubbleMother.SetActive(false);
                bubbleNurse.SetActive(true);

                //rectP.SetPositionAndRotation(panelorgPos, rot);
                //rectT.SetPositionAndRotation(panelorgPos, rot);
                MessageNurse.text = msg9;
            }

            if (timer > 54f)
            {
                MotherSitting.SetActive(true); //Annika
                NurseSitting.SetActive(false); // -Annika
                renderer.sprite = view4; //-Annika
                bubbleMother.SetActive(true);
                bubbleNurse.SetActive(false);

                //rectP.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);
                //rectT.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);
                MessageMother.text = msg10;
            }

            if (timer > 58f)
            {
                MotherSitting.SetActive(false); //Annika
                NurseSitting.SetActive(true); // -Annika
                renderer.sprite = view2; //-Annika
                bubbleMother.SetActive(false);
                bubbleNurse.SetActive(true);

                //rectP.SetPositionAndRotation(panelorgPos, rot);
                //rectT.SetPositionAndRotation(panelorgPos, rot);

                back.SetActive(true);
                GoalBG.transform.SetPositionAndRotation(new Vector3(1000, 550, 0), rot);
                //GoalBG.transform.SetPositionAndRotation(new Vector3(0, 1000, 0), rot);//-Annika
                MessageNurse.text = "    Nurse: \n You're welcome! ";
                GameManager.Instance.tutorialFinished = true;
                GameManager.Instance.goalDone = true;
            }

        }
    }

    public void NextTutorial()
    {
        Destroy(button); //-Annika
        done = true;
        TutorialText.fontSize = 30;
        GameManager.Instance.goalDone = true;
        villageArrow.SetActive(true);
        TutorialText.text = "Now you need to go to the hospital with your mother!\n" +
                            "Go to the village by clicking the houses on the right";

        //Mother changes to Mother that looks to the player and speaks to him -Annika
        Mother.SetActive(false);

        //MotherHoldingPhone.SetActive(true);
        MessageMother.fontSize = 30;
        MessageMother.text = "Mother: \n Let's go to the hospital " + PlayerManager.playernamestr +"!";

    }

    
    }
        
    

