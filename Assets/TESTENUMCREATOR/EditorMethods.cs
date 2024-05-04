using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EditorMethods : Editor
{
    
    public static void WriteToEnums(string path, string enumFileName, string extension, List<string> charName)
    {
        Debug.Log("awd");
        using (StreamWriter file = File.CreateText(path + enumFileName + extension))
        {
            file.WriteLine("public enum " + enumFileName);
            file.WriteLine("{");

            //int i = 0;
            foreach (var line in charName)
            {
                string lineRep = line.Replace(" ", string.Empty);
                if (!string.IsNullOrEmpty(lineRep))
                {
                    //file.WriteLine(string.Format("	{0} = {1},", lineRep, i));
                    file.WriteLine($"    {lineRep},");
                    //i++;
                }
            }

            file.WriteLine("}");

        }

        AssetDatabase.ImportAsset(path + enumFileName + extension);
    }

    public static void WriteToUnitCharacteristics(string path, string characteristicsFileName, string extension, List<TestCharStruct> data)
    {
        using (StreamWriter file = File.CreateText(path + characteristicsFileName + extension))
        {
            file.WriteLine("using UnityEngine;");
            file.WriteLine(string.Empty);
            file.WriteLine("public class " + characteristicsFileName + " : MonoBehaviour");
            file.WriteLine("{");

            foreach (var str in data)
            {
                file.WriteLine($"    public {str.charType.ToString().ToLowerInvariant()} {str.charName};");
            }
            file.WriteLine("}");

        }

        AssetDatabase.ImportAsset(path + characteristicsFileName + extension);
    }

    public static void ReadFromEnum(string path, string charNamesFile, string extension_1, string charTypesFile, string extension_2, List<TestCharStruct> data)
    {
        List<string> enumCharNamesLines = File.ReadAllLines(path + charNamesFile + extension_1).ToList();
        List<string> enumCharTypesLines = File.ReadAllLines(path + charTypesFile + extension_2).ToList();

        enumCharNamesLines.RemoveRange(0, 2);
        enumCharTypesLines.RemoveRange(0, 2);
        int lastIndex = enumCharNamesLines.Count - 1;
        enumCharNamesLines.RemoveAt(lastIndex);
        enumCharTypesLines.RemoveAt(lastIndex);

        data.Clear();

        for (int i = 0; i < enumCharNamesLines.Count; i++)
        {
            enumCharNamesLines[i] = enumCharNamesLines[i].Replace(",", string.Empty);
            enumCharNamesLines[i] = enumCharNamesLines[i].Replace(" ", string.Empty);
        }

        for (int i = 0; i < enumCharTypesLines.Count; i++)
        {
            enumCharTypesLines[i] = enumCharTypesLines[i].Replace(",", string.Empty);
            enumCharTypesLines[i] = enumCharTypesLines[i].Replace(" ", string.Empty);
        }

        for (int i = 0; i < enumCharNamesLines.Count; i++)
        {
            TestCharStruct testCharStruct = new()
            {
                charName = enumCharNamesLines[i],
                charType = (CharType)Enum.Parse(typeof(CharType), enumCharTypesLines[i])
            };
            data.Add(testCharStruct);
        }
    }
}
