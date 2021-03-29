﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Text distanceTraveled;
    [SerializeField] Text coinsCollected;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;
    [SerializeField] GameObject gameMusic;
    [SerializeField] GameObject sky;


    
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        gameMusic.SetActive(false);
        sky.SetActive(false);
        float roundedDistance = Mathf.Ceil(player.distanceTraveled);
        distanceTraveled.text = roundedDistance.ToString();
        coinsCollected.text = player.collectedCoins.ToString();

    }
 public void GameRestart()
    {
        
        SceneManager.LoadScene("EndlessRunner");
        Debug.Log("Restart the game");
    }
}
