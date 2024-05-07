using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(EnumDataContainer<,>))]
public class EnumDataContainerDrawer : PropertyDrawer
{
    // Storing content and enumType variables can give problems, so they are found every time in the methods.
    private SerializedProperty GetContent(SerializedProperty property)
    {
        return property.FindPropertyRelative("content");
    }
    
    private Type GetEnumType()
    {
        // This is how we find the enum type without a field in EnumDataContainer.
        return (fieldInfo.FieldType.IsArray ? fieldInfo.FieldType.GetElementType() : fieldInfo.FieldType).GetGenericArguments()[1];
    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty content = GetContent(property);
        Type enumType = GetEnumType();

        float height = EditorGUIUtility.singleLineHeight;  // Edited from FOLDOUT_HEIGHT in video.
        if (property.isExpanded)
        {
            if (content.arraySize != enumType.GetEnumNames().Length)
            {
                content.arraySize = enumType.GetEnumNames().Length;
            }
            for (int i = 0; i < content.arraySize; i++)
            {
                height += EditorGUI.GetPropertyHeight(content.GetArrayElementAtIndex(i));
            }
        }
        return height;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty content = GetContent(property);
        Type enumType = GetEnumType();
        
        EditorGUI.BeginProperty(position, label, property);
        Rect foldoutRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);

        if (property.isExpanded)
        {
            EditorGUI.indentLevel++;
            float addY = EditorGUIUtility.singleLineHeight;
            for (int i = 0; i < content.arraySize; i++)
            {
                Rect rect = new Rect(position.x, position.y + addY, position.width, EditorGUI.GetPropertyHeight(content.GetArrayElementAtIndex(i)));
                addY += rect.height;
                EditorGUI.PropertyField(rect, content.GetArrayElementAtIndex(i), new GUIContent(enumType.GetEnumNames()[i]), true);
            }
            EditorGUI.indentLevel--;
        }
        EditorGUI.EndProperty();
    }
}
