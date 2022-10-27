using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUiHandler : MonoBehaviour
{
    public void StartNew()
    {
        SceneManager.LoadScene(1);  
    }

    public void Exit()
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
    #else
        Application.Quit(); // original code to quit Unity player
    #endif
    }

    public void startHighScore()
    {
        SceneManager.LoadScene(2);
    }
}
