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

        // Data for edtior
        string editorFilesSaveFolder = "Assets/Editor/CharacteristicsCreator/";
        string charTypesFileName = "CharacteristicType";

        // Data for Enum characteristicName        
        string folderForEnums = "Assets/Scripts/General/Enums/";
        string charNamesFileName = "CharacteristicName";

        // Data for Class PersonCharacteristics
        string folderForPersonCharacteristics = "Assets/Scripts/General/";                
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
}

