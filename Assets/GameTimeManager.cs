using System;
using UnityEngine;
using static EnumsAndStructs;

public class GameTimeManager : MonoBehaviour
{
    DateTime _currentDateTime;
    GameState _gamestate;
    float _timeSinceLastTick = 0;
    int _tickCount = 0;

    private void Start()
    {
        _currentDateTime = DateTime.Parse(ManagersLocator.GameProperties.StartDate);
        EventBus.OnPause += () => { _gamestate = GameState.Pause; };
        EventBus.OnResume += () => { _gamestate = GameState.Resume; };
    }

    void Update()
    {
        if (!EntryPoint.initialized) return;
        Tick();
    }

    public void Tick()
    {        
        if (_gamestate != GameState.Resume) return;
        _timeSinceLastTick += Time.deltaTime;
        if (_timeSinceLastTick <= ManagersLocator.GameProperties.TickRate) return;
        _tickCount++;
        _timeSinceLastTick = 0;

        _currentDateTime = _currentDateTime.AddDays(ManagersLocator.GameProperties.DayPerTick);
        EventBus.OnTick?.Invoke();

        if (_tickCount <= ManagersLocator.GameProperties.TicksNumberForCallEvents) return;
        _tickCount = 0;
        EventBus.OnTimeForEvent?.Invoke();
    }
}
