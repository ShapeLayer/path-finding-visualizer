using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_ProcessorGroup : MonoBehaviour
{
    public GameObject processorPrefab; // Must connect manually.
    Config_Processor processorConfigTemplate = new Config_Processor();

    void Awake()
    {
        _ValidateFields();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void _ValidateFields()
    {
        if (processorPrefab == null)
        {
            throw new InvalidFieldExistsException();
        }
    }

    public GameObject AddNewProcessor()
    {
        GameObject _new = GenerateNewProcessor();
        _new.transform.parent = transform;
        return _new;
    }
    public GameObject AddNewProcessor(Vector3? initPosition, List<PositionPoint> positionPoints)
    {
        GameObject _new = AddNewProcessor();
        GameObject _newProcessor = _new.transform.Find(this.processorConfigTemplate.processorObjectName).gameObject;
        _newProcessor.GetComponent<Controller_Processor>().pointsHeading = positionPoints;
        return _new;
    }

    public GameObject GenerateNewProcessor()
    {
        GameObject _new = Instantiate(processorPrefab);
        return _new;
    }

    [ContextMenu("AddNewProcessor()")]
    public void ContextMenu_AddNewProcessor()
    {
        AddNewProcessor();
    }
}
