using UnityEngine;
using Mirror;
using TMPro;

public class PlayerManager : NetworkRoomPlayer
{
    [SerializeField] private GameObject prefabPlayerGUI;


    public TMP_Text playerNickName;

    public static PlayerManager ins;
    private void Awake()
    {
        ins ??= this;


        if(NetworkClient.active)
        {
            GameObject spawn = Instantiate(prefabPlayerGUI, CanvasRoom.ins.canvasPanel);
            playerNickName = spawn.GetComponentInChildren<TMP_Text>();
        }

    }

}
