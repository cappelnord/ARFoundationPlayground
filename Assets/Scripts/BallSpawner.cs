using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float force = 1f;

    [SerializeField]
    private float spawnDistance = 0.25f;

    [SerializeField]
    private bool randomizeColors = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Spawn();
            }
        }

#if UNITY_EDITOR
    if(Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
#endif
    }

    private void Spawn()
    {
        GameObject obj = Instantiate(prefab, target);

        if(randomizeColors)
        {
            Color col = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

            var renderer = obj.GetComponent<MeshRenderer>();
            renderer.material.SetColor("_Color", col);
        }

        obj.transform.position = cam.transform.position + cam.transform.forward * spawnDistance;

        obj.GetComponent<Rigidbody>().AddForce(cam.transform.forward * force, ForceMode.VelocityChange);

    }
}
