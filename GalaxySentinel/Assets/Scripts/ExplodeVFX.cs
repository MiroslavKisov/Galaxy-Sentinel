using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeVFX : MonoBehaviour
{
    [SerializeField] GameObject explodeVFX;
    [SerializeField] float vfxDuration = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject explode = Instantiate(explodeVFX, transform.position, transform.rotation);
        Destroy(explode, vfxDuration);
    }
}
