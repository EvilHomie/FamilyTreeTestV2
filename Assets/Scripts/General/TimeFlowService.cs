using System;
using UnityEngine;


public class TimeFlowService : MonoBehaviour
{
    public static TimeFlowService Instance;
    public DateTime _currentDateTime;
    
    GameState _gamestate;
    float _timeSinceLastTick = 0;
    int _tickCount = 0;

    public void Init()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        _currentDateTime = DateTime.Parse(GameProperties.Instance.StartDate);
        EventBus.OnChangeGameState += (state) => { _gamestate = state; };
    }

    void Update()
    {
        if (!EntryPoint._initialized) return;
        Tick();
    }

    public void Tick()
    {
        if (_gamestate != GameState.Resume) return;
        _timeSinceLastTick += Time.deltaTime;

        if (_timeSinceLastTick <= GameProperties.Instance.TickRate) return;
        _tickCount++;
        _timeSinceLastTick = 0;

        _currentDateTime = _currentDateTime.AddDays(GameProperties.Instance.DayPerTick);
        EventBus.OnTick?.Invoke();

        if (_tickCount <= GameProperties.Instance.TicksNumberForCallEvents) return;
        _tickCount = 0;
        EventBus.OnTimeForEvent?.Invoke();
    }
}


