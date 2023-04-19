using System.Collections;
using UnityEngine;
using Mirror;

public class PlayerHealth : NetworkBehaviour
{
    [SerializeField] private GameObject FloatingInfo;
    [SerializeField] private GameObject GroundCheck;
    [SerializeField] private GameObject Mesh;
    [SerializeField] private GameObject PlayerCamera;
    [SerializeField] private GameObject FakeWeapon;
    [SerializeField] private Transform PlayerTranform;
    public Weapon weapon;
    public short Health = 100;
    public static int Kill;

    public static PlayerHealth ins;
    private void Awake()
    {
        ins ??= this;
    }

    public void DamageHealth(short damage, PlayerHealth playerHealth)
    {
        short health = Health;
        health -= damage;
        if(health <= 0)
            KillCount();
        CmdHealth(damage, playerHealth);
    }

    [Command(requiresAuthority = false)]
    public void CmdHealth(short damage, PlayerHealth playerHealth)
    {
        RpcHealth(damage, playerHealth);
    }

    [ClientRpc]
    public void RpcHealth(short damage, PlayerHealth playerHealth)
    {
        Health -= damage;
    }

    [Command(requiresAuthority = false)]
    public void CmdRespawn()
    {
        RpcRespawn();
    }

    [ClientRpc]
    public void RpcRespawn()
    {
        StartCoroutine(Respawn());
    }

    public void KillCount()
    {
        Kill++;
    }

    private void Update()
    {
        if(!isLocalPlayer)
        {
            if(Health <= 0)
            {
                FloatingInfo.SetActive(false);
                GroundCheck.SetActive(false);
                Mesh.SetActive(false);
                FakeWeapon.SetActive(false);
                CmdRespawn();
            }
        }

        else if(isLocalPlayer)
        {
            if(Health <= 0)
            {
                FloatingInfo.SetActive(false);
                GroundCheck.SetActive(false);
                PlayerCamera.SetActive(false);
                GetComponent<CapsuleCollider>().enabled = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                CmdRespawn();
            }
        }

        if(gameObject.transform.position.y <= -5)
        {
            Health = 0;
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.01f);
        Health = 100;
        weapon.ammo = 30;
        Vector3 pos = new Vector3(Random.Range(-9f, 87f), 2f, Random.Range(-35, 68));
        PlayerTranform.position = pos;
        yield return new WaitForSeconds(5f);

        if(isLocalPlayer)
        {
            PlayerCamera.SetActive(true);
        }
        else
        {
            Mesh.SetActive(true);
            FakeWeapon.SetActive(true);
        }
        FloatingInfo.SetActive(true);
        GroundCheck.SetActive(true);
        GetComponent<CapsuleCollider>().enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

