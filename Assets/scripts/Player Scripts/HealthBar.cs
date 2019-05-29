using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar;
    private static float size = .1f;
    private void Start()
    {
        Transform bar = transform.Find("Bar");
        bar.localScale = new Vector3(size, 1f);
        //size = .1f;
    }

    public Transform getBar()
    {
        return bar;
    }
  
    public void SetSize (float sizeNormalized) //from  0 to 1
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetSizeL() //from  0 to 1
    {
        Transform bar = transform.Find("Bar");
        size += .2f;
        if (size >= 1f) { size = 1f; }
        bar.localScale = new Vector3(size, 1f);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
