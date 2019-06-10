using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hospital : MonoBehaviour
{
    public Text nurseWords;
    private float timer = 0.0f;
    public float dialogWaitTime;
    private LinkedList<string> startDialog;
    private LinkedListNode<string> listNode;

    void Start()
    {
        startDialog = new LinkedList<string>();
        startDialog.AddLast("Player: \n Hello, I need your help!");
        startDialog.AddLast("Nurse: \n What happened?");
        startDialog.AddLast("Player: \n I met the welldigger from our village and he has blurry vision.");
        startDialog.AddLast("Nurse: \n That could mean that his blood sugar is to low and he needs something sweet to increase it again.");
        startDialog.AddLast("Nurse: \n I could come with you and measure his blood sugar.");
        startDialog.AddLast("Player: \n Thanks. I still have to buy water for my mother. After the screening of the well digger I could go to the supermarket for both.");
        startDialog.AddLast("Nurse: \n Okay let’s go.");
        GameManager.Instance.goalDone = true;


        listNode = startDialog.First;
        nurseWords.text = listNode.Value;
    }

    // Update is called once per frame
    void Update()
    {
        if (true /*GameManager.Instance.seenNurse != true*/)
        {
            timer += Time.deltaTime;
            if (timer > dialogWaitTime)
            {
                try
                {
                    nurseWords.text = listNode.Value;
                    listNode = listNode.Next;
                }
                catch (System.NullReferenceException) { /*GameManager.Instance.seenNurse = true; //update objective */ SceneManager.LoadScene("Well"); }
                finally { timer -= dialogWaitTime; }


            }
        }
        if (timer > dialogWaitTime) { timer -= dialogWaitTime; }
    }
}
