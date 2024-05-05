using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CharacteristicsCreator
{
    [CustomEditor(typeof(CharacteristicCreator))]
    public class EditorExtention : Editor
    {
        CharacteristicCreator myScrip;
        const string assetExtension = ".cs";
        const string textExtension = ".txt";

        // Data for Editor
        string editorFilesSaveFolder = "Assets/Editor/CharacteristicsCreator/";
        string charTypesFileName = "CharacteristicType";

        // Data for Enum CharacteristicName        
        string folderForEnums = "Assets/Scripts/General/Enums/";
        string charNamesFileName = "CharacteristicName";

        // Data for Class PersonCharacteristics
        string folderForPersonCharacteristics = "Assets/Scripts/Person/";
        string personCharacteristicsFileName = "PersonCharacteristics";

        private void OnEnable()
        {
            myScrip = (CharacteristicCreator)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            //saveFolder = EditorGUILayout.TextField("SaveFolder", saveFolder);
            //enumTESTCharNames = EditorGUILayout.TextField("EnumCharNamesFileName", enumTESTCharNames);
            //enumTESTCharTypes = EditorGUILayout.TextField("EnumCharTypesFileName", enumTESTCharTypes);
            //unitCharacteristicsFileName = EditorGUILayout.TextField("UnitCharacteristicsFileName", unitCharacteristicsFileName);
            if (GUILayout.Button("Save Files"))
            {
                EditorMethods.WriteToEnums(folderForEnums, charNamesFileName, assetExtension, myScrip.enumFields.Select(data => data.characteristicName.ToString()).ToList());
                EditorMethods.WriteToEnums(editorFilesSaveFolder, charTypesFileName, textExtension, myScrip.enumFields.Select(data => data.characteristicType.ToString()).ToList());
                EditorMethods.WriteToPersonCharacteristics(folderForPersonCharacteristics, personCharacteristicsFileName, assetExtension, myScrip.enumFields);
            }
            if (GUILayout.Button("Read Enum File"))
            {
                string pathToEnumWithFieldNames = $"{folderForEnums}{charNamesFileName}{assetExtension}";
                string pathToTextWithFieldTypes = $"{editorFilesSaveFolder}{charTypesFileName}{textExtension}";
                EditorMethods.ReadFromEnum(pathToEnumWithFieldNames, pathToTextWithFieldTypes, myScrip.enumFields);
            }
        }
    }

    [CustomEditor(typeof(GameEvent))]
    public class ChoiceExtention : Editor
    {
        GameEvent myScrip;

        //SerializedProperty _oneTimeEvent;
        //SerializedProperty _eventName;
        //SerializedProperty _discription;
        //SerializedProperty _deffWeight;

        SerializedProperty _mandatoryConditions;
        SerializedProperty _orConditions;
        SerializedProperty _choices;


        void OnEnable()
        {
            myScrip = (GameEvent)target;
            //_oneTimeEvent = serializedObject.FindProperty("_oneTimeEvent");
            //_eventName = serializedObject.FindProperty("_eventName");
            //_discription = serializedObject.FindProperty("_discription");
            //_deffWeight = serializedObject.FindProperty("_deffWeight");

            _mandatoryConditions = serializedObject.FindProperty("_mandatoryConditions");
            _orConditions = serializedObject.FindProperty("_orConditions");
            _choices = serializedObject.FindProperty("_choices");
        }

        public override void OnInspectorGUI()
        {
            //serializedObject.Update();
            base.OnInspectorGUI();

            //EditorGUILayout.Space();

            //myScrip.OneTimeEvent = EditorGUILayout.Toggle("OneTimeEvent", myScrip.OneTimeEvent);
            //myScrip.EventName = EditorGUILayout.TextField("EventName", myScrip.EventName);
            //myScrip.Discription = EditorGUILayout.TextField("Discription", myScrip.EventName);
            //myScrip.DeffWeight = EditorGUILayout.IntField("DeffWeight", myScrip.DeffWeight);

            //EditorGUILayout.PropertyField(_mandatoryConditions, true);

            //if (boolProperty.boolValue)
            //{
            //    OnBoolPropertyTrue();
            //}

            //floatProperty.floatValue = EditorGUILayout.FloatField(floatProperty.displayName, floatProperty.floatValue);
            //intProperty.intValue = EditorGUILayout.IntField(intProperty.displayName, intProperty.intValue);

            //serializedObject.ApplyModifiedProperties();
        }

    }
}
//[SerializeField] bool _oneTimeEvent;
//[SerializeField] string _eventName;
//[SerializeField] string _discription;
//[SerializeField] int _deffWeight;

//[SerializeField] List<Condition> _mandatoryConditions = new();
//[SerializeField] List<Condition> _orConditions = new();
//[SerializeField] List<Choice> _choices = new();
