using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundsManager : MonoBehaviour
{
    public static BackgroundsManager Instance { get; private set; }
    public List<GameObject> TypeOfBackgrounds;
    private static int ActiveBackground = 0;
    public static int NumberOfActiveBackgroundIsInstanciated { get; private set; } = 0;
    public  Vector3 BackGroundSpawn {get; private set; } = new Vector3(18.9f, 0, 0);
    [SerializeField] private int NumberRepetitionBackground = 2;
    public string PrefixName { get; private set; } = "Background"; 


    
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

        if (TypeOfBackgrounds != null)
        {
            GameObject firstBackgroud = Instantiate(TypeOfBackgrounds[ActiveBackground], Vector3.zero, Quaternion.identity, GameObject.Find("Backgrounds").transform);
            NumberOfActiveBackgroundIsInstanciated = 1;
            firstBackgroud.name = PrefixName + "Start";
            CreateBackgroud();
        }
    }

    public void CreateBackgroud()
    {
        SelectActiveBackground();
        GameObject go = Instantiate(TypeOfBackgrounds[ActiveBackground], BackGroundSpawn, Quaternion.identity, GameObject.Find("Backgrounds").transform);        
        NumberOfActiveBackgroundIsInstanciated++;
        go.name = PrefixName + NumberOfActiveBackgroundIsInstanciated%2;
    }

    public void DestroyBackground(GameObject background)
    {
        if(background.tag == "Background")
        {
            Destroy(background);
        }        
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
