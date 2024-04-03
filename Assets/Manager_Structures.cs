using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for Structures

public class Manager_Structures : MonoBehaviour
{
    GameObject baseObject;
    List<Structure> structures;
    public void AddStructure(Vector3 p1, Vector3 p2)
    {
        GameObject newObject = Instantiate(baseObject);
        // set size to p1~p2.
    }
}