using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EnumDataAttribute))]
public class EnumDataAttributeDrawer : PropertyDrawer
{
    private SerializedProperty array;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EnumDataAttribute enumData = (EnumDataAttribute)attribute;
        string path = property.propertyPath;
        if (array == null)
        {
            array = property.serializedObject.FindProperty(path.Substring(0, path.LastIndexOf('.')));
            if (array == null)
            {
                EditorGUI.LabelField(position, "Use EnumDataAttribute on arrays.");
                return;
            }
        }
        
        if (array.arraySize != enumData.names.Length)
        {
            array.arraySize = enumData.names.Length;
        }
        
        // These two lines are edited from the video to fix an issue of nested arrays and garbage from Replace.
        int indexOfNum = path.LastIndexOf('[') + 1;
        int index = System.Convert.ToInt32(path.Substring(indexOfNum, path.LastIndexOf(']') - indexOfNum));
        //
        label.text = enumData.names[index];
        EditorGUI.PropertyField(position, property, label, true);
    }
}
