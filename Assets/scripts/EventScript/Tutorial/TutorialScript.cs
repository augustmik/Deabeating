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

    public GameObject back;

    public GameObject GoalBG;

    public GameObject Nurse;
    public GameObject Mother;

    public Text Message;
    public Sprite view2;
    public Sprite view3;
    
    private float timer;

    private float heightT;
    private float heightP;

    private RectTransform rectP;
    private RectTransform rectT;

    private Vector3 view2Pos;
    private Quaternion rot;
    private float nurseposy;
    private SpriteRenderer renderer;

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

    }

    private void Update()
    {

        if(SceneManager.GetActiveScene().name == "Home_tutorial")
        {
            timer += Time.deltaTime;
            if(timer > 1.5f)
            {
                Message.text = " \n  Hello, \n \n  Don't forget your screening in the hospital today! \n \n  -Nurse";
            }
        }

     

        if(SceneManager.GetActiveScene().name == "Hospital_tutorial" && GameManager.Instance.leftHome == true)
        {
            timer += Time.deltaTime;
            if (timer > 0f && timer < 3f)
            {
                Message.text = " Nurse: \n  Hey, you are right on time for the appointment! \n  Please sit down!";
            }

            if(timer > 3f && timer < 7f)
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

           
                if(timer > 10f)
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

                if (timer > 28f)
                {
                    back.SetActive(true);
                    GoalBG.transform.SetPositionAndRotation(new Vector3(920, 600, 0), rot);
                    Message.text = "    Nurse: \n You're welcome! ";
                    GameManager.Instance.tutorialFinished = true;
                }



        }


        
    }



    






}
