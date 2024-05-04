using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacteristicCreator : MonoBehaviour
{
    public List<TestCharStruct> enumFields;
}

[Serializable]
public struct TestCharStruct
{
    public string charName;
    public CharType charType;
}

public enum CharType
{
    String,
    Bool,
    Int
}