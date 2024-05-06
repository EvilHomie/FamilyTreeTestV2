using UnityEditor;

[CustomEditor(typeof(ListTester))]
public class TestExtention : Editor
{


    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorList.Show(serializedObject.FindProperty("integers"));
        EditorList.Show(serializedObject.FindProperty("vectors"));
        EditorList.Show(serializedObject.FindProperty("colorPoints"));
        EditorList.Show(serializedObject.FindProperty("objects"));
        serializedObject.ApplyModifiedProperties();
    }

}













//TESTMONOBEH myScrip;

////SerializedProperty _oneTimeEvent;
////SerializedProperty _eventName;
////SerializedProperty _discription;
////SerializedProperty _deffWeight;

//SerializedProperty _mandatoryConditions;
//SerializedProperty _orConditions;
//SerializedProperty _choices;


//void OnEnable()
//{
//    myScrip = (TESTMONOBEH)target;
//    //_oneTimeEvent = serializedObject.FindProperty("_oneTimeEvent");
//    //_eventName = serializedObject.FindProperty("_eventName");
//    //_discription = serializedObject.FindProperty("_discription");
//    //_deffWeight = serializedObject.FindProperty("_deffWeight");

//    _mandatoryConditions = serializedObject.FindProperty("_mandatoryConditions");
//    _orConditions = serializedObject.FindProperty("_orConditions");
//    _choices = serializedObject.FindProperty("_choices");
//}

//public override void OnInspectorGUI()
//{
//    //myScrip.oneTimeEvent = EditorGUILayout.Toggle("OneTimeEvent", myScrip.oneTimeEvent);
//    //myScrip.eventName = EditorGUILayout.TextField("EventName", myScrip.eventName);
//    //myScrip.discription = EditorGUILayout.TextField("Discription", myScrip.discription);
//    //myScrip.deffWeight = EditorGUILayout.IntField("DeffWeight", myScrip.deffWeight);



//    serializedObject.Update();
//    //EditorGUILayout.PropertyField(serializedObject.FindProperty("eventName"));

//    EditorList.Show(serializedObject.FindProperty("mandatoryConditions"));
//    EditorList.Show(serializedObject.FindProperty("orConditions"));
//    EditorList.Show(serializedObject.FindProperty("choices"));



//    //EditorGUILayout.PropertyField(serializedObject.FindProperty("mandatoryConditions"), true);
//    //EditorGUILayout.PropertyField(serializedObject.FindProperty("orConditions"), true);
//    //EditorGUILayout.PropertyField(serializedObject.FindProperty("choices"), true);
//    serializedObject.ApplyModifiedProperties();


//    //Debug.Log(myScrip.eventName);










//    //serializedObject.Update();
//    //base.OnInspectorGUI();

//    //EditorGUILayout.Space();

//    //myScrip.OneTimeEvent = EditorGUILayout.Toggle("OneTimeEvent", myScrip.OneTimeEvent);
//    //myScrip.EventName = EditorGUILayout.TextField("EventName", myScrip.EventName);
//    //myScrip.Discription = EditorGUILayout.TextField("Discription", myScrip.EventName);
//    //myScrip.DeffWeight = EditorGUILayout.IntField("DeffWeight", myScrip.DeffWeight);

//    //EditorGUILayout.PropertyField(_mandatoryConditions, true);

//    //if (boolProperty.boolValue)
//    //{
//    //    OnBoolPropertyTrue();
//    //}

//    //floatProperty.floatValue = EditorGUILayout.FloatField(floatProperty.displayName, floatProperty.floatValue);
//    //intProperty.intValue = EditorGUILayout.IntField(intProperty.displayName, intProperty.intValue);

//    //serializedObject.ApplyModifiedProperties();
//}