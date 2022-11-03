using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUiHandler : MonoBehaviour
{

    public TMP_InputField playerNameImputField;

    public void SetPlayerName()
    {
        MainManager.Instance.PlayerName = playerNameImputField.text;
    }
}
