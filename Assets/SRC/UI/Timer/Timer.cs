using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimeUI, BestTimeUI;
    private Animator animator;
    private bool isBreakBest = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        // Display the best time if it's not the first game
        BestTimeUI.text = ShowTime(GameMeneger.Instance.BestTime);
        if (GameMeneger.Instance.isFirst)
            animator.SetBool("FirstGame", true);

        newEvents.Sub("Start Game", ResetTimeUI);
    }

    private void Update()
    {
        // Display the current time
        TimeUI.text = ShowTime(GameMeneger.Instance.time);

        // Trigger the animation for breaking the best time record
        if (GameMeneger.Instance.BestTime <= GameMeneger.Instance.time && !isBreakBest)
            BreakBestTime();
    }

    // Trigger the animation for breaking the best time record
    public void BreakBestTime()
    {
        if (!isBreakBest)
        {
            animator.SetBool("BreakBest", true);
            isBreakBest = true;
        }
    }

    // Reset the Timer UI
    public bool ResetTimeUI()
    {
        BestTimeUI.text = ShowTime(GameMeneger.Instance.BestTime);
        isBreakBest = false;
        animator.SetBool("BreakBest", false);
        animator.SetBool("FirstGame", false);
        return false;
    }

    // Function to display time in the format mm:ss:ms
    public static string ShowTime(float time)
    {
        float sec = (time - (time % 1)) % 60;
        float min = ((time - (time % 1)) / 60) - ((time - (time % 1)) / 60) % 1;
        float milisec = time * 100 % 100;

        string minS = min.ToString("00");
        string secS = sec.ToString("00");
        string milisecS = milisec.ToString("00");

        return minS + ":" + secS + ":" + milisecS;
    }
}
