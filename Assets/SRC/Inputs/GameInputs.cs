using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : MonoBehaviour
{

    private InputsMeneger inputsMeneger;
    
    void Awake()
    {
        //Inicialize Input System
        inputsMeneger = new();
        inputsMeneger.RTS.Enable();
    }

    public Vector2 GetMovement()
    {

        Vector2 movement = inputsMeneger.RTS.move.ReadValue<Vector2>();

        return movement.normalized;
        
    }

    public float GetRotate()
    { 
    
        float rotate = inputsMeneger.RTS.rotate.ReadValue<float>();
        
        return rotate;
    
    }


}
