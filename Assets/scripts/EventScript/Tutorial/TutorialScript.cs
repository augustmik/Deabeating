using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
   
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

    public GameObject BG;
    public GameObject panel;
    public GameObject text;

    public GameObject back;

    public GameObject GoalBG;

    public GameObject Nurse;
    public GameObject Mother;

    public Text Message;
    public Sprite view2;
    public Sprite view3;

    private float timer;
    private int messageNumber = 0;

    private float heightT;
    private float heightP;

    private RectTransform rectP;
    private RectTransform rectT;

    private Vector3 view2Pos;
    private Quaternion rot;
    private float nurseposy;
    private SpriteRenderer renderer;

    private List<string> messages;
    private void Start()
    {
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

        Debug.Log("asd");
       
    }

    private void Update()
    {
        Debug.Log(messages[0].ToString());
        if (SceneManager.GetActiveScene().name == "Home_tutorial")
        {
            Message.text = "asdasdasd";
        }

       if (SceneManager.GetActiveScene().name == "Hospital_tutorial" && GameManager.Instance.leftHome == true)
        {
            Message.text = "asdasdasd";
            showNextMessage();
           /* timer += Time.deltaTime;
            if (timer > 0f && timer < 3f)
            {
                Message.text = " Nurse: \n  Hey, you are right on time for the appointment! \n  Please sit down!";
            }

            if (timer > 3f && timer < 7f)
            {
                Nurse.transform.localScale = new Vector3(111, 111, 0);
                Nurse.transform.SetPositionAndRotation(view2Pos, rot);
                Destroy(Mother);
                renderer.sprite = view2;

                Message.text = "    Nurse: \n   Next I will measure your blood sugar. \n  And don’t be afraid. \n It may sting a bit, but it won’t hurt.";
            }

            if (timer > 7f)
            {
                Nurse.transform.SetPositionAndRotation(new Vector3(0, 1000, 0), rot);
                renderer.sprite = view3;

                rectP.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightP);
                rectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightT);
                Message.text = "    Nurse: \n   Soon we will see a value. \n    If you haven’t eaten anything for 8 - 10 hours, \n  the normal value is 5,6. \n     So if your value is higher we know you might have diabetes.";
            }


            if (timer > 10f)
            {
                renderer.sprite = view2;
                Nurse.transform.SetPositionAndRotation(view2Pos, rot);
                Message.text = "    Nurse: \n   So now we know that you have diabetes.";
            }

            if (timer > 13f)
            {
                Message.text = "  Mother: \n  How could I have discovered this myself?";
            }

            if (timer > 16f)
            {
                Message.text = "    Nurse: \n   A few symptoms could be that you have a blurry vision and that you are tired a lot";
            }

            if (timer > 19f)
            {
                Message.text = "    Mother: \n  So this means if my son gets for example blurry vision he has diabetes as well?";
            }

            if (timer > 22f)
            {
                Message.text = "    Nurse: \n   No, this is not always the case.\n  So when something like this happens, \n    always be sure to see a adoctor as soon as possible";
            }

            if (timer > 25f)
            {
                Message.text = "    Mother: \n  Thank you for your help! ";
            }

            if (messageNumber == 9)
            {
                back.SetActive(true);
                GoalBG.transform.SetPositionAndRotation(new Vector3(920, 600, 0), rot);
                Message.text = "    Nurse: \n You're welcome! ";
                GameManager.Instance.tutorialFinished = true;
            }*/

        }
    }


    
    public void showNextMessage()
    {
        Debug.Log(messages[messageNumber]);
        Message.text = messages[messageNumber];
        messageNumber++;

        /*switch (messageNumber)
        {
            case 1:
                Nurse.transform.localScale = new Vector3(111, 111, 0);
                Nurse.transform.SetPositionAndRotation(view2Pos, rot);
                Destroy(Mother);
                renderer.sprite = view2;
                break;

            case 2:
                Nurse.transform.SetPositionAndRotation(new Vector3(0, 1000, 0), rot);
                renderer.sprite = view3;
                rectP.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightP);
                rectT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heightT);
                break;

            case 3:
                renderer.sprite = view2;
                Nurse.transform.SetPositionAndRotation(view2Pos, rot);
                break;

            case 9:
                back.SetActive(true);
                GoalBG.transform.SetPositionAndRotation(new Vector3(920, 600, 0), rot);
                Message.text = "    Nurse: \n You're welcome! ";
                GameManager.Instance.tutorialFinished = true;
                break;*/

        }
    }
        
    

