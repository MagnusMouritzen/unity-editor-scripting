using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(RandomizeAttribute))]
public class RandomizeAttributeDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * 2;  // Edited from 32f in the video.
    }
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.Float)
        {
            EditorGUI.BeginProperty(position, label, property);
            Rect labelPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);  // Edited from 16f in the video.
            Rect buttonPosition = new Rect(position.x, position.y + labelPosition.height, position.width, EditorGUIUtility.singleLineHeight);  // Edited from 16f in the video.
            
            EditorGUI.LabelField(labelPosition, label, new GUIContent(property.floatValue.ToString()));
            if (GUI.Button(buttonPosition, "Randomize"))
            {
                RandomizeAttribute randomizeAttribute = (RandomizeAttribute)attribute;
                property.floatValue = Random.Range(randomizeAttribute.minValue, randomizeAttribute.maxValue);
            }
        }
        else
        {
            EditorGUI.LabelField(position, "Use RandomizeAttribute with floats.");
        }
    }
}
