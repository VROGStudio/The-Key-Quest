using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emiter : MonoBehaviour
{
    void Awake()
    {
        newEvents.Create("Start");
        
                
                
                
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            newEvents.Induce("Start");
            
            
            
            
           
            
        }

        




    }
}
