using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundsManager : MonoBehaviour
{
    public static BackgroundsManager Instance { get; private set; }
    public List<GameObject> TypeOfBackgrounds;
    private static int ActiveBackground = 0;
    private static int NumberOfActiveBackgroundIsInstanciated = 0;
    private Vector3 BackGroundSpawn = new Vector3(18.9f, 0, 0);
    [SerializeField] private int NumberRepetitionBackground = 2;
    private string PrefixName = "Background"; 


    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        GameObject firstBackgroud = Instantiate(TypeOfBackgrounds[ActiveBackground], new Vector3(0, 0, 0), Quaternion.identity, GameObject.Find("Backgrounds").transform);
        NumberOfActiveBackgroundIsInstanciated = 1;
        firstBackgroud.name = PrefixName + "Start";
        createBackgroud();

    }

    public void createBackgroud()
    {
        SelectActiveBackground();
        GameObject go = Instantiate(TypeOfBackgrounds[ActiveBackground], BackGroundSpawn, Quaternion.identity, GameObject.Find("Backgrounds").transform);        
        NumberOfActiveBackgroundIsInstanciated++;
        go.name = PrefixName + NumberOfActiveBackgroundIsInstanciated%2;
    }

    public void DestroyBackground(GameObject background)
    {
        Destroy(background);
    }

    private void SelectActiveBackground()
    {
        if (NumberOfActiveBackgroundIsInstanciated == NumberRepetitionBackground)
        {
            NumberOfActiveBackgroundIsInstanciated = 0;
            ActiveBackground++;
            if (ActiveBackground > TypeOfBackgrounds.Count - 1)
            {
                ActiveBackground = 0;
            }
        }

    }
}
