using System;
using System.Linq;
using static EnumsAndStructs;

public class CharacteristicManager 
{
    readonly Type myType = typeof(UnitCharacteristics);

    public void UpdateCharacteristic(UnitCharacteristics unit, CharName charName, string newValue, AffectType affectType)
    {
        var property = myType.GetProperty(charName.ToString());

        if (property.PropertyType == typeof(string))
        {
            property.SetValue(unit, newValue);
        }
        else if (property.PropertyType == typeof(bool))
        {
            property.SetValue(unit, newValue);
        }
        else if (property.PropertyType == typeof(int))
        {
            int currentValue = (int)property.GetValue(unit);
            Calculating(ref currentValue, newValue, affectType);
            property.SetValue(unit, currentValue);
        }
    }

    void Calculating(ref int currentValue, string newValue, AffectType affectType)
    {
        int inputValue = int.Parse(newValue);

        currentValue = affectType switch
        {
            AffectType.Increase => currentValue + inputValue,
            AffectType.Decrease => currentValue - inputValue,
            AffectType.Set => inputValue,
            _ => 0
        };

        if (currentValue < 0) currentValue = 0;
    }

    public bool CheckCharacteristics(UnitCharacteristics unit, GameEvent gameEvent)
    {
        bool totalres = gameEvent.Conditions.TrueForAll(condition => CheckCharMatchCondition(unit, condition.charName, condition.mustBe, condition.requiredValue));
        UnityEngine.Debug.Log("TOTAL RESULT : " + totalres);
        return totalres;
    }

    public bool ORCheckCharacteristics(UnitCharacteristics unit, GameEvent gameEvent)
    {
        bool totalres = gameEvent.Conditions.Any(condition => CheckCharMatchCondition(unit, condition.charName, condition.mustBe, condition.requiredValue));
        UnityEngine.Debug.Log("TOTAL RESULT : " + totalres);
        return totalres;
    }

    bool CheckCharMatchCondition(UnitCharacteristics unit, CharName charName, CompareType compareType, string requiredValue)
    {
        var property = myType.GetProperty(charName.ToString());
        bool isMatched = false;

        if (property.PropertyType == typeof(string))
        {

        }
        else if (property.PropertyType == typeof(bool))
        {
            var inputValue = bool.Parse(requiredValue);
            var currentValue = (bool)property.GetValue(unit);
            isMatched = compareType switch
            {
                CompareType.Equal => currentValue == inputValue,
                CompareType.NotEqual => currentValue != inputValue,
                _ => false
            };
        }
        else if (property.PropertyType == typeof(int))
        {
            var inputValue = int.Parse(requiredValue);
            var currentValue = (int)property.GetValue(unit);
            isMatched = compareType switch
            {
                CompareType.Equal => currentValue == inputValue,
                CompareType.NotEqual => currentValue != inputValue,
                CompareType.Less => currentValue < inputValue,
                CompareType.More => currentValue > inputValue,
                _ => false
            };
        }
        UnityEngine.Debug.Log($" COMPARE RESULT \n " +
            $"CharName : {charName}\n" +
            $"CompareType : {compareType}\n" +
            $"OldValue : {property.GetValue(unit)}  targetValue : {requiredValue}\n " +
            $"Result : {isMatched}");
        return isMatched;        
    }
}
