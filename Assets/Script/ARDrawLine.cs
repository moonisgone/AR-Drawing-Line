using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARDrawLine : MonoBehaviour
{
    public Transform pivotPoint;
    public GameObject lineRendererPrefabs;
    private LineRenderer lineRenderer;
    public List<LineRenderer> lineList = new List<LineRenderer>();
    public Transform linePool;

    public bool _use;
    public bool startLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_use)
        {
            if (startLine)
            {
                DrawLineContinue();
            }
        }
    }

    public void MakeLineRenderer()
    {
        GameObject tLine = Instantiate(lineRendererPrefabs);
        tLine.transform.SetParent(linePool);
        tLine.transform.position = Vector3.zero;
        tLine.transform.localScale = new Vector3(1, 1, 1);

        lineRenderer = tLine.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, pivotPoint.position);

        startLine = true;
        lineList.Add(lineRenderer);
    }


    public void DrawLineContinue()
    {
        lineRenderer.positionCount = lineRenderer.positionCount + 1;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, pivotPoint.position);

    }

    public void StartDrawLine()
    {
        _use = true;
        if (!startLine)
        {
            MakeLineRenderer();
        }
    }

    public void StopDrawLine()
    {
        _use = false;
        startLine = false;
        lineRenderer = null;
    }
}
