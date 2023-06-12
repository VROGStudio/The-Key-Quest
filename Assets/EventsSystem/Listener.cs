using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Listener : MonoBehaviour
{
    void Start()
    {
        newEvents.Sub("Start", EventListen);

    }
    public bool EventListen()
    {

        
            Debug.Log("Start");
            newEvents.UnSub("Start", EventListen);
        



        return true;
    
    }


}
