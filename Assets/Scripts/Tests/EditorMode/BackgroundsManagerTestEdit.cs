using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class BackgroundsManagerTestEdit
{
  
    BackgroundsManager backgroundsManager;

    [OneTimeSetUp]
     public void OneTimeSetUp()
    {
        GameObject go = new GameObject();
        backgroundsManager = go.AddComponent<BackgroundsManager>();
        GameObject[] backGroundPrefabs = Resources.LoadAll<GameObject>("Background");
        backgroundsManager.TypeOfBackgrounds = new List<GameObject>();
        backgroundsManager.TypeOfBackgrounds.AddRange(backGroundPrefabs);
    }

    [Test]
    public void CreateBackgroudIsOkTest()
    {
        backgroundsManager.CreateBackgroud();       
        GameObject dayBackGround = GameObject.Find(backgroundsManager.PrefixName + BackgroundsManager.NumberOfActiveBackgroundIsInstanciated%2);        
        Assert.IsTrue(dayBackGround.tag == "Background");
    }

    [Test]
    public void CreateBackGroundInGoodPlaceTest()
    {
        backgroundsManager.CreateBackgroud();
        GameObject dayBackGround = GameObject.Find(backgroundsManager.PrefixName + BackgroundsManager.NumberOfActiveBackgroundIsInstanciated % 2);
        Assert.AreEqual(dayBackGround.transform.position, backgroundsManager.BackGroundSpawn);
    }

    [Test]
    public void CreateBackGroundNotNullTest()
    {
        backgroundsManager.CreateBackgroud();
        GameObject dayBackGround = GameObject.Find(backgroundsManager.PrefixName + BackgroundsManager.NumberOfActiveBackgroundIsInstanciated % 2);        
        Assert.IsNotNull(dayBackGround);
    }

}
