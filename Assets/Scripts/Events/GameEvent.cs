using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "GO/GameEvent")]
public class GameEvent : ScriptableObject
{
    [SerializeField] bool _oneTimeEvent;    
    [SerializeField] string _eventName;
    [Space(10)]
    [Multiline(5)]    
    [SerializeField] string _discription;
    [Space(10)]
    [SerializeField] int _deffWeight;
    [Space(10)]
    [SerializeField] List<Condition> _mandatoryConditions = new();
    [Space(10)]
    [SerializeField] List<Condition> _orConditions = new();
    [Space(10)]
    [SerializeField] List<Choice> _choices = new();

    public List<Condition> MandatoryConditions => _mandatoryConditions;
    public List<Condition> OrConditions => _orConditions;
    public List<Choice> Choices => _choices;


    public string EventName => _eventName;
    public string Discription => _discription;
    public int DeffWeight => _deffWeight;
    public bool OneTimeEvent => _oneTimeEvent;
}

