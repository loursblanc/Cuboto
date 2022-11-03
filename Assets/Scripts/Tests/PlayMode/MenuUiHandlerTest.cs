using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


public class MenuUiHandlerTest
{

    private MenuUiHandler menuInstance;
    private NavigateUiHandler navigateInstance;


    [OneTimeSetUp]
    public void Setup()
    {
        GameObject goMenu = new GameObject();
        menuInstance = goMenu.AddComponent<MenuUiHandler>();
        menuInstance.playerNameImputField = goMenu.AddComponent<TMPro.TMP_InputField>();
        goMenu.AddComponent<MainManager>();
        GameObject goNavigate = new GameObject();
        navigateInstance =  goNavigate.AddComponent<NavigateUiHandler>();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        GameObject.Destroy(menuInstance);
    }


    [UnityTest]
    public IEnumerator SetPlayerNameIsOk()
    {
        menuInstance.playerNameImputField.text = "UnitTest";
        menuInstance.SetPlayerName();
        navigateInstance.StartMain();
        yield return null;
        Assert.AreEqual(MainManager.Instance.PlayerName, "UnitTest");

    }

}
