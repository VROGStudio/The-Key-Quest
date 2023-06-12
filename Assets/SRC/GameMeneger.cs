using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMeneger : MonoBehaviour
{
    [SerializeField] public float time { get; private set; }
    [SerializeField] public float BestTime { get; private set; }
    public bool isPlay { get; private set; }
    public bool canGo { get; set; } = true;
    public bool isFirst { get; private set; }
    public bool haveKey { get; set; } = false;
    private bool haveKeyUI = false;
    [SerializeField] private GameObject key;

    public static GameMeneger Instance;

    private void Awake()
    {
        // Creating events
        newEvents.Create("Start Game");
        newEvents.Create("Pause Game");
        newEvents.Create("Continue Game");
        newEvents.Create("Game Over");
        newEvents.Create("Chest");
        newEvents.Create("Door");
        newEvents.Create("DoorKey");
        newEvents.Create("Key");
        // Initial settings
        key.SetActive(false);
        Instance = this;
        isPlay = false;
        BestTime = 0;
        // Loading the result and checking if it's the first game
        isFirst = !LoadData();
        canGo = true;
    }

    private void Start()
    {
        newEvents.Sub("Start Game", StartGame);
        newEvents.Sub("Continue Game", ContinueGame);
    }

    private void Update()
    {
        if (isPlay)
        {
            time += Time.deltaTime;
        }

        // Pausing the game
        if (Input.GetKeyDown(KeyCode.Escape) && isPlay)
            StopGame();

        // Displaying/hiding the key icon
        if (haveKey && !haveKeyUI)
        {
            key.SetActive(true);
            haveKeyUI = true;
        }
        else if (!haveKey && haveKeyUI)
        {
            key.SetActive(false);
            haveKeyUI = false;
        }
    }

    private void StopGame()
    {
        isPlay = false;
        newEvents.Induce("Pause Game");
    }

    private bool ContinueGame()
    {
        canGo = true;
        isPlay = true;
        return true;
    }

    public void GameOver()
    {
        newEvents.Induce("Game Over");
        // Setting the best time to the current time
        if (time < BestTime)
            BestTime = time;
        if (isFirst)
            BestTime = time;
        SaveData();
        isFirst = false;
        isPlay = false;
        key.SetActive(false);
        haveKeyUI = false;
    }

    private bool StartGame()
    {
        // Initial settings
        haveKey = false;
        canGo = true;
        isPlay = true;
        time = 0;
        key.SetActive(false);
        haveKeyUI = false;
        return true;
    }

    // Loading the best time, also returns if it's the first game
    private bool LoadData()
    {
        if (PlayerPrefs.HasKey("BestTime"))
        {
            BestTime = PlayerPrefs.GetFloat("BestTime");
            if (BestTime != 0)
                return true;
        }
        return false;
    }

    // Saving the best time
    private void SaveData()
    {
        PlayerPrefs.SetFloat("BestTime", BestTime);
        PlayerPrefs.Save();
    }
}
