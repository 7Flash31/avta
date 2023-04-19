using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DontDestroyOnLoadSC : MonoBehaviour
{
    public TMP_InputField InputPlayerName;

    public static DontDestroyOnLoadSC Instance { get; private set; }

    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
