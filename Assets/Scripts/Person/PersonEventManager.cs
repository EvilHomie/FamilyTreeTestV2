using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PersonEventManager : MonoBehaviour
{
    [SerializeField] List<EventData> _eventsCollection;
    [SerializeField] PersonCharacteristics _personCharacteristics;
    void Awake()
    {
        _personCharacteristics = GetComponent<PersonCharacteristics>();
        //_eventsCollection = new(ServicesLocator.EventContainer.GetAllEvents());
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
                bool resMCon = CharacteristicService.CheckMandatoryConditions(_personCharacteristics, eventData.gameEvent);
                bool resOrCon = CharacteristicService.CheckOrConditions(_personCharacteristics, eventData.gameEvent);
                Choice choice = eventData.gameEvent.Choices[0];
                AffectedCharateristic affectedCharateristic = choice.affectedCharateristics[0];


                if (resMCon && resOrCon) CharacteristicService.UpdateCharacteristic(_personCharacteristics, affectedCharateristic.charName, affectedCharateristic.affectValue, affectedCharateristic.affectType);
                //EventBus.OnPause?.Invoke();
                //EventBus.OnEventFound?.Invoke(this, eventData.gameEvent);
                //return;
            }
        }
    }
}
