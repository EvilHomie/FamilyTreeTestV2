using System.Collections.Generic;
using UnityEngine;

public static class EventHolder
{
    static List<EventData> _eventsCollection;
    public static List<EventData> GetAllEvents() { return _eventsCollection; }

    public static void Init()
    {
        _eventsCollection = new();

        GameEvent[] events = Resources.LoadAll<GameEvent>("Events");

        foreach (var e in events)
        {
            _eventsCollection.Add(new(e));
        }
    }
}


