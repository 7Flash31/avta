using TMPro;
using UnityEngine;
using Mirror;
using Mirror.Examples.MultipleMatch;

public class RoomPlayerController : NetworkBehaviour
{
    [SyncVar]
    public string playerName;

    public static RoomPlayerController ins;
    private void Awake()
    {
        ins ??= this;
    }

    public void SetupPlayer()
    {
        Debug.Log("SetupPlayer");
        string name = DontDestroyOnLoadSC.Instance.InputPlayerName.text.ToString();
        CmdSetupPlayer(name);
    }


    [Command(requiresAuthority = false)]
    public void CmdSetupPlayer(string name)
    {
        playerName = name;
        Debug.Log("CmdSetupPlayer");
        RpcSetupPlayer(playerName);
    }

    [ClientRpc]
    public void RpcSetupPlayer(string name)
    {
        Debug.Log("RpcSetupPlayer");

        //PlayerManager.ins.playerNickName.text = name;
    }

}
