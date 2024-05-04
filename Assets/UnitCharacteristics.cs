using UnityEngine;

public class UnitCharacteristics : MonoBehaviour
{
    
    [Header("Main Characteristics")]
    [SerializeField] string _firstName;
    [SerializeField] int _age;
    [SerializeField] int _charisma;
    [SerializeField] int _income;
    [SerializeField] int _happy;

    [SerializeField] bool _married;

    public string FirstName { get => _firstName; private set => _firstName = value; }
    public int Age { get => _age; private set => _age = value; }
    public int Charisma { get => _charisma; private set => _charisma = value; }
    public int Income { get => _income; private set => _income = value; }
    public int Happy { get => _happy; private set => _happy = value; }

    public bool Married { get => _married; private set => _married = value; }
}
