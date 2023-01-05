using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text gameText;
    public bool gameWon;
    
    private int previousScore = 0;
    private PlayerController playerControllerScript;

    private void Start()
    {
        gameWon = false;
        playerControllerScript = FindObjectOfType<PlayerController>();
        scoreText.text = "Score: " + playerControllerScript.GetScore().ToString();
        previousScore = playerControllerScript.GetScore();
    }

    private void Update()
    {
        if (previousScore != playerControllerScript.GetScore())
        {
            scoreText.text = "Score: " + playerControllerScript.GetScore().ToString();
            previousScore = playerControllerScript.GetScore();
            CheckWin();
        }

        GameIsOver();
    }

    private void CheckWin()
    {
        if (playerControllerScript.GetScore() == 3)
        {
            gameWon = true;
        }
    }

    private void GameIsOver()
    {
        if (playerControllerScript.GetGameOver() && gameWon)
        {
            // player won the game
            gameText.text = "You've Won!";
        } else if (playerControllerScript.GetGameOver() && !gameWon)
        {
            // player lost the game
            gameText.text = "Game Over!";
        }
    }
}
