using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_PathIndicator : MonoBehaviour
{
    public static Color indicatorColor = new Color(.13f, .69f, .69f);
    
    Controller_Processor processorController;
    public Config_PathIndicator config = new Config_PathIndicator();
    GameObject parentObject;
    GameObject processorObject;
    LineRenderer lineRenderer;

    void Awake()
    {
        this.parentObject = transform.parent.gameObject;
        this.processorObject = transform.Find("Processor").gameObject;
        this.processorController = processorObject.GetComponent<Controller_Processor>();
        this.lineRenderer = GetComponent<LineRenderer>();
        this.config.lineRendererConfig = new Config_LineRenderer(ColorUtils.ColorToGradient(indicatorColor));
        _ValidateFields();
    }

    void _ValidateFields()
    {
        if (this.processorController == null)
        {
            throw new InvalidFieldExistsException();
        }
        if (this.parentObject == null)
        {
            throw new InvalidFieldExistsException();
        }
        if (this.parentObject == null)
        {
            throw new InvalidFieldExistsException();
        }
    }

    void Start()
    {
        this.config.lineRendererConfig.Apply(this.lineRenderer);
    }

    void Update()
    {
        UpdateIndicatorVertices();
    }


    void UpdateIndicatorVertices()
    {
        float y = .5f; // revise later
        List<Vector3> positions = new List<Vector3>();
        positions.Add(processorObject.transform.position);
        foreach (PositionPoint each in processorController.pointsHeading)
        {
            Vector2 pos = each.position;
            positions.Add(new Vector3(pos.x, y, pos.y));
        }
        int n = positions.Count;
        lineRenderer.positionCount = n;
        for (int i = 0; i < n; i++)
        {
            lineRenderer.SetPosition(i, positions[i]);
        }
    }
}
