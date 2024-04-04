using System;
using UnityEngine;

public class CurveUtils
{
    public static AnimationCurve ScalarToCurve(float value)
    {
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.0f, value);
        curve.AddKey(1.0f, value);
        return curve;
    }
}
