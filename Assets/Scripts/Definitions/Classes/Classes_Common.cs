using System;
using UnityEngine;

[System.Serializable]
public class Config_Rigidbody
{
    public float mass;
    public float drag;
    public float angularDrag;
    public bool automaticInertiaTensor;
    public bool useGravity;
    public bool isKinematic;
    public Config_Rigidbody(
        float mass = 1,
        float drag = 0,
        float angularDrag = .05f,
        bool automaticInertiaTensor = true,
        bool useGravity = true,
        bool isKinematic = false
    )
    {
        this.mass = mass;
        this.drag = drag;
        this.angularDrag = angularDrag;
        this.automaticInertiaTensor = automaticInertiaTensor;
        this.useGravity = useGravity;
        this.isKinematic = isKinematic;
    }
    public void Apply(Rigidbody rb)
    {
        rb.mass = this.mass;
        rb.drag = this.drag;
        rb.angularDrag = this.angularDrag;
        rb.automaticInertiaTensor = this.automaticInertiaTensor;
        rb.useGravity = this.useGravity;
        rb.isKinematic = this.isKinematic;
    }
}

[System.Serializable]
public class Config_LineRenderer
{
    public float? startWidth;
    public float? endWidth;
    public float? width;
    public AnimationCurve? widthCurve;
    public float? widthMultiplier;

    public LineAlignment? alignment;
    
    public Color startColor;
    public Color endColor;
    public Gradient colorGradient;
    public float shadowBias;
    public LineTextureMode textureMode;

    public bool generateLightingData;
    public bool loop;
    public bool useWorldSpace;

    public int numCapVertices;
    public int numCornerVertices;
    public int positionCount;

    public Config_LineRenderer() {}
    public Config_LineRenderer(Gradient colorGradient)
    {
        this.colorGradient = colorGradient;
    }
    public Config_LineRenderer(Gradient colorGradient, AnimationCurve widthCurve, float widthMultiplier)
    {
        this.colorGradient = colorGradient;
        this.widthCurve = widthCurve;
    }

    public void Apply(LineRenderer lr)
    {
        if (this.startWidth != null)
        {
            lr.startWidth = this.startWidth ?? default(float);
        }
        if (this.endWidth != null)
        {
            lr.endWidth = this.endWidth ?? default(float);
        }
        if (this.width != null)
        {
            lr.SetWidth(width ?? default(float), width ?? default(float));
        }
        if (this.widthCurve != null)
        {
            lr.widthCurve = this.widthCurve!;
        }
        if (this.widthMultiplier != null)
        {
            lr.widthMultiplier = this.widthMultiplier ?? default(float);
        }

        if (this.alignment != null)
        {
            lr.alignment = this.alignment ?? default(LineAlignment);
        }

        if (this.startColor != null)
        {
            lr.startColor = this.startColor;
        }
        if (this.endColor != null)
        {
            lr.endColor = this.endColor;
        }
        if (this.colorGradient != null)
        {
            lr.colorGradient = this.colorGradient;
        }
        if (this.shadowBias != null)
        {
            lr.shadowBias = this.shadowBias;
        }
        if (this.textureMode != null)
        {
            lr.textureMode = this.textureMode;
        }

        if (this.generateLightingData != null)
        {
            lr.generateLightingData = this.generateLightingData;
        }
        if (this.loop != null)
        {
            lr.loop = this.loop;
        }
        if (this.useWorldSpace != null)
        {
            lr.useWorldSpace = this.useWorldSpace;
        }

        if (this.numCapVertices != null)
        {
            lr.numCapVertices = this.numCapVertices;
        }
        if (this.numCornerVertices != null)
        {
            lr.numCornerVertices = this.numCornerVertices;
        }
        if (this.positionCount != null)
        {
            lr.positionCount = this.positionCount;
        }
    }
}

[System.Serializable]
public class Config_Transform
{}
