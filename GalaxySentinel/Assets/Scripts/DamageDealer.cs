using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float damage = 0f;

    public float DoDamage()
    {
        return damage;
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
