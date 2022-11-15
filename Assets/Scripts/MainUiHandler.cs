using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUiHandler : MonoBehaviour
{

    [SerializeField] private TMP_Text PlayerNameText;
    [SerializeField] private TMP_Text ScoreText;
    
    
    private void Start()
    {
        setPlayerNameText();
        setScore(000);
        
        GameManager.ScoreChanged += delegate (int currentScore)
        {
            ScoreText.text = " Score : " + currentScore;
        };
    }


    private void Update()
    {
            
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameManager.GameState == GameManager.GAMESTATE.Running)
            {
                GameManager.GameState = GameManager.GAMESTATE.Paused;
            }
            else
            {
                GameManager.GameState = GameManager.GAMESTATE.Running;
            }
        }
    }

    private void setPlayerNameText()
    {
        if (MainManager.Instance != null)
        {
            PlayerNameText.text = "Player Name : " + MainManager.Instance.PlayerName;
        }
            
    }

    private void setScore(int score)
    {
        if(MainManager.Instance != null)
        {
            ScoreText.text = " Score : " + score;
        }
    }
}
