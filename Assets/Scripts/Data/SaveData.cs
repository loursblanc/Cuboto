using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SaveData
{
    public void SaveHighScores()
    {

        ScoreData scoreData = new ScoreData();
        HighScore highScore = new HighScore();
        highScore.PlayerName = "PlayerNameTest0";
        highScore.Score = 0;
        scoreData.highScores.Add(highScore);

        highScore = new HighScore();
        highScore.PlayerName = "PlayerNameTest1";
        highScore.Score = 1;
        scoreData.highScores.Add(highScore);

       

        string json = JsonUtility.ToJson(scoreData);
        string filePath = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(filePath, json);

    }


}
