using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isStarted;
    public bool isLosed;
    public bool isFinished;
    public bool isTutorial;
    public int curCoins;
    public Player player;
    private Managers _managers;

    public int Tutorial
    {
        get => PlayerPrefs.GetInt("Tutorial", 1);
        set => PlayerPrefs.SetInt("Tutorial", value);
    }

    public int Coins
    {
        get => PlayerPrefs.GetInt("Coins", 0);
        set => PlayerPrefs.SetInt("Coins", value);
    }

    private void Start()
    {
        _managers = Managers.instance;
        Time.timeScale = 1f;
        _managers.uiManager.startCoinText.text = Coins.ToString();
    }

    public void AddCoin()
    {
        Coins++;
        curCoins++;
        _managers.uiManager.startCoinText.text = Coins.ToString();
    }

    public void StartGame()
    {
        isStarted = true;
        player.canMove = true;
        player.playerAnimator.SetBool("Started",true);
        _managers.uiManager.StartGame();
    }

    public void LoseGame()
    {
        isLosed = true;
        player.canMove = false;
        _managers.uiManager.LoseGameInTime(1f);
    }

    public void FinishGame()
    {
        isFinished = true;
        player.canMove = false; 
        player.playerAnimator.SetBool("Finished",true);
        player.NulliftVelocity();
        _managers.uiManager.FinishGameInTime(1f);
        _managers.uiManager.finishCoinText.text = curCoins.ToString();
    }

    public void OpenPause()
    {
        Time.timeScale = 0f;
        _managers.uiManager.OpenPause();
    }

    public void ClosePause()
    {
        Time.timeScale = 1f;
        _managers.uiManager.ClosePause();
    }

    public bool CanPlay()
    {
        return isStarted && !isLosed && !isFinished;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Levels levels = Levels.instance;
        levels.SetNewTenTimeLevel();
        levels.SetNewLevel();
        Restart();
    }
}
