using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;
using Newtonsoft.Json.Linq;

public class SaveDataTestEdit
{
    private string expectedJsonFilePath = Application.persistentDataPath + "/expected.json";
    private string savePath = Application.persistentDataPath + "/savefile.json";

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        int NumberOfHighScoreGenerated = 2;
        ScoreData scoreExpected = new ScoreData();
        

        for (int i = 0; i<NumberOfHighScoreGenerated; i++)
        {
            HighScore highScoreExpected = new HighScore();
            highScoreExpected.PlayerName = "PlayerNameTest" + i;
            highScoreExpected.Score = i;
            scoreExpected.highScores.Add(highScoreExpected);
        }

        string jsonExpected = JsonUtility.ToJson(scoreExpected);
        File.WriteAllText(expectedJsonFilePath, jsonExpected);

        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }

    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        File.Delete(expectedJsonFilePath);
    }
    
    [Test]
    public void SaveHighScoreIsOkTest()
    {
        SaveData saveData = new();
        saveData.SaveHighScores();
        JToken received = File.ReadAllText(savePath);
        JToken expected = File.ReadAllText(expectedJsonFilePath);
        Assert.IsTrue(JToken.DeepEquals(received, expected));        
    }

    [Test]
    public void SaveHigScoreFileIsCreatedTest()
    {
        SaveData saveData = new();
        saveData.SaveHighScores();
        Assert.IsTrue(File.Exists(savePath));
    }
    

}
