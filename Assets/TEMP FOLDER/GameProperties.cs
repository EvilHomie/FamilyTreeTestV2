using UnityEngine;

public class GameProperties : MonoBehaviour
{
    [SerializeField] private string _startDate = "01.01.2020";
    [SerializeField] private float _decreaseWeightCoefficient = 0.5f;
    [SerializeField] private float _increaseWeightCoefficient = 0.2f;
    [SerializeField] private float _tickRate = 0.1f;
    [SerializeField] private int _dayPerTick = 7;
    [SerializeField] private int _ticksNumberForCallEvents = 50;

    public string StartDate => _startDate;

    public float BaseSubjectWeightCorrectionCoefficient => _decreaseWeightCoefficient;

    public float BaseSubjectWeightRestoreCoefficient => _increaseWeightCoefficient;

    public float TickRate => _tickRate;

    public int DayPerTick => _dayPerTick;

    public int TicksNumberForCallEvents => _ticksNumberForCallEvents;
}
