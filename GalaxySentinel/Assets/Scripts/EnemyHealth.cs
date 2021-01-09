using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float health = 500f;
    [SerializeField] public GameObject[] hitVFXs;
    [SerializeField] float electricGunTimeVFX = 0.25f;

    GameObject hitVFX;
    ParticleSystem laserHitVFX;

    void Start()
    {
        laserHitVFX = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessHit(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        laserHitVFX.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        laserHitVFX.Stop();
    }

    private void ProcessHit(Collider2D collision)
    {
        var damageDealerScript = collision.gameObject.GetComponent<DamageDealer>();

        if(!damageDealerScript)
        {
            return;
        }

        PlayVFXOnHit(collision);

        health -= damageDealerScript.DoDamage();
        damageDealerScript.DestroyProjectile();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void PlayVFXOnHit(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "electric_gun(Clone)":
                hitVFX = Instantiate(hitVFXs[0], transform.position, transform.rotation);
                Destroy(hitVFX, electricGunTimeVFX);
                break;
            default:
                break;
        }
    }
}
