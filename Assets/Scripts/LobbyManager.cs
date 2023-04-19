using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class LobbyManager : NetworkRoomManager
{
    [Header("LobbyManager")]
    [SerializeField] private GameObject canvasPlayerPanel;


    public override void OnRoomStartServer()
    {
        Instantiate(canvasPlayerPanel, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
