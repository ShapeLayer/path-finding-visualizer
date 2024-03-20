using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProcessorHeading
{
    public Vector2 src;
    public Vector2 Src { get { return src; } }
    public Vector2 dest;
    public Vector2 Dest { get { return dest; } }
    public Vector2 dir;
    public Vector2 Dir { get { return dir; } }
    public ProcessorHeading(Vector2 src, Vector2 dest)
    {
        this.src = src;
        this.dest = dest;
        this.dir = this.Dest - this.Src;
    }
}

public class Controller_Processor : MonoBehaviour
{
    public Config_Processor config = new Config_Processor();
    public List<PositionPoint> pointsHeading = new List<PositionPoint>();
    public List<PositionPoint> pointsPassed = new List<PositionPoint>();
    public ProcessorHeading processorHeading;
    public MovingStatus movingStatus = MovingStatus.Idle;

    public GameObject displayModelObject;

    void Awake()
    {
        this.displayModelObject = transform.Find(config.modelObjectName).gameObject;
    }

    void Start()
    {
        TargetingNextPosition();
        this.movingStatus = MovingStatus.Rotating;
    }

    void Update()
    {
        ProcessingMoving();
    }

    void ProcessingMoving()
    {
        float step;
        switch (movingStatus)
        {
            case MovingStatus.Forwading:
                step = config.velocity * Time.deltaTime;/*
                Vector3 newPosition = Vector3.MoveTowardstr(transform.position, 
                    new Vector3()
                );
                transform.position = Vector3;*/
            break;
            case MovingStatus.Rotating:
                step = config.angularVelocity * Time.deltaTime;
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, processorHeading.Dir, step, 0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
            break;
        }
    }

    void TargetingNextPosition()
    {
        processorHeading = new ProcessorHeading(
            new Vector2(transform.position.x, transform.position.y),
            new Vector2(pointsHeading[0].position.x, pointsHeading[0].position.y)
        );
    }
}
