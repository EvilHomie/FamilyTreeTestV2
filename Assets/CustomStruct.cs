using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CustomStruct
{
    [TextArea(1, 10)]
    public string discription;
    public List<AffectedCharateristic> affectedCharateristics;
    public List<AditionAction> aditionActions;
}
