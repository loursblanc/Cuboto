using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUiHandler : MonoBehaviour
{

    [SerializeField] private TMP_Text PlayerNameText;
    [SerializeField] private TMP_Text ScoreText;
    
    
    private void Awake()
    {
        setPlayerNameText();
        setScore(0);
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
