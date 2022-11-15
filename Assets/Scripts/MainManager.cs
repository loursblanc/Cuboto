using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string PlayerName = "---";
    public List<HighScore> HighScores;
    //public int Score = 0; 

    private void Awake()
    {
        SaveData saveData = new SaveData();
        HighScores = saveData.LoadHighScores();
        //saveData.SaveHighScores();
        if(Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
