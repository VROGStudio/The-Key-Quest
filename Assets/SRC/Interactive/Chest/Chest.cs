using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Transform key;

    private void Start()
    {
        newEvents.Sub("Chest", Option);
    }

    private void OnMouseDown()
    {
        if (GameMeneger.Instance.isPlay)
            WindowObject.instance.OpenWindow(0);
    }

    // After opening the chest, it is destroyed and a key is created
    private bool Option()
    {
        GetComponent<AudioSource>().Play();
        Instantiate(key, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
        newEvents.UnSub("Chest", Option);
        Destroy(gameObject);
        return true;
    }
}
