using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateUiHandler : MonoBehaviour
{

    public void StartMain()
    {
        GameManager.Restart();
        SceneManager.LoadScene(1);
    }

    public void StartHighScore()
    {
        SceneManager.LoadScene(2);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); 
        #endif
    }



}
