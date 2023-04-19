using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveNickname : MonoBehaviour
{
    public TMP_InputField InputPlayerName;

    public static SaveNickname ins;
    private void Awake()
    {
        ins ??= this;
    }
}
