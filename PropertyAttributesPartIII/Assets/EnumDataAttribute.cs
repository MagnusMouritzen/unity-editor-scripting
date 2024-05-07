using UnityEngine;
using System;

public class EnumDataAttribute : PropertyAttribute
{
    public readonly string[] names;

    public EnumDataAttribute(Type enumType)
    {
        names = Enum.GetNames(enumType);
    }
}
