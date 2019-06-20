using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hospital : MonoBehaviour
{
    public Text nurseWords;
    public GameObject speechBubble;
    private float timer;
    public float dialogWaitTime;
    private int counter = 0;
    private bool[] speechOrder = {true,false, true, false, false, true, false};
    public GameObject nurse;
    public GameObject villageArrow;
    private LinkedList<string> startDialog;
    private LinkedListNode<string> listNode;

    void Start()
    {
        startDialog = new LinkedList<string>();
        timer = dialogWaitTime;
        villageArrow.SetActive(false);
        if (GameManager.Instance.seenNurse != true)
        {
            startDialog.AddLast("Player: \n Hello, I need your help!");
            startDialog.AddLast("Nurse: \n What happened?");
            startDialog.AddLast("Player: \n I met the welldigger from our village and he has blurry vision.");
            startDialog.AddLast("Nurse: \n That could mean that his blood sugar is to low and he needs something sweet to increase it again.");
            startDialog.AddLast("Nurse: \n I could come with you and measure his blood sugar.");
            startDialog.AddLast("Player: \n Thanks. I still have to buy water for my mother. After the screening of the well digger I could go to the supermarket for both.");
            startDialog.AddLast("Nurse: \n Okay let’s go.");
            GameManager.Instance.goalDone = true;
        }
        else
        {
            nurse.SetActive(false);
            villageArrow.SetActive(true);
            counter = 0;
            startDialog.AddLast("Player: \n The Nurse must be with the Welldigger.");
        }

        listNode = startDialog.First;
        //nurseWords.text = listNode.Value;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.seenNurse != true)
        {
            timer += Time.deltaTime;
            if (timer > dialogWaitTime)
            {
                try
                {
                    AdjustOrb();
                    nurseWords.text = listNode.Value;
                    listNode = listNode.Next;
                    

                }
                catch (System.NullReferenceException) {
                    GameManager.Instance.seenNurse = true;
                    SceneManager.LoadScene("Well");
                }
                finally { timer -= dialogWaitTime; }


            }
        }
        if (timer > dialogWaitTime) { timer -= dialogWaitTime; }
    }
    void AdjustOrb()
    {
        try
        {
            if (speechOrder[counter])
            {
                speechBubble.transform.localScale = new Vector3(-0.49217f, -0.49217f, 0.49217f);
                nurseWords.transform.localScale = new Vector3(-1, -1, 1);
            }
            else
            {
                speechBubble.transform.localScale = new Vector3(0.49217f, -0.49217f, 0.49217f);
                nurseWords.transform.localScale = new Vector3(1, -1, 1);
            }
            counter++;
        }
        catch (System.IndexOutOfRangeException) { }
    }
}
