using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Perk : MonoBehaviour
{
    [SerializeField] GameObject perk;
    [SerializeField] float padding = 0f;
    [SerializeField] public float fireSpeed = 0;
    [SerializeField] public bool isStaticPerk = false;

    GameObject perkShot;

    public void InstantiateStaticPerk(Transform fighterTransform)
    {
        perkShot = Instantiate(perk, fighterTransform);
        perkShot.transform.parent = fighterTransform.transform;
        perkShot.transform.localPosition = Vector3.zero;
    }

    public void DestroyStaticPerk()
    {
        Destroy(perkShot);
    }

    public void InstantiateKinematicPerk(Transform fighterTransform)
    {
        Instantiate(fighterTransform);
    }

    private void Instantiate(Transform fighterTransform)
    {
        perkShot = Instantiate(
                 perk,
                 new Vector3(
                     fighterTransform.position.x,
                     fighterTransform.position.y + padding, 0), 
                 Quaternion.identity) as GameObject;
    }
}
