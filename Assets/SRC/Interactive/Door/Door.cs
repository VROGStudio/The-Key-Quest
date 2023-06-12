using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource close, open;

    private void Start()
    {
        newEvents.Sub("DoorKey", DoorKey);
    }

    // If the player has the key, display the game-ending window when clicked; otherwise, display the window prompting to find the key.
    private void OnMouseDown()
    {
        if (GameMeneger.Instance.isPlay)
        {
            if (GameMeneger.Instance.haveKey)
                WindowObject.instance.OpenWindow(2);
            else
            {
                WindowObject.instance.OpenWindow(1);
                close.Play();
            }
        }
    }

    private bool DoorKey()
    {
        open.Play();
        newEvents.UnSub("DoorKey", DoorKey);
        GameMeneger.Instance.GameOver();
        return true;
    }
}
