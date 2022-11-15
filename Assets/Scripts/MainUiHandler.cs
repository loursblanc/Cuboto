using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainUiHandler : MonoBehaviour
{

    [SerializeField] private TMP_Text PlayerNameText;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text GameStatusText;
    [SerializeField] private Image PauseMenu; 
    
    
    private void Start()
    {
        setPlayerNameText();
        setScore(000);
        
        GameManager.ScoreChanged += delegate (int currentScore)
        {
            ScoreText.text = " Score : " + currentScore;
        };

        GameManager.GameStateChanged += delegate (GameManager.GAMESTATE gameState)
        {
            GameStatusText.text = " Game "  + gameState;
        };
      }


    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.GameState != GameManager.GAMESTATE.Over)
        {

            if(GameManager.GameState == GameManager.GAMESTATE.Running)
            {
                GameManager.GameState = GameManager.GAMESTATE.Paused;
                PauseMenu.gameObject.SetActive(true);
            }
            else
            {
                GameManager.GameState = GameManager.GAMESTATE.Running;
                PauseMenu.gameObject.SetActive(false);

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
