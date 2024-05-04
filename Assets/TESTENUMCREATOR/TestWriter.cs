using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacteristicCreator))]
public class TestWriter : Editor
{
    CharacteristicCreator myScrip;
    const string assetExtension = ".cs";
    const string textExtension = ".txt";
    string saveFolder = "Assets/TESTENUMCREATOR/";
    string enumTESTCharNames = "TESTCharNames";
    string enumTESTCharTypes = "TESTCharTypes";
    string unitCharacteristicsFileName = "TESTUnitCharacteristics";

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
            EditorMethods.WriteToEnums(saveFolder, enumTESTCharNames, assetExtension, myScrip.enumFields.Select(data => data.charName.ToString()).ToList());
            EditorMethods.WriteToEnums(saveFolder, enumTESTCharTypes, textExtension, myScrip.enumFields.Select(data => data.charType.ToString()).ToList());
            EditorMethods.WriteToUnitCharacteristics(saveFolder, unitCharacteristicsFileName, assetExtension, myScrip.enumFields);
        }
        if (GUILayout.Button("Read Enum File"))
        {
            EditorMethods.ReadFromEnum(saveFolder, enumTESTCharNames, assetExtension, enumTESTCharTypes, textExtension, myScrip.enumFields);
        }
    }
}
