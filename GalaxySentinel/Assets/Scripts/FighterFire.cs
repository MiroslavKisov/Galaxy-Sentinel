using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterFire : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] ParticleSystem[] weaponsParticleSystems;

    Coroutine fireCoroutine;
    GameObject weapon;
    Weapon weaponScript;
    ParticleSystem weaponParticleSystem;

    void Start()
    {
        LoadWeapon();
        SetParticleSystems();
    }

    void Update()
    {
        Fire();
    }

    private void LoadWeapon()
    {
        var selectedWeapon = PlayerPrefs.GetString("weapon");

        switch (selectedWeapon)
        {
            case "electricGun":
                weapon = weapons[0];
                weaponParticleSystem = weaponsParticleSystems[0];
                break;
            case "plasmaCannon":
                weapon = weapons[1];
                weaponParticleSystem = weaponsParticleSystems[1];
                break;
            case "machineGun":
                weapon = weapons[2];
                weaponParticleSystem = weaponsParticleSystems[2];
                break;
            case "apCannon":
                weapon = weapons[3];
                weaponParticleSystem = weaponsParticleSystems[3];
                break;
            case "laser":
                weapon = weapons[4];
                weaponParticleSystem = weaponsParticleSystems[4];
                break;
            default:
                break;
        }

        weaponScript = weapon.GetComponent<Weapon>();
    }

    private void Fire()
    {
        if (weaponScript.isStaticProjectile)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weaponScript.InstantiateStaticProjectile(transform);
                weaponParticleSystem.Play();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                weaponScript.DestroyStaticProjectile();
                weaponParticleSystem.Stop();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                fireCoroutine = StartCoroutine(FireToggleKinematic(weaponScript));
                weaponParticleSystem.Play();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                StopCoroutine(fireCoroutine);
                weaponParticleSystem.Stop();
            }
        }
    }

    private IEnumerator FireToggleKinematic(Weapon weaponScript)
    {
        while (true)
        {
            weaponScript.InstantiateKinematicProjectile(transform);
            yield return new WaitForSeconds(weaponScript.fireSpeed);
        }
    }

    private void SetParticleSystems()
    {
        foreach (var particleSystem in weaponsParticleSystems)
        {
            particleSystem.Stop();
        }
    }
}
