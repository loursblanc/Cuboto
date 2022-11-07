using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundsManager : MonoBehaviour
{
    public static BackgroundsManager Instance { get; private set; }
    public List<GameObject> typeOfBackgrounds;
    private static int activeBackground = 0;
    private static int numberOfActiveBackgroundIsInstanciated = 0;
    [SerializeField] private int NumberRepetitionBackground = 2;

    
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

        GameObject firstBackgroud = Instantiate(typeOfBackgrounds[activeBackground], new Vector3(0, 0, 0), Quaternion.identity, GameObject.Find("Backgrounds").transform);
        GameObject  secondBackgroud = Instantiate(typeOfBackgrounds[activeBackground], new Vector3(18.9f, 0, 0), Quaternion.identity, GameObject.Find("Backgrounds").transform);
        numberOfActiveBackgroundIsInstanciated = 2;


    }

    public void createBackgroud()
    {
        if( numberOfActiveBackgroundIsInstanciated == NumberRepetitionBackground)
        {
            numberOfActiveBackgroundIsInstanciated = 0;
            activeBackground++;
            if(activeBackground > typeOfBackgrounds.Count -1)
            {
                activeBackground = 0;
            }
        }
        GameObject go = Instantiate(typeOfBackgrounds[activeBackground], new Vector3(18.9f, 0, 0), Quaternion.identity, GameObject.Find("Backgrounds").transform);        
        go.name = "Background";
        numberOfActiveBackgroundIsInstanciated++;
    }

    internal void DestroyBackground(GameObject background)
    {
        Destroy(background);
    }
}
