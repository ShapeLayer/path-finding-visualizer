using System;
using UnityEngine;

public class ColorUtils
{
    public static Gradient ColorToGradient(Color color)
    {
        Gradient gradient = new Gradient();
        
        GradientColorKey[] colors = new GradientColorKey[2];
        colors[0] = new GradientColorKey(color, 0f);
        colors[1] = new GradientColorKey(color, 1f);

        GradientAlphaKey[] alphas = new GradientAlphaKey[2];
        alphas[0] = new GradientAlphaKey(1f, 0f);
        alphas[1] = new GradientAlphaKey(1f, 1f);

        gradient.SetKeys(colors, alphas);
        return gradient;
    }
}
