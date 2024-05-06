using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AditionAction))]
public class AditionActionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //label = EditorGUI.BeginProperty(position, label, property);
        EditorGUI.BeginProperty(position, label, property);
        ////Rect contentPosition = EditorGUI.PrefixLabel(position, label);
        //position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var actionTypeRect = new Rect(position.x, position.y, 100, position.height);
        var enterEventNameLableRect = new Rect(position.x + 110, position.y, 80, position.height);
        var aditionEventNameRect = new Rect(position.x + 200, position.y, 100, position.height);

        var nameField = property.FindPropertyRelative("name");
        var actionTypeField = property.FindPropertyRelative("actionType");
        var aditionEventNameField = property.FindPropertyRelative("aditionEventName");

        GUIStyle gUIStyle = new() { fontStyle = FontStyle.Bold };

        if (string.IsNullOrEmpty(aditionEventNameField.stringValue) || string.IsNullOrWhiteSpace(aditionEventNameField.stringValue))
            gUIStyle.normal.textColor = Color.red;
        else gUIStyle.normal.textColor = Color.green;

        EditorGUI.PropertyField(actionTypeRect, actionTypeField, GUIContent.none);
        if (actionTypeField.enumValueIndex == (int)AditionActionType.AnotherEvent)
        {
            EditorGUI.LabelField(enterEventNameLableRect, "Event Name: ", gUIStyle);
            EditorGUI.PropertyField(aditionEventNameRect, aditionEventNameField, GUIContent.none);
        }


        nameField.stringValue = Enum.GetName(typeof(AditionActionType), actionTypeField.enumValueIndex);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}

