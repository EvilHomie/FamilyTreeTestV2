using UnityEngine;

public class ManagersLocator
{
    public static CharacteristicManager CharacteristicManager = new();

    public static EventContainer EventContainer;

    public static GameProperties GameProperties;
    public static GameTimeManager GameTimeManager;

    public static void Init()
    {
        EventContainer = GameObject.FindObjectOfType<EventContainer>(true);
        GameProperties = GameObject.FindObjectOfType<GameProperties>(true);
        GameTimeManager = GameObject.FindObjectOfType<GameTimeManager>(true);
    }
}
