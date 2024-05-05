using System;

[Serializable]
public struct Condition
{
    public string conditionName;
    public CharacteristicName characteristicName;
    public CompareType compareType;
    public string requiredValue;
}