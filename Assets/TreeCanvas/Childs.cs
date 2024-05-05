using UnityEngine;
using UnityEngine.UI;

public class Childs : MonoBehaviour
{
    HorizontalLayoutGroup horizontalLayoutGroup;
    TreeConfig config;

    private void Awake()
    {
        config = FindObjectOfType<TreeConfig>();
        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
    }

    private void Update()
    {
        horizontalLayoutGroup.spacing = config.childsHorizontalSpaceSize;
    }
}
