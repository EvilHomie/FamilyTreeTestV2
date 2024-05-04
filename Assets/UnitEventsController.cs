using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static EnumsAndStructs;

public class UnitEventsController : MonoBehaviour
{
    [SerializeField] List<EventData> _eventsCollection;
    [SerializeField] UnitCharacteristics _unitCharacteristics;
    void Start()
    {
        _eventsCollection = new(ManagersLocator.EventContainer.GetAllEvents());
        EventBus.OnTimeForEvent += OnTimeForEvent; 
    }

    void OnTimeForEvent()
    {
        FindMatchEvent();
    }

    void FindMatchEvent()
    {
        int weightSum = _eventsCollection.Sum(eventData => eventData.currentWeight);

        foreach (EventData eventData in _eventsCollection)
        {
            int targetWeight = Random.Range(0, weightSum);

            if (targetWeight > eventData.currentWeight) continue;
            else
            {
                Debug.Log("Нашелся по весу");
                bool resMCon = ManagersLocator.CharacteristicManager.CheckCharacteristics(_unitCharacteristics, eventData.gameEvent);
                bool resOrCon = ManagersLocator.CharacteristicManager.ORCheckCharacteristics(_unitCharacteristics, eventData.gameEvent);
                Choice choice = eventData.gameEvent.Choices[0];
                AffectedCharateristic affectedCharateristic = choice.affectedCharateristics[0];


                if (resMCon && resOrCon) ManagersLocator.CharacteristicManager.UpdateCharacteristic(_unitCharacteristics, affectedCharateristic.charName, affectedCharateristic.affectValue, affectedCharateristic.affectType);
                //EventBus.OnPause?.Invoke();
                //EventBus.OnEventFound?.Invoke(this, eventData.gameEvent);
                //return;
            }
        }
    }
}
