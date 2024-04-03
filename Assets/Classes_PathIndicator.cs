using System;
using UnityEngine;

[System.Serializable]
public class Config_PathIndicator
{
    public Config_LineRenderer lineRendererConfig;
    public Config_PathIndicator()
    {
        this.lineRendererConfig = new Config_LineRenderer();
    }
}
