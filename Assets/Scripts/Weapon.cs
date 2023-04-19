using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AudioClip shot;
    [SerializeField] private AudioClip reload;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Transform BulletSpawn;
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private short damage;
    [SerializeField] private float bulletForse;
    [SerializeField] private float range;
    [SerializeField] private float fireRate;
    [SerializeField] private float volume;
    public short ammo = 30;
    
    private bool isCanShout;
    private bool isReload;
    private float nextFire = 0;
    

    public static Weapon ins;
    private void Awake()
    {
        ins ??= this;
    }

    private void Update()
    {
        if(ammo > 0)
        {
            isCanShout = true;
        }
        else
        {
            isCanShout = false;
        }

        if(Input.GetKeyDown(KeyCode.R) && !isReload)
        {
            StartCoroutine(Reload());
            audioSource.PlayOneShot(reload);
            ammo = 30;
        }

        if(Input.GetButton("Fire1") && Time.time > nextFire && isCanShout && !isReload)
        {
            ammo--;
            nextFire = Time.time + 1f / fireRate;
            Shoot();

            muzzleFlash.SetActive(true);
        }
        else
        {
            muzzleFlash.SetActive(false);
        }

        audioSource.volume = volume;
    }

    private void Shoot()
    {
        audioSource.PlayOneShot(shot);
        RaycastHit hit;

        if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);

            if(hit.transform.gameObject.tag == "Player" && hit.collider.TryGetComponent<PlayerHealth>(out var healthDamage))
            {
                //hit.rigidbody.AddForce(-hit.normal * bulletForse);
                healthDamage.DamageHealth(damage, healthDamage);
            }
        }
    }

    IEnumerator Reload()
    {
        isReload = true;
        yield return new WaitForSeconds(2f);

        isReload = false;
    }
}
