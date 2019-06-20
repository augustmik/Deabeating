using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WellDigger : MonoBehaviour
{
    public Text diggerWords;
    private float timer;
    public float dialogWaitTime;
    private int[] speechOrder;//0 - player, 1 - nurse, 2 - digger
    public GameObject speechBubble;
    private int counter = 0;
    public GameObject nurse;
    public GameObject villageArrow;


    //public GameObject WellBubble; // -Annika
    //public GameObject PlayerNurseBubble; //-Annika
    private LinkedList<string> startDialog;
    private LinkedListNode<string> listNode;
    private void Awake()
    {
        nurse.SetActive(false);
        villageArrow.SetActive(false);
    }
    void Start()
    {
        //PlayerNurseBubble.SetActive(false); //-Annika
        counter = 0;
        timer = dialogWaitTime;
        startDialog = new LinkedList<string>();
        if (GameManager.Instance.gotWater == true)
        {
            startDialog.AddLast("Welldigger: \n Thank you so much, i'm feeling much better.");
            startDialog.AddLast("Player: \n You’re welcome.");
            speechOrder = new int[] { 2, 0};
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
            speechOrder = new int[] { 2, 0, 1, 1, 2, 1};

        }
        else
        {
            startDialog.AddLast("Welldigger: \n   Is someone there?");
            startDialog.AddLast("Player: \n Hi, I’m " + GameManager.Instance.playerName + ".Can I help you ?");
            startDialog.AddLast("Welldigger: \n I’m not sure. Sometimes suddenly I get this blurry vision, but I don’t know what to do.");
            startDialog.AddLast("Player: \n I think the nurse told me about this. I have to see her, maybe she will know what to do.");
            speechOrder = new int[] { 2, 0, 2, 0};
        }

        listNode = startDialog.First;
        //diggerWords.text = listNode.Value;
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
                    AdjustOrb();
                    diggerWords.text = listNode.Value;
                    listNode = listNode.Next;
                } catch (System.NullReferenceException) {
                    if (GameManager.Instance.firstCheckStranger == false)
                    {
                        GameManager.Instance.secCheckStranger = true;
                        villageArrow.SetActive(true);
                    }
                    GameManager.Instance.firstCheckStranger = false; //update objective
                    villageArrow.SetActive(true);
                }
                finally { timer -= dialogWaitTime; }

                
            }
        }
        if (timer > dialogWaitTime) { timer -= dialogWaitTime; }
    }
    void AdjustOrb()
    {
        Debug.Log("Adjusts");
        try
        {
            if (speechOrder[counter] == 0) //player
            {
                speechBubble.transform.localPosition = new Vector3(-443, 160, 0);
                Debug.Log("player");

                speechBubble.transform.localScale = new Vector3(0.3119941f, 0.34208f, 0.34208f);
                diggerWords.transform.localScale = new Vector3(1.2245f, 1, 1);
            }
            else if (speechOrder[counter] == 1) //nurse
            {
                speechBubble.transform.localPosition = new Vector3(-217, -17, 0);
                Debug.Log("nurse");

                speechBubble.transform.localScale = new Vector3(-0.3119941f, -0.34208f, 0.34208f);
                diggerWords.transform.localScale = new Vector3(-1.2245f, -1, 1);
            }
            else //digger
            {
                speechBubble.transform.localPosition = new Vector3(-443, 160, 0);
                Debug.Log("digger");

                speechBubble.transform.localScale = new Vector3(-0.3119941f, 0.34208f, 0.34208f);
                diggerWords.transform.localScale = new Vector3(-1.2245f, 1, 1);
            }
            counter++;
        }
        catch (System.IndexOutOfRangeException) { }
    }
}
