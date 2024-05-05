using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnumsAndStructs;

public class Test2 : MonoBehaviour
{
    [SerializeField] AffectType characteristicsType1;
    [SerializeField] AffectType characteristicsType2;
    [SerializeField] string Strinf;
    [SerializeField] int age;

    //public string Strinf { get => strinf; set => strinf = value; }


    public void ChangeFirstName(string name, int age)
    {
        Strinf = name;
        this.age = age;
    }
}
