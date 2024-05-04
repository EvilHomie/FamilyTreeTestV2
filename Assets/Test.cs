using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using System.Reflection;
using System;
using static EnumsAndStructs;
using System.Xml.Linq;
using System.Runtime.InteropServices;

public class Test : MonoBehaviour
{
    //[SerializeField] AffectedCharacteristic characteristicsType1;
    //[SerializeField] AffectedCharacteristic characteristicsType2;
    //AffectedCharacteristic CharacteristicsType = AffectedCharacteristic.ChangeFirstName;

    //[SerializeField] UnitCharacteristics unitCharacteristics;
    //[SerializeField] CharName charName;
    //[SerializeField] string newValue;
    //[SerializeField] AffectType affect;

    //public string test1 = "qwe";
    //public int test2 = 2;

    //public string TEST1 => test1;

    //object TEST2;

    private void Start()
    {
        //string json = JsonUtility.ToJson(this);
        //Debug.Log(json);
        //Test2 test2 = GetComponent<Test2>();
        //JsonUtility.FromJsonOverwrite(json, test2);
        //Type myType = typeof(Test2);
        //Debug.Log(CharacteristicsType.ToString());
        ////myType.GetField(CharacteristicsType.ToString()).SetValue(test2, characteristicsType1.ToString());

        //var method = myType.GetMethod(CharacteristicsType.ToString());

        //method.Invoke(test2, new object[] { characteristicsType1.ToString(), 10});

        //CharacteristicService.UpdateCharacteristic(charName, newValue, affect);

        //ManagersLocator.CharacteristicService.UpdateCharacteristic(unitCharacteristics, charName, newValue, affect);

        //Type myType = typeof(Test);
        //myType.GetProperty("TEST1").GetType();

        //var field = myType.GetProperty("TEST1");

        //Debug.Log(field.PropertyType == typeof(string));
        //Debug.Log(field.PropertyType == typeof(int));

        //Debug.Log(TEST2.GetType());
        //TEST2 = test1;
        //Debug.Log(TEST2.GetType());
        //TEST2 = test2;
        //Debug.Log(TEST2.GetType());
        //Debug.Log(myType.GetField("test1").GetValue(this));

        //Debug.Log(myType.GetField("test2").GetType());
        //Debug.Log(myType.GetField("test2").GetValue(this));

        

        //Debug.Log((int)Chars[0].Value - (int)Chars[1].Value);
        //Debug.Log((bool)Chars[2].Value == (bool)Chars[3].Value);

        //Debug.Log(Chars[0].Value.GetType());
        //Debug.Log(Chars[2].Value.GetType());
    }

    [SerializeField] TESTCharNames CharTypes;

    //[SerializeField] List<TestChar> Chars = new ();
}

//[Serializable]
//struct TestChar
//{
//    [SerializeField] string charName;
//    [SerializeField] CharType charType;
//    [SerializeField] string _value;
        
//    public object Value 
//    { 
//        get
//        {
//            return charType switch
//            {
//                CharType.String => _value,
//                CharType.Bool => bool.Parse(_value),
//                CharType.Int => int.Parse(_value),
//                _ => null
//            };
//        } 
//        set => _value = (string)value; }
//}

