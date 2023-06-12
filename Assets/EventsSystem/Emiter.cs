using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emiter : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //Tworzenie Eventu
        newEvents.Create("Start");
        
                
                
                
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            //Wywo³ywanie Eventu
            newEvents.Induce("Start");
            
            
            
            
           
            
        }

        




    }
}
