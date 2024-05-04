using UnityEngine;
using UnityEngine.UI;

public class Childs : MonoBehaviour
{
    HorizontalLayoutGroup horizontalLayoutGroup;
    Config config;

    private void Awake()
    {
        config = FindObjectOfType<Config>();
        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
    }

    private void Update()
    {
        horizontalLayoutGroup.spacing = config.childsHorizontalSpaceSize;
    }
}
