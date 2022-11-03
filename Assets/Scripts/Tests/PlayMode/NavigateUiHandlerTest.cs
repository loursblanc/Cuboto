using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NavigateUiHandlerTest
{
    private NavigateUiHandler instance;


    [OneTimeSetUp]
    public void Setup()
    {
        GameObject go = new GameObject();
        instance = go.AddComponent<NavigateUiHandler>();
        go.AddComponent<MainManager>();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        GameObject.Destroy(instance);
    }

    [UnityTest]
    public IEnumerator StarMainGoGoodSceneTest()
    {
        instance.StartMain();
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
    public IEnumerator StartMenuGoGoodSceneTest()
    {
        instance.StartMenu();
        yield return null;
        Assert.AreEqual(SceneManager.GetActiveScene().buildIndex, 0);
    }

}
