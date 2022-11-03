using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


public class MenuUiHandlerTest
{

    private MenuUiHandler instance;


    [OneTimeSetUp]
    public void Setup()
    {
        GameObject go = new GameObject();
        instance = go.AddComponent<MenuUiHandler>();
        instance.playerNameImputField = go.AddComponent<TMPro.TMP_InputField>();
        go.AddComponent<MainManager>();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        GameObject.Destroy(instance);
    }

    
    [UnityTest]
    public IEnumerator StarNewGoGoodSceneTest()
    {
        instance.StartNew();
        yield return null;
        Assert.AreEqual(SceneManager.GetActiveScene().buildIndex, 1);
    }

    [UnityTest]
    public IEnumerator StartHighScoreGoGoodSceneTest()
    {
        instance.StartHighScore();
        yield return null;
        Assert.AreEqual(SceneManager.GetActiveScene().buildIndex, 2);
    }

    [UnityTest]
    public IEnumerator SetPlayerNameIsOk()
    {
        instance.playerNameImputField.text = "UnitTest";
        instance.SetPlayerName();
        instance.StartNew();
        yield return null;
        Assert.AreEqual(MainManager.Instance.PlayerName, "UnitTest");

    }

}
