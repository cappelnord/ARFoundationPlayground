using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlanePlacement : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private GameObject pointerPrefab;

    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private bool placeMultiple;

    private GameObject spawnedObject;
    private GameObject pointer;
    private ARRaycastManager raycastManager;

    private Vector2 screenCenter;

    void Awake() {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        screenCenter = new Vector2(Screen.width/2, Screen.height/2);

        if(pointerPrefab != null) {
            pointer = Instantiate(pointerPrefab, targetTransform);
            pointer.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if(raycastManager.Raycast(screenCenter, hits, trackableTypes: TrackableType.PlaneWithinPolygon)) {
            Pose pose = hits[0].pose;

            if(Input.touchCount > 0) {
                Touch t = Input.GetTouch(0);
                if(t.phase == TouchPhase.Began) {
                    if(spawnedObject != null && !placeMultiple) {
                        Destroy(spawnedObject);
                        spawnedObject = null;
                    } else {
                        spawnedObject = Instantiate(prefab, targetTransform);
                        spawnedObject.transform.position = pose.position;
                        spawnedObject.transform.rotation = pose.rotation;
                    }
                }
            }

            DisplayPointer(pose);

        } else {
            HidePointer();
        }
    }

    void DisplayPointer(Pose pose) {
        if(pointer == null) return;

        if(!placeMultiple && spawnedObject != null) {
            HidePointer();
            return;
        }

        pointer.transform.position = pose.position;
        pointer.transform.rotation = pose.rotation;
        pointer.SetActive(true);
    }

    void HidePointer() {
        if(pointer == null) return;

        pointer.SetActive(false);
    }
}
