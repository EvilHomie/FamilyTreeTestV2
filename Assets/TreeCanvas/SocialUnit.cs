using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SocialUnit : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject parentsContainer;
    [SerializeField] GameObject childsConteiner;

    [SerializeField] GameObject mainParent;
    [SerializeField] GameObject secondParent;
    

    VerticalLayoutGroup verticalLayoutGroup;
    TreeConfig config;
    GameObject lastChild;

    private void Awake()
    {
        verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        config = FindObjectOfType<TreeConfig>();
    }

    void AddPartner()
    {
        if (secondParent.activeSelf) return;
        secondParent.SetActive(true);
    }

    void AddChild()
    {
        if (!secondParent.activeSelf) return;
        lastChild = Instantiate(config.socialUnitPF, childsConteiner.transform);
    }

    void CreateConnectionLine()
    {
        if (!secondParent.activeSelf) return;
        GameObject connectionLine = Instantiate(config.ConnectionLinePF, transform);
        connectionLine.GetComponent<ConnectionLine>().SetUpCurve(parentsContainer, lastChild);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            AddPartner();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            //SwitchBirthAbility();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            AddChild();
            CreateConnectionLine();
        }
    }
    private void Update()
    {
        verticalLayoutGroup.spacing = config.socUnitVerticalSpaceSize;
    }

    //void SwitchBirthAbility()
    //{
    //    childsConteiner.GetComponent<BirthAbility>().SwitchBirthAbility();
    //}
}
