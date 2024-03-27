using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller_Processor : MonoBehaviour
{
    public Config_Processor config = new Config_Processor();
    public List<PositionPoint> pointsHeading = new List<PositionPoint>();
    public List<PositionPoint> pointsPassed = new List<PositionPoint>();
    public MovingStatus movingStatus = MovingStatus.Idle;
    public Vector2 processorHeading;
    public GameObject displayModelObject;

    void Awake()
    {
        this.displayModelObject = transform.Find(this.config.modelObjectName).gameObject;
    }

    void Start()
    {
        SetTarget();
    }

    void Update()
    {
        ProcessingMoving();
    }

    void ProcessingMoving()
    {
        if (this.movingStatus == MovingStatus.Idle) return;

        float step;
        switch (this.movingStatus)
        {
            case MovingStatus.Forwarding:
                if (Vector3.Distance(transform.position, VectorUtils.Vector2To3(processorHeading, transform.position.y)) < .001f)
                {
                    SwitchTarget();
                }
                else
                {
                    _ProcessingForwarding();
                }
                break;
            case MovingStatus.Rotating:
                _ProcessingRotating();
                /*
                step = config.angularVelocity * Time.deltaTime;
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, processorHeading.Dir, step, 0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
                */
            break;
        }
    }
    void SetTarget()
    {
        if (this.pointsHeading.Count == 0) return;
        this.processorHeading = this.pointsHeading[0].position;
        _SetMovingStatusToStart();
    }
    void _SetMovingStatusToStart()
    {
        this.movingStatus = MovingStatus.Rotating;
    }
    void SwitchTarget()
    {
        if (pointsHeading.Count == 0)
        {
            this.movingStatus = MovingStatus.Idle;
            return;
        }
        this.pointsPassed.Add(this.pointsHeading[0]);
        this.pointsHeading.RemoveAt(0);
        SetTarget();
        // check angular
    }
    void _ProcessingForwarding()
    {
        float step = this.config.velocity * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, VectorUtils.Vector2To3(processorHeading, transform.position.y), step);

        /*
        Vector3 newPosition = Vector3.MoveTowardstr(transform.position, 
            new Vector3()
        );
        transform.position = Vector3;*/
    }
    void _ProcessingRotating()
    {
        Vector3 targetDirection = VectorUtils.Vector2To3(processorHeading, transform.position.y) - transform.position;
        Quaternion targetDirectionQ = Quaternion.LookRotation(targetDirection);
        float step = this.config.angularVelocity * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        if (targetDirectionQ == transform.rotation)
        {
            this.movingStatus = MovingStatus.Forwarding;
        }
    }
}
