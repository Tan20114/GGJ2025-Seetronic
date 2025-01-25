using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MaxLengthAttribute))]
public class MaxLengthDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        MaxLengthAttribute maxLength = (MaxLengthAttribute)attribute;

        if (property.propertyType == SerializedPropertyType.String)
        {
            property.stringValue = EditorGUI.TextField(position, label, property.stringValue);

            if (property.stringValue.Length > maxLength.maxLength)
            {
                property.stringValue = property.stringValue.Substring(0, maxLength.maxLength);
            }
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
