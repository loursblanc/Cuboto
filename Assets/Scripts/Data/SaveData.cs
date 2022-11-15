using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SaveData
{

    string SaveHighScorefilePath = Application.persistentDataPath + "/cubotoSave.json";


    public void SaveHighScores(int currentScore)
    {

        ScoreData scoreData = new ScoreData();
        //HighScore highScore = new HighScore();
        //highScore.PlayerName = "PlayerNameTest0";
        //highScore.Score = 0;
        //scoreData.highScores.Add(highScore);

        //highScore = new HighScore();
        //highScore.PlayerName = "PlayerNameTest1";
        //highScore.Score = 1;
        //scoreData.highScores.Add(highScore);
        List<HighScore> highScores = MainManager.Instance.HighScores;
        
        highScores.Add(new HighScore(MainManager.Instance.PlayerName, currentScore));

        if(highScores.Count > 1)
        {
            highScores.Sort((p1, p2) => p1.Score.CompareTo(p2.Score));
        }

        if(highScores.Count > 10)
        {
            //removes the lowest score
            highScores.RemoveAt(0);
        }

        //To do because of the limitation of the lists in the json by unity
        scoreData.highScores = highScores;
        string json = JsonUtility.ToJson(scoreData);
        File.WriteAllText(SaveHighScorefilePath, json);
    }

    public List<HighScore> LoadHighScores()
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
