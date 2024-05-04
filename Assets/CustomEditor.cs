//using System.Collections.Generic;
//using UnityEditor;
//using UnityEditor.PackageManager.UI;
//using UnityEngine;
//using static EnumsAndStructs;


//[CustomEditor(typeof(GameEvent))]
//[CanEditMultipleObjects]
//public class GameEventEditor : Editor
//{
//    int selectedToolbarNumber = 0;
//    readonly string[] toolbarStrings = { "Separate  Conditions", "Or Conditions", "Choices" };

//    GameEvent queryManager;


//    SerializedProperty _eventName;
//    SerializedProperty _discription;
//    SerializedProperty _weight;

//    SerializedProperty _conditions;
//    SerializedProperty _orConditions;
//    SerializedProperty _choices;

//    void OnEnable()
//    {
//        _eventName = serializedObject.FindProperty("_eventName");
//        _discription = serializedObject.FindProperty("_discription");
//        _weight = serializedObject.FindProperty("_weight");

//        _conditions = serializedObject.FindProperty("_conditions");
//        _orConditions = serializedObject.FindProperty("_orConditions");
//        _choices = serializedObject.FindProperty("_choices");
//    }

//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();
//        //serializedObject.Update();

//        //EditorGUILayout.PropertyField(_eventName, true);
//        //EditorGUILayout.PropertyField(_discription, true);
//        //EditorGUILayout.PropertyField(_weight, true);

//        //EditorGUILayout.TextField(_eventName.displayName, _eventName.stringValue);
//        //EditorGUILayout.TextField(_discription.displayName, _discription.stringValue);
//        //_weight.intValue = EditorGUILayout.IntField(_weight.displayName, _weight.intValue);

//        selectedToolbarNumber = GUILayout.Toolbar(selectedToolbarNumber, toolbarStrings);
//        queryManager = (GameEvent)target;

//        switch (toolbarStrings[selectedToolbarNumber])
//        {
//            case "Separate  Conditions":
//                EditorGUILayout.PropertyField(_conditions, true);
//                if (GUILayout.Button("Clear Conditions")) queryManager.ClearConditions();
//                break;

//            case "Or Conditions":
//                EditorGUILayout.PropertyField(_orConditions, true);
//                if (GUILayout.Button("Clear OrConditions")) queryManager.ClearOrConditions();
//                break;

//            case "_choices":
//                EditorGUILayout.PropertyField(_choices, true);
//                if (GUILayout.Button("Clear Choices")) queryManager.ClearOrConditions();
//                break;
//        }
//    }
//}

//////[CustomEditor(typeof(GameEvent))]
//////[CanEditMultipleObjects]
//////public class GameEventEditor : Editor
//////{
//////    int selectedToolbarNumber = 0;
//////    readonly string[] toolbarStrings = { "Separate  Conditions", "Or Conditions" };

//////    GameEvent queryManager;

//////    public override void OnInspectorGUI()
//////    {

//////        queryManager = (GameEvent)target;
//////        DrawDefaultInspector();
//////        selectedToolbarNumber = GUILayout.Toolbar(selectedToolbarNumber, toolbarStrings);

//////        switch (toolbarStrings[selectedToolbarNumber])
//////        {
//////            case "Separate  Conditions":
//////                GUILayout.BeginArea(new Rect(10, 10, 100, 100));
//////                GUILayout.Button("Click me");
//////                GUILayout.Button("Or me");
//////                GUILayout.EndArea();
//////                //queryManager.EditMainText(text);
//////                break;

//////            case "Or Conditions":
//////                //queryManager.EditExtraText(GUILayout.TextField(queryManager.extraTextTMP.text, GameConfig.maxTextLength));
//////                break;
//////        }

//////        //if (GUILayout.Button("SAVE TEXTS FOR BOTS"))
//////        //{
//////        //    queryManager.SaveTexts();
//////        //}
//////    }
//////}

////[CustomEditor(typeof(Example))]
////public class CustomExample : Editor
////{
////    SerializedProperty boolProperty;
////    SerializedProperty floatProperty;
////    SerializedProperty intProperty;


////    void OnEnable()
////    {
////        boolProperty = serializedObject.FindProperty("boolVariable");
////        floatProperty = serializedObject.FindProperty("floatVariable");
////        intProperty = serializedObject.FindProperty("intVariable");
////    }


////    public override void OnInspectorGUI()
////    {
////        serializedObject.Update();

////        EditorGUILayout.Space();

////        boolProperty.boolValue = EditorGUILayout.Toggle(boolProperty.displayName, boolProperty.boolValue);

////        if (boolProperty.boolValue)
////        {
////            OnBoolPropertyTrue();
////        }

////        floatProperty.floatValue = EditorGUILayout.FloatField(floatProperty.displayName, floatProperty.floatValue);
////        intProperty.intValue = EditorGUILayout.IntField(intProperty.displayName, intProperty.intValue);

////        serializedObject.ApplyModifiedProperties();
////    }


////    void OnBoolPropertyTrue()
////    {
////        EditorGUILayout.LabelField("I AM BELOW THE BOOL PROPERTY NOW");
////    }
////}
