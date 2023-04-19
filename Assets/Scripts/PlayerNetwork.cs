using UnityEngine;
using Mirror;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private GameObject Mesh;
    [SerializeField] private GameObject FakeWeapon;
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Component[] components;

    public static PlayerNetwork ins;
    private void Awake()
    {
        ins ??= this;
    }

    private void Start()
    {
        if(!isLocalPlayer)
        {
            for(int i = 0; i < objects.Length; i++)
            {
                Destroy(objects[i]);
            }

            for(int i = 0; i < components.Length; i++)
            {
                Destroy(components[i]);
            }
        }

        if(isLocalPlayer)
        {
            Destroy(Mesh);
            Destroy(FakeWeapon);
        }
    }

    public void StopGame()
    {
        if(NetworkManager.singleton != null)
        {
            Destroy(NetworkManager.singleton.gameObject);
        }

        if(isLocalPlayer)
        {
            NetworkManager.singleton.StopHost();
        }

        if(!isLocalPlayer)
        {
            NetworkManager.singleton.StopClient();
        }
    }
}
