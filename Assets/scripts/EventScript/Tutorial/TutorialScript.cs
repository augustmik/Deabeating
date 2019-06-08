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

    private string msg1 = " \n  Hello, \n \n  Don't forget your screening in the hospital today! \n \n  -Nurse";
    private string msg2 = " Nurse: \n  Hey, you are right on time for the appointment! \n  Please sit down!";
    private string msg3 = "    Nurse: \n   Next I will measure your blood sugar. \n  And don’t be afraid. \n It may sting a bit, but it won’t hurt.";
    private string msg4 = "    Nurse: \n   Soon we will see a value. \n    If you haven’t eaten anything for 8 - 10 hours, \n  the normal value is 5,6. \n     So if your value is higher we know you might have diabetes.";
    private string msg5 = "    Nurse: \n   So now we know that you have diabetes.";
    private string msg6 = "  Mother: \n  How could I have discovered this myself?";
    private string msg7 = "    Nurse: \n   A few symptoms could be that you have a blurry vision and that you are tired a lot";
    private string msg8 = "    Mother: \n  So this means if my son gets for example blurry vision he has diabetes as well?";
    private string msg9 = "    Nurse: \n   No, this is not always the case.\n  So when something like this happens, \n    always be sure to see a adoctor as soon as possible";
    private string msg10 = "    Mother: \n  Thank you for your help! ";

    public GameObject GoalBG;

    public GameObject Nurse;
    public GameObject Mother;

    public Text TutorialText;
    public Text Message;
    public Sprite view2;
    public Sprite view3;

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

    private List<string> messages;
    private void Start()
    {
        messages = new List<string>();
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
       
    }

    private void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "Home_tutorial")
        {
        //Debug.Log("home_tut");
            Message.text = msg1;
            Message.text = "asd";
            TutorialText.text = "asdasd";
            TutorialText.text = "Hello " + PlayerManager.playernamestr + " welcome to Diabeating, a game where you are going to learn about Diabetes. \n" +
                                "In the top left you will see your current goal you are trying to accomplish. \n    In the bottom right corner is a button where you can get to the village. \n" +
                                "Dialogue boxes will display the name of the speaker so you always know who is talking.";
           
        }

       if (SceneManager.GetActiveScene().name == "Hospital_tutorial" && GameManager.Instance.leftHome == true)
        {
         
           timer += Time.deltaTime;
            if (timer > 0f && timer < 3f)
            {
                Message.text = msg2;
            }

            if (timer > 3f && timer < 7f)
            {
                Nurse.transform.localScale = new Vector3(111, 111, 0);
                Nurse.transform.SetPositionAndRotation(view2Pos, rot);
                Destroy(Mother);
                renderer.sprite = view2;

                Message.text = msg3;
            }

            if (timer > 7f)
            {
                Nurse.transform.SetPositionAndRotation(new Vector3(0, 1000, 0), rot);
                renderer.sprite = view3;

                rectP.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightP);
                rectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightT);
                Message.text = msg4;
            }


            if (timer > 10f)
            {
                renderer.sprite = view2;
                Nurse.transform.SetPositionAndRotation(view2Pos, rot);
                Message.text = msg5;
            }

            if (timer > 15f)
            {
                rectP.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightP-80f);
                rectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightT-80f);
                rectP.SetPositionAndRotation(new Vector3(1000,500,0),rot);
                rectT.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);
                Message.text = msg6;
            }

            if (timer > 20f)
            {
                rectP.SetPositionAndRotation(panelorgPos, rot);
                rectT.SetPositionAndRotation(panelorgPos, rot);
                Message.text = msg7;
            }

            if (timer > 25f)
            {
                rectP.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);
                rectT.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);
                Message.text = msg8;
            }

            if (timer > 30f)
            {
                rectP.SetPositionAndRotation(panelorgPos, rot);
                rectT.SetPositionAndRotation(panelorgPos, rot);
                Message.text = msg9;
            }

            if (timer > 35f)
            {
                rectP.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);
                rectT.SetPositionAndRotation(new Vector3(1000, 500, 0), rot);
                Message.text = msg10;
            }

            if (timer > 40f)
            {
                rectP.SetPositionAndRotation(panelorgPos, rot);
                rectT.SetPositionAndRotation(panelorgPos, rot);
                back.SetActive(true);
                GoalBG.transform.SetPositionAndRotation(new Vector3(920, 600, 0), rot);
                Message.text = "    Nurse: \n You're welcome! ";
                GameManager.Instance.tutorialFinished = true;
            }

        }
    }


    
    }
        
    

