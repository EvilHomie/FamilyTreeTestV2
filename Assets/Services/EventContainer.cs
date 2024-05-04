using System.Collections.Generic;
using UnityEngine;
using static EnumsAndStructs;

public class EventContainer: MonoBehaviour
{
    [SerializeField] List<EventData> _eventsCollection = new();

    public List<EventData> GetAllEvents() { return _eventsCollection; }
}

