using UnityEngine;


public class EntryPoint : MonoBehaviour
{
    public static bool _initialized;
    private void Awake()
    {
        EventHolder.Init();
        FindObjectOfType<GameProperties>().Init();
        FindObjectOfType<TimeFlowService>().Init();
        _initialized = true;
    }
}


