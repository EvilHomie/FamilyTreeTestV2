//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

////[ExecuteInEditMode]
//public class BirthAbility : MonoBehaviour
//{
//    [SerializeField] bool ignoreLG;

//    LayoutElement layoutElement;
//    ContentSizeFitter contentSizeFitter;
//    RectTransform rectTransform;
//    bool abilityActiveStatus = false;
//    bool temp = false;
//    //private void Awake()
//    //{
//    //    layoutElement = GetComponent<LayoutElement>();
//    //    contentSizeFitter = GetComponent<ContentSizeFitter>();
//    //    rectTransform = GetComponent<RectTransform>();
//    //}

//    //private void Update()
//    //{
//    //    if (temp != ignoreLG)
//    //    {
//    //        temp = ignoreLG;
//    //        //Test123();

//    //        //layoutElement.ignoreLayout = ignoreLG;
//    //        //contentSizeFitter.enabled = ignoreLG;

//    //        if (ignoreLG)
//    //            GetComponent<LayoutElement>().preferredWidth = GetComponent<RectTransform>().rect.width;
//    //        else
//    //            GetComponent<LayoutElement>().preferredWidth = -1;

//    //        foreach (Transform child in transform)
//    //        {
//    //            child.GetComponent<LayoutElement>().ignoreLayout = ignoreLG;
//    //            child.GetComponent<ContentSizeFitter>().enabled = ignoreLG;
//    //            child.GetComponent<SocialUnit>().xMark.SetActive(!child.GetComponent<SocialUnit>().xMark.activeSelf);
//    //        }

//    //    }
//    //}
//    public void SwitchBirthAbility()
//    {
//        abilityActiveStatus = !abilityActiveStatus;

//        if (abilityActiveStatus)
//            GetComponent<LayoutElement>().preferredWidth = GetComponent<RectTransform>().rect.width;
//        else
//            GetComponent<LayoutElement>().preferredWidth = -1;

//        foreach (Transform child in transform)
//        {
//            child.GetComponent<LayoutElement>().ignoreLayout = abilityActiveStatus;
//            child.GetComponent<ContentSizeFitter>().enabled = abilityActiveStatus;
//            child.GetComponent<SocialUnit>().xMark.SetActive(!child.GetComponent<SocialUnit>().xMark.activeSelf);
//        }
//    }

//    //public void OnPointerClick(PointerEventData eventData)
//    //{
//    //    if (eventData.button == PointerEventData.InputButton.Middle)
//    //    {
//    //        SwitchBirthAbility();
//    //    }        
//    //}
//    //void Test123()
//    //{
//    //    Vector3 tempPos = rectTransform.localPosition;

//    //    layoutElement.ignoreLayout = true;

//    //    rectTransform.localPosition = tempPos;

//    //}
//}
