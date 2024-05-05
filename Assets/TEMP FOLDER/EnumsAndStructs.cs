using System;
using System.Collections.Generic;

public class EnumsAndStructs
{ 
    public enum AffectType
    {
        Increase,
        Decrease,
        Set
    }

    public enum AditionAction
    {
        BirthBaby,
        Marriage
    }

    public enum CharName
    {
        Name,
        Age,
        Charisma,
        Income,
        Happy,
        Married
    }

    public enum CompareType
    {
        More,
        Less,
        Equal,
        NotEqual
    }

    public enum GameState
    {
        Resume,
        Pause
    }


    [Serializable]
    public struct Choice
    {
        public string discription;
        public List<AffectedCharateristic> affectedCharateristics;
        public List<AditionAction> aditionActions;
    }

    [Serializable]
    public struct AffectedCharateristic
    {
        public CharName charName;
        public AffectType affectType;
        public string affectValue;
    }

    [Serializable]
    public struct Condition
    {
        public string conditionName;
        public CharName charName;
        public CompareType  mustBe;
        public string requiredValue;
    }

    [Serializable]
    public struct EventData
    {
        public string eventName;
        public GameEvent gameEvent;
        public int currentWeight;

        public EventData(GameEvent gameEvent)
        {
            eventName = gameEvent.EventName;
            this.gameEvent = gameEvent;
            currentWeight = gameEvent.Weight;
        }
    }
}
