using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Listener : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //Obserowanie Eventu
        newEvents.Sub("Start", EventListen);

    }

    // Update is called once per frame
    void Update()
    {

        
            
                




    }

    public bool EventListen()
    {

        
            Debug.Log("Start");
            //Koniec obserwacji Eventu
            newEvents.UnSub("Start", EventListen);
        



        return true;
    
    }


}
