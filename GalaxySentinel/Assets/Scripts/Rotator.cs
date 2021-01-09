using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float minRotationSpeed = 30f;
    [SerializeField] float maxRotationSpeed = 720f;

    private void Update()
    {
        transform.Rotate(0, 0, Random.Range(minRotationSpeed, maxRotationSpeed) * Time.deltaTime);
    }
}
