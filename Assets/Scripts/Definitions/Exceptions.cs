using System;
using UnityEngine;

[System.Serializable]
public class InvalidFieldExistsException : Exception
{
    public InvalidFieldExistsException() : base() {}
    public InvalidFieldExistsException(string message) : base(message) {}
    public InvalidFieldExistsException(string message, Exception inner) : base(message, inner) {}
}
