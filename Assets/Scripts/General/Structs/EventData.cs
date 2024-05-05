using System;

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
        currentWeight = gameEvent.DeffWeight;
    }
}