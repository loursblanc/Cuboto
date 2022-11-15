using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BackgroundManagerTest : MonoBehaviour
{
    BackgroundsManager backgroundsManager;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Debug.Log("OneTime");
        GameObject go = new GameObject();
        backgroundsManager = go.AddComponent<BackgroundsManager>();
        GameObject[] backGroundPrefabs = Resources.LoadAll<GameObject>("Background");
        backgroundsManager.TypeOfBackgrounds = new List<GameObject>();
        backgroundsManager.TypeOfBackgrounds.AddRange(backGroundPrefabs);
    }

    [UnityTest]
    public IEnumerator DestroyBackgroundIsOkTest()
    {
        GameObject  toDestroy= Instantiate(backgroundsManager.TypeOfBackgrounds[0], Vector3.zero, Quaternion.identity);
        toDestroy.tag = "Background";
        toDestroy.name = "toDestroy";
        backgroundsManager.DestroyBackground(toDestroy);
        yield return null;
        Assert.IsNull(GameObject.Find("toDestroy"));
    }

    [UnityTest]
    public IEnumerator NotDestroyBackgroundIfTagIsNotBackGroundTest()
    {
        GameObject toDestroy = Instantiate(backgroundsManager.TypeOfBackgrounds[0], Vector3.zero, Quaternion.identity);
        toDestroy.tag = "Player";
        toDestroy.name = "toDestroy";
        backgroundsManager.DestroyBackground(toDestroy);
        yield return null;
        Assert.IsNotNull(GameObject.Find("toDestroy"));
    }

}
