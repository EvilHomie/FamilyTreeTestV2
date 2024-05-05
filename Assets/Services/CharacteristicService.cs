using System;
using System.Linq;

public static class CharacteristicService 
{
    readonly static Type myType = typeof(PersonCharacteristics);

    #region PublicMethods
    public static void UpdateCharacteristic(PersonCharacteristics person, CharacteristicName charName, string newValue, AffectType affectType)
    {
        var field = myType.GetField(charName.ToString());

        if (field.FieldType == typeof(string))
        {
            field.SetValue(person, newValue);
        }
        else if (field.FieldType == typeof(bool))
        {
            field.SetValue(person, newValue.ToLowerInvariant());
        }
        else if (field.FieldType == typeof(int))
        {
            int currentValue = (int)field.GetValue(person);
            Calculating(ref currentValue, newValue, affectType);
            field.SetValue(person, currentValue);
        }
    }
    public static bool CheckMandatoryConditions(PersonCharacteristics person, GameEvent gameEvent)
    {
        bool totalres = gameEvent.MandatoryConditions.TrueForAll(condition => CheckCharMatchCondition(person, condition.characteristicName, condition.compareType, condition.requiredValue));
        UnityEngine.Debug.Log("TOTAL RESULT : " + totalres);
        return totalres;
    }

    public static bool CheckOrConditions(PersonCharacteristics person, GameEvent gameEvent)
    {
        bool totalres = gameEvent.OrConditions.Any(condition => CheckCharMatchCondition(person, condition.characteristicName, condition.compareType, condition.requiredValue));
        UnityEngine.Debug.Log("TOTAL RESULT : " + totalres);
        return totalres;
    }
    #endregion

    #region PrivateMethods
    static void Calculating(ref int currentValue, string newValue, AffectType affectType)
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

    static bool CheckCharMatchCondition(PersonCharacteristics person, CharacteristicName charName, CompareType compareType, string requiredValue)
    {
        var field = myType.GetField(charName.ToString());
        bool isMatched = false;

        if (field.FieldType == typeof(string))
        {

        }
        else if (field.FieldType == typeof(bool))
        {
            var inputValue = bool.Parse(requiredValue);
            var currentValue = (bool)field.GetValue(person);
            isMatched = compareType switch
            {
                CompareType.Equal => currentValue == inputValue,
                CompareType.NotEqual => currentValue != inputValue,
                _ => false
            };
        }
        else if (field.FieldType == typeof(int))
        {
            var inputValue = int.Parse(requiredValue);
            var currentValue = (int)field.GetValue(person);
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
            $"OldValue : {field.GetValue(person)}  targetValue : {requiredValue}\n " +
            $"Result : {isMatched}");
        return isMatched;        
    }
    #endregion
}
