using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUiHandler : MonoBehaviour
{

    [SerializeField] private TMP_InputField playerNameImputField;

    public void StartNew()
    {
        SceneManager.LoadScene(1);  
    }

    public void startHighScore()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
    #else
        Application.Quit(); // original code to quit Unity player
    #endif
    }

   

    public void SetPlayerName()
    {
        MainManager.Instance.PlayerName = playerNameImputField.text;
    }
}
