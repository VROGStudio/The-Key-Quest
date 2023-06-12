using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowObject : MonoBehaviour
{
    public static WindowObject instance;
    [SerializeField] private WindowSO[] so;
    [SerializeField] private TextMeshProUGUI title, option1, option2;
    private int index;

    private void Awake()
    {
        instance = this;
        // Hide the window at the start of the game
        transform.localScale = Vector3.zero;
    }

    // Open the window with the specified data index
    public void OpenWindow(int i)
    {
        index = i;
        title.text = so[i].Tittle;
        option1.text = so[i].Option1;
        option2.text = so[i].Option2;

        transform.localScale = Vector3.one;
        GameMeneger.Instance.canGo = false;
    }

    
    public void CloseWindow()
    {
        transform.localScale = Vector3.zero;
        GameMeneger.Instance.canGo = true;
    }

    
    public void Option1()
    {
        CloseWindow();
    }

    
    public void Option2()
    {
        // Trigger the event associated with the selected option
        newEvents.Induce(so[index].ID);
        CloseWindow();
    }
}
