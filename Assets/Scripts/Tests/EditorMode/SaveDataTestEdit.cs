using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

public class SaveDataTestEdit
{
    private string expectedJsonFilePath = Application.persistentDataPath + "/expected.json";
    private string saveFilePath = Application.persistentDataPath + "/savefile.json";
    //private string loadTestFilePath = Application.persistentDataPath + "/loadTest.json";

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        int NumberOfHighScoreGenerated = 2;
        ScoreData scoreExpected = new ScoreData();

        scoreExpected.highScores = createHighScoresForTest(NumberOfHighScoreGenerated);
        
        string jsonExpected = JsonUtility.ToJson(scoreExpected);
        File.WriteAllText(expectedJsonFilePath, jsonExpected);
        //File.WriteAllText(loadTestFilePath, jsonExpected);

        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }

    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        if (File.Exists(expectedJsonFilePath))
        {
            File.Delete(expectedJsonFilePath);
        }
        
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }
    }

    [Test]
    public void SaveHighScoreIsOkTest()
    {
        SaveData saveData = new();
        saveData.SaveHighScores();
        JToken received = File.ReadAllText(saveFilePath);
        JToken expected = File.ReadAllText(expectedJsonFilePath);
        Assert.IsTrue(JToken.DeepEquals(received, expected));
    }

    [Test]
    public void SaveHigScoreFileIsCreatedTest()
    {
        SaveData saveData = new();
        saveData.SaveHighScores();
        Assert.IsTrue(File.Exists(saveFilePath));
    }

    [Test]
    public void LoadHigScoreIsOkTest()
    {
        int NumberOfHighScoreGenerated = 2;
        ScoreData scoreExpected = new ScoreData();
        scoreExpected.highScores = createHighScoresForTest(NumberOfHighScoreGenerated);
        string jsonExpected = JsonUtility.ToJson(scoreExpected);
        File.WriteAllText(saveFilePath, jsonExpected);

        SaveData saveData = new();
        List<HighScore> highScores = saveData.loadHighScores();


        List<HighScore> firstNotSecond = highScores.Except(scoreExpected.highScores).ToList();
        List<HighScore> secondNotFirst = scoreExpected.highScores.Except(highScores).ToList();

        Assert.IsTrue(!firstNotSecond.Any() && !secondNotFirst.Any());
    }

    [Test]
    public void loadIfNoFileTest()
    {
        SaveData saveData = new();

        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }

        List<HighScore> test = saveData.loadHighScores();

        Assert.IsFalse(test.Any());
    }

    private List<HighScore> createHighScoresForTest(int NumberOfHigScoreItems)
    {
        List<HighScore> highScores = new List<HighScore>();

        for (int i = 0; i < NumberOfHigScoreItems; i++)
        {
            HighScore highScore = new HighScore() { PlayerName = "PlayerNameTest" + i, Score = i };
            highScores.Add(highScore);
        }

        return highScores;
    }

   
}
