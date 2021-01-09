using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 0;
    [SerializeField] float padding = 0;
    [SerializeField] public float fireSpeed = 0;
    [SerializeField] public bool isStaticProjectile = false;
    [SerializeField] GameObject projectile;

    GameObject shot;

    public void InstantiateKinematicProjectile(Transform fighterTransform)
    {
        shot = InstantiateProjectile(projectile, fighterTransform);
        shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
    }

    public void InstantiateStaticProjectile(Transform fighterTransform)
    {
        shot = InstantiateProjectile(projectile, fighterTransform);
        shot.transform.parent = fighterTransform.transform;
    }

    public void DestroyStaticProjectile()
    {
        Destroy(shot);
    }

    private GameObject InstantiateProjectile(GameObject projectile, Transform fighterTransform)
    {
        return Instantiate(
             projectile,
             new Vector3(
                 fighterTransform.position.x,
                 fighterTransform.position.y + padding, 0),
                 Quaternion.identity) as GameObject;
    }
}
