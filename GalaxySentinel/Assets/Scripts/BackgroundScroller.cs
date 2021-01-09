using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollingSpeed = 0.07f;
    Material backgroundMaterial;
    Vector2 offSet;
    
    void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0, backgroundScrollingSpeed);
    }

    
    void Update()
    {
        backgroundMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
