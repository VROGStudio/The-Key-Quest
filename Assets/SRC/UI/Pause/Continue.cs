using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Continue : MonoBehaviour
{
    [SerializeField] private Animator animator, timer;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        newEvents.Sub("Pause Game", Pause);
        transform.localScale = Vector3.zero;
        animator = GetComponent<Animator>();
        animator.SetBool("isOpen", true);
        text = timer.GetComponent<TextMeshProUGUI>();
        text.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        animator.SetBool("isOpen", false);
        StartCoroutine(InduceGame());
    }

    private bool Pause()
    {
        WindowObject.instance.CloseWindow();
        transform.localScale = Vector3.one;
        animator.SetBool("isOpen", true);
        return true;
    }

    IEnumerator InduceGame()
    {
        // Start countdown
        yield return new WaitForSeconds(1);
        transform.localScale = Vector3.zero;
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

        newEvents.Induce("Continue Game");
    }
}
