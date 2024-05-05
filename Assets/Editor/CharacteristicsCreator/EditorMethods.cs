using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CharacteristicsCreator
{
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

        public static void WriteToPersonCharacteristics(string path, string characteristicsFileName, string extension, List<Characteristic> CharData)
        {
            using (StreamWriter file = File.CreateText(path + characteristicsFileName + extension))
            {
                file.WriteLine("using UnityEngine;");
                file.WriteLine(string.Empty);
                file.WriteLine("public class " + characteristicsFileName + " : MonoBehaviour");
                file.WriteLine("{");

                foreach (var characteristic in CharData)
                {
                    file.WriteLine($"    public {characteristic.characteristicType.ToString().ToLowerInvariant()} {characteristic.characteristicName};");
                }
                file.WriteLine("}");

            }

            AssetDatabase.ImportAsset(path + characteristicsFileName + extension);
        }

        public static void ReadFromEnum(string pathToEnumWithFieldNames, string pathToTextWithFieldTypes, List<Characteristic> CharData)
        {
            List<string> enumCharNamesLines = File.ReadAllLines(pathToEnumWithFieldNames).ToList();
            List<string> enumCharTypesLines = File.ReadAllLines(pathToTextWithFieldTypes).ToList();

            enumCharNamesLines.RemoveRange(0, 2);
            enumCharTypesLines.RemoveRange(0, 2);
            int lastIndex = enumCharNamesLines.Count - 1;
            enumCharNamesLines.RemoveAt(lastIndex);
            enumCharTypesLines.RemoveAt(lastIndex);

            CharData.Clear();

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
                Characteristic testCharStruct = new()
                {
                    characteristicName = enumCharNamesLines[i],
                    characteristicType = (CharacteristicType)Enum.Parse(typeof(CharacteristicType), enumCharTypesLines[i])
                };
                CharData.Add(testCharStruct);
            }
        }
    }
}

