using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float damage = 0.5f;
    [SerializeField] float damageFrequency = 0.5f;

    LineRenderer lineRenderer;
    Coroutine laserDamage;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), transform.up);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hit.point);

        var enemyHealthScript = hit.collider.gameObject.GetComponent<EnemyHealth>();

        if (hit.collider.tag == "Enemy")
        {
            laserDamage = StartCoroutine(DoDamage(hit, enemyHealthScript));
        }
        else if (hit.collider.tag == "Shredder")
        {
            StopCoroutine(DoDamage(hit, enemyHealthScript));
        }
    }

    private IEnumerator DoDamage(RaycastHit2D hit, EnemyHealth enemyHealthScript)
    {
        enemyHealthScript.health -= damage;

        if (enemyHealthScript.health <= 0)
        {
            Destroy(hit.collider.gameObject);
        }

        yield return new WaitForSeconds(damageFrequency);;
    }
}
