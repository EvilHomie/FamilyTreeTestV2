using System;

public class EventBus
{
    public static Action OnTick;
    
    public static Action OnTimeForEvent;

    public static Action<PersonEventManager, GameEvent> OnEventFound;

    public static Action<GameState> OnChangeGameState;
}
