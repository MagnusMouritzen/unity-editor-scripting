using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class EnumDataContainer<TValue, TEnum> : IEnumerable where TEnum : Enum
{
    [SerializeField] private TValue[] content;
    // enumType removed after video in favour of solution presented in the drawer.

    public TValue this[int i]
    {
        get => content[i];
        set => content[i] = value;  // Added after video to make the class more useful.
    }

    // Added after the video to make indexing easier.
    public TValue this[TEnum i]
    {
        get => content[Convert.ToInt32(i)];
        set => content[Convert.ToInt32(i)] = value;
    }

    public int Length => content.Length;
    
    // Added after video to make the class more useful.
    public IEnumerator GetEnumerator()
    {
        return content.GetEnumerator();
    }
}
