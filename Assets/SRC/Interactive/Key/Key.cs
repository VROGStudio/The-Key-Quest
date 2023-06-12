using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void Start()
    {
        newEvents.Sub("Key", Option);
    }

    private void OnMouseDown()
    {
        if (GameMeneger.Instance.isPlay)
            WindowObject.instance.OpenWindow(3);
    }

    private bool Option()
    {
        GameMeneger.Instance.haveKey = true;
        newEvents.UnSub("Key", Option);
        Destroy(gameObject);
        return true;
    }
}
