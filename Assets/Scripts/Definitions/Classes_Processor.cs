using UnityEngine;

[System.Serializable]
public enum MovingStatus
{
    Idle,
    Forwading,
    Backwarding,
    Rotating
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
    public int velocity;
    public int angularVelocity;
    public bool isBackwardMovingBeforeDestination;
    public int backwardMovingTriggerRange;

    public Config_Processor
    (
        string modelObjectName = "model",
        int velocity = 10,
        int angularVelocity = 10,
        bool isBackwardMovingBeforeDestination = true,
        int backwardMovingTriggerRange = 10
    )
    {
        this.modelObjectName = modelObjectName;
        this.velocity = velocity;
        this.angularVelocity = angularVelocity;
        this.isBackwardMovingBeforeDestination = isBackwardMovingBeforeDestination;
        this.backwardMovingTriggerRange = backwardMovingTriggerRange;
    }
}
