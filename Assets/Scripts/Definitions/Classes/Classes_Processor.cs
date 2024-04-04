using System;
using UnityEngine;

[System.Serializable]
public enum MovingStatus
{
    Idle,
    Rotating,
    Forwarding,
    Backwarding,
    BackwardRotating
}

[System.Serializable]
public enum PositionPointType
{
    Passing,
    Destination
}

[System.Serializable]
public class PositionPoint
{
    public Vector2 position;
    public PositionPointType pointType;
}

[System.Serializable]
public class Config_Processor
{
    public string modelObjectName;
    public string processorObjectName;
    public int velocity;
    public int angularVelocity;
    public bool isBackwardMovingBeforeDestination;
    public int backwardMovingTriggerRange;

    public Config_Processor
    (
        string modelObjectName = "model",
        string processorObjectName = "Processor",
        int velocity = 10,
        int angularVelocity = 10,
        bool isBackwardMovingBeforeDestination = true,
        int backwardMovingTriggerRange = 10
    )
    {
        this.modelObjectName = modelObjectName;
        this.processorObjectName = processorObjectName;
        this.velocity = velocity;
        this.angularVelocity = angularVelocity;
        this.isBackwardMovingBeforeDestination = isBackwardMovingBeforeDestination;
        this.backwardMovingTriggerRange = backwardMovingTriggerRange;
    }
}

public class Events_Processor
{
    public static event EventHandler MovingStatusChanged;
    public static event EventHandler HeadingPointChanged;
    public static void InvokeMovingStatusChanged(object? sender, EventArgs e)
    {
        Events_Processor.MovingStatusChanged?.Invoke(sender, e);
    }
    public static void InvokeHeadingPointChanged(object? sender, EventArgs e)
    {
        Events_Processor.HeadingPointChanged?.Invoke(sender, e);
    }
}

public class MovingStatusChangedArgs : EventArgs {
    public MovingStatus status { get; set; }
    public MovingStatusChangedArgs(MovingStatus status)
    {
        this.status = status;
    }
}
public class HeadingPointChangedArgs : EventArgs
{
    public PositionPoint Changed { get; set; }
    public HeadingPointChangedArgs(PositionPoint Changed)
    {
        this.Changed = Changed;
    }
}
