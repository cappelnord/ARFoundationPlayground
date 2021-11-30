using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenYBellow : MonoBehaviour
{

    [SerializeField]
    private float yThreshold = -50;

    void Update()
    {
        if (transform.position.y < yThreshold)
        {
            Destroy(gameObject);
        }
    }
}
