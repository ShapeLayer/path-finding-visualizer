using UnityEngine;

[System.Serializable]
public class Config_Camera
{
    public Vector2 movingSpeed;
    public Vector2 rotatingSpeed;
    public Config_Camera(
        float movingSpeedX = 10.0f,
        float movingSpeedY = 10.0f,
        float rotatingSpeedX = 2.0f,
        float rotatingSpeedY = 2.0f
    )
    {
        this.movingSpeed = new Vector2(movingSpeedX, movingSpeedY);
        this.rotatingSpeed = new Vector2(rotatingSpeedX, rotatingSpeedY);
    }
}
