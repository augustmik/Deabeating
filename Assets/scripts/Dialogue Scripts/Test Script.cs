using Ink.Runtime;
using UnityEngine;

public class Script : MonoBehaviour
{
    public bool tää = false;

    // Set this file to your compiled json asset
    public TextAsset inkAsset;

    // The ink story that we're wrapping
    Story _inkStory;

    void Awake()
    {
        if(tää == true)
        {
            _inkStory = new Story(inkAsset.text);
        }
    }
}