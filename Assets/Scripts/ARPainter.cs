using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPainter : MonoBehaviour
{

    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private GameObject linePrefab;

    [SerializeField]
    private GameObject cam;

    private LineRenderer currentLineRenderer = null;
    private Color currentColor;
    private float tipLength;

    // Start is called before the first frame update
    void Start()
    {
        SetColor(Color.red);
        tipLength = Vector3.Distance(Vector3.zero, transform.localPosition);
    }

    public void SetColor(Color color)
    {
        currentColor = color;
        GetComponent<MeshRenderer>().material.SetColor("_Color", color);
    }

    void LateUpdate()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                StartLine();
            } else if (t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
            {
                ContinueLine();
            } else
            {
                EndLine();
            }
        }

        if(Input.GetMouseButtonDown(0)) {
            StartLine();
        }

        if(Input.GetMouseButtonUp(0))
        {
            EndLine();
        }

    }

    private void StartLine()
    {
        GameObject obj = Instantiate(linePrefab, targetTransform);
        currentLineRenderer = obj.GetComponent<LineRenderer>();

        currentLineRenderer.startColor = currentColor;
        currentLineRenderer.endColor = currentColor;

        ContinueLine();
    }

    private void ContinueLine()
    {
        Vector3 point = cam.transform.localPosition  + cam.transform.forward * tipLength;

        if(currentLineRenderer != null)
        {
            currentLineRenderer.positionCount = currentLineRenderer.positionCount + 1;
            currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, point);
        }
    }

    private void EndLine()
    {
        currentLineRenderer = null;
    }
}
