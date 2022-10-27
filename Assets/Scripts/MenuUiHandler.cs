using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUiHandler : MonoBehaviour
{
    public void StarNew()
    {
        SceneManager.LoadScene(1);  
    }
}
