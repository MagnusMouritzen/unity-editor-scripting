using UnityEngine;
using System;

public class ForceInterfaceAttribute : PropertyAttribute
{
    public readonly Type interfaceType;

    public ForceInterfaceAttribute(Type interfaceType)
    {
        this.interfaceType = interfaceType;
    }
}
