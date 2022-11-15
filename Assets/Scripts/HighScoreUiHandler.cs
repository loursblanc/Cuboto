using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUiHandler : MonoBehaviour
{

    [SerializeField] private TMP_Text ListHighScores;


    private void Awake()
    {
        DisplayHighScores();
    }


    public void DisplayHighScores()
    {
        if(MainManager.Instance != null) { 
            int y = 1;
            ListHighScores.text = "";

            List<HighScore> highScores = MainManager.Instance.HighScores;
            for(int i = highScores.Count - 1; i > 0; i--)
            {
                string playerName = highScores[i].PlayerName;
                String playerNameWithoutSpace = highScores[i].PlayerName.Replace(" ", String.Empty);
                if (playerName == null || playerNameWithoutSpace == "")
                {
                    playerName = "John Doe";
                }
                ListHighScores.text += y + "  " + playerName + "  " + highScores[i].Score + "\n";
                y++;
            }
        }
    }
}
