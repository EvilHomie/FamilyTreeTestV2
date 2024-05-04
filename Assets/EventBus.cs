using System;

public class EventBus
{
    public static Action OnTick;
    
    public static Action OnTimeForEvent;

    public static Action<UnitEventsController, GameEvent> OnEventFound;

    public static Action OnPause;
    public static Action OnResume;
}
