using System;
using System.Collections.Generic;
using UnityEngine;
using static EnumsAndStructs;

[CreateAssetMenu(fileName = "Event", menuName = "GO/GameEvent")]
public class GameEvent : ScriptableObject
{
    [SerializeField] string _eventName;
    [SerializeField] string _discription;
    [SerializeField] int _weight;

    [SerializeField] List<Condition> _conditions = new();
    [SerializeField] List<Condition> _orConditions = new();
    [SerializeField] List<Choice> _choices = new();

    public List<Condition> Conditions => _conditions;
    public List<Condition> OrConditions => _orConditions;
    public List<Choice> Choices => _choices;


    public string EventName => _eventName;
    public string Discription => _discription;
    public int Weight => _weight;

    public void ClearConditions()
    {
        _conditions.Clear();
    }

    public void ClearOrConditions()
    {
        _orConditions.Clear();
    }

    public void ClearChoices()
    {
        _choices.Clear();
    }

}

