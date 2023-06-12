using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BestTimeUI, TimeUI;
    [SerializeField] private Animator animator, timer;
    [SerializeField] private TextMeshProUGUI text, button;
    [SerializeField] private GameObject BestTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
        text = timer.GetComponent<TextMeshProUGUI>();
        StartUI();
        newEvents.Sub("Game Over", Retry);
    }

    // Launches the menu after winning the game
    public bool Retry()
    {
        TimeUI.gameObject.SetActive(true);
        TimeUI.text = Timer.ShowTime(GameMeneger.Instance.time);
        if (GameMeneger.Instance.time < GameMeneger.Instance.BestTime)
            BestTime.SetActive(true);
        button.text = "Try Again";
        StartUI();

        return true;
    }

    // Launches the menu
    private void StartUI()
    {
        BestTimeUI.text = Timer.ShowTime(GameMeneger.Instance.BestTime);
        animator.SetBool("isOpen", true);
        BestTimeUI.gameObject.SetActive(true);
        if (GameMeneger.Instance.BestTime == 0 || GameMeneger.Instance.isFirst)
            BestTimeUI.gameObject.SetActive(false);

        text.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        animator.SetBool("isOpen", false);
        StartCoroutine(InduceGame());
    }

    IEnumerator InduceGame()
    {
        // Launches the countdown
        yield return new WaitForSeconds(1);
        BestTime.SetActive(false);
        text.gameObject.SetActive(true);
        timer.PlayInFixedTime("Start Game");
        text.text = "3";
        yield return new WaitForSeconds(1);
        text.text = "2";
        yield return new WaitForSeconds(1);
        text.text = "1";
        yield return new WaitForSeconds(1);
        text.text = "Start!!!";
        yield return new WaitForSeconds(1);
        text.gameObject.SetActive(false);

        newEvents.Induce("Start Game");
    }

    public void Quit()
    {
        

        Application.Quit();


    }
}
