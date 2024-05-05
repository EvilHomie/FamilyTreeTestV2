using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEventPopUp : MonoBehaviour
{
    public static UIEventPopUp instance;

    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI discriptionText;
    [SerializeField] List<Button> choiceButtons = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //private void Start()
    //{
    //    EventBus.OnTimeForEvent += OnEventFound;
    //}

    //private void OnEventFound(GameEvent incomeEvent)
    //{
    //    titleText.text = incomeEvent.EventName;
    //    discriptionText.text = incomeEvent.Discription;
    //}
}
