using System.Collections.Generic;
using UnityEngine;

public class ConnectionLine : MonoBehaviour
{
    TreeConfig config;

    RectTransform parents;
    RectTransform children;
    LineRenderer lineRenderer;

    Vector2 startPos;
    Vector2 roundingOnStartPos;

    Vector2 endPos;
    Vector2 roundingOnEndPos;

    Vector2 middlePos;

    private void Awake()
    {
        config = FindObjectOfType<TreeConfig>();
        lineRenderer = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        if(parents == null || children == null) return;

        if (config.vertexCount <= 0) config.vertexCount = 1;

        startPos = parents.transform.position;
        endPos = children.transform.position;
        middlePos = (startPos + endPos) / 2;

        roundingOnStartPos = startPos - config.offsetForRoundingPoints;
        roundingOnEndPos = endPos + config.offsetForRoundingPoints;

        //lineRenderer.SetPosition(0, startPos);
        //lineRenderer.SetPosition(1, roundingOnStartPos);
        //lineRenderer.SetPosition(2, middlePos);
        //lineRenderer.SetPosition(3, roundingOnEndPos);
        //lineRenderer.SetPosition(4, endPos);

        var pointList = new List<Vector3>();

        for (float ratio = 0; ratio <= 1; ratio += 1f / config.vertexCount)
        {
            var Lerp1 = Vector2.Lerp(startPos, roundingOnStartPos, ratio);
            var Lerp2 = Vector2.Lerp(roundingOnStartPos, middlePos, ratio);
            var curvePoint = Vector2.Lerp(Lerp1, Lerp2, ratio);
            pointList.Add(curvePoint);
        }

        for (float ratio = 0; ratio <= 1; ratio += 1f / config.vertexCount)
        {
            var Lerp1 = Vector2.Lerp(middlePos, roundingOnEndPos, ratio);
            var Lerp2 = Vector2.Lerp(roundingOnEndPos, endPos, ratio);
            var curvePoint = Vector2.Lerp(Lerp1, Lerp2, ratio);
            pointList.Add(curvePoint);
        }


        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPositions(pointList.ToArray());





        //startPos = new(parents.localPosition.x, parents.localPosition.y - parents.rect.height / 2);
        //roundingOnStartPos = startPos - offsetForRoundingPoints;

        //endPos = new()
    }


    public void SetUpCurve(GameObject targetParents, GameObject targetChild)
    {
        parents = targetParents.GetComponent<RectTransform>();
        children = targetChild.GetComponent<RectTransform>();
    }


    //private Vector3 Bezier(float t)
    //{
    //    float mt = 1 - t;
    //    float x = mt * mt * mt * bezierPoints[0].x + 3 * mt * mt * t * bezierPoints[1].x + 3 * mt * t * t * bezierPoints[2].x + t * t * t * bezierPoints[3].x;
    //    float y = mt * mt * mt * bezierPoints[0].y + 3 * mt * mt * t * bezierPoints[1].y + 3 * mt * t * t * bezierPoints[2].y + t * t * t * bezierPoints[3].y;
    //    float z = mt * mt * mt * bezierPoints[0].z + 3 * mt * mt * t * bezierPoints[1].z + 3 * mt * t * t * bezierPoints[2].z + t * t * t * bezierPoints[3].z;
    //    return new Vector3(x, y, z);
    //    //}
    //}
}
