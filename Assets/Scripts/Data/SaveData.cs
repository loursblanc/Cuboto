using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SaveData
{

    string SaveHighScorefilePath = Application.persistentDataPath + "/savefile.json";


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
       
        File.WriteAllText(SaveHighScorefilePath, json);

    }

    public List<HighScore> loadHighScores()
    {

        ScoreData scoreData = new ScoreData(); ;
        if (File.Exists(SaveHighScorefilePath))
        {
            string json = File.ReadAllText(SaveHighScorefilePath);
            scoreData = JsonUtility.FromJson<ScoreData>(json);
        }
        else
        {
            scoreData.highScores = new List<HighScore>() { };
        }
        
        return scoreData.highScores;

    }
}
