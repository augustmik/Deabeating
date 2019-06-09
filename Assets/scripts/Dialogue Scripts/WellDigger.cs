using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WellDigger : MonoBehaviour
{
    public Text diggerWords;
    private float timer = 0.0f;
    public float dialogWaitTime;
    public GameObject nurse;
    private LinkedList<string> startDialog;
    private LinkedListNode<string> listNode;
    private void Awake()
    {
        nurse.SetActive(false);
    }
    void Start()
    {
        //diggerWords.text = "Welldigger: \n   Is there someone ?";
        startDialog = new LinkedList<string>();
        if (GameManager.Instance.gotWater == true)
        {
            startDialog.AddLast("Welldigger: \n Thank you so much, i'm feeling much better.");
            startDialog.AddLast("Player: \n You’re welcome.");

        }
        else if (GameManager.Instance.firstCheckStranger == false)
        {
            nurse.SetActive(true);
            startDialog.AddLast("Welldigger: \n" +GameManager.Instance.playerName + ", is it you again?");
            startDialog.AddLast("Player: \n Yes, and I brought the nurse to help you.");
            startDialog.AddLast("Nurse: \n It could be that you have diabetes. To know what I can do for you, I have to measure your blood sugar.It may sting a bit, but don’t worry, it won’t hurt.");
            //measure pics
            startDialog.AddLast("Nurse: \n Unfortunately you have diabetes, but at least we know now what to do.");
            startDialog.AddLast("Welldigger: \n Thanks for your help.");
            startDialog.AddLast("Nurse: \n " + GameManager.Instance.playerName + ", go get something sweet from the Market.");

        }
        else
        {
            startDialog.AddLast("Welldigger: \n   Is someone there?");
            startDialog.AddLast("Player: \n Hi, I’m " + GameManager.Instance.playerName + ".Can I help you ?");
            startDialog.AddLast("Welldigger: \n I’m not sure. Sometimes suddenly I get this blurry vision, but I don’t know what to do.");
            //second choice here
            startDialog.AddLast("Player: \n I think the nurse told me about this. I have to see her, maybe she will know what to do.");
            //update goals
        }

        listNode = startDialog.First;
        diggerWords.text = listNode.Value;
    }

    // Update is called once per frame
    void Update()
    {

        if (true /*GameManager.Instance.firstCheckStranger*/) {
            timer += Time.deltaTime;
            if (timer > dialogWaitTime)
            {
                try 
                {
                    diggerWords.text = listNode.Value;
                    listNode = listNode.Next;
                } catch (System.NullReferenceException) {
                    if (GameManager.Instance.firstCheckStranger == false)
                    {
                        GameManager.Instance.secCheckStranger = true;
                    }
                    GameManager.Instance.firstCheckStranger = false; //update objective

                }
                finally { timer -= dialogWaitTime; }

                
            }
        }
        if (timer > dialogWaitTime) { timer -= dialogWaitTime; }
    }
}
