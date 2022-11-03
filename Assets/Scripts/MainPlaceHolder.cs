using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlaceHolder : MonoBehaviour
{
         
    public void AddScore() {
        if(MainManager.Instance == null)
        {
            GameObject go = new GameObject();
            go.AddComponent<MainManager>();
        }
        MainManager.Instance.Score ++ ;        
    }
  
}
