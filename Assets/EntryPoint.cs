using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public static bool initialized;
    private void Awake()
    {
        ManagersLocator.Init();
        initialized = true;
    }
}
