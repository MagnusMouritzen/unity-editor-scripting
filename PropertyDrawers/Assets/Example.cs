using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] private EnumDataContainer<TextStyle, TextStyles> textStyles;
}

public enum TextStyles
{
    Normal,
    Heading,
    Warning,
    Error
}

[System.Serializable]
public class TextStyle
{
    public int size;
    public Color color;
}
