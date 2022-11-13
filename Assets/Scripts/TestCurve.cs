using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCurve : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform middle;
    [SerializeField] private Transform end;

    [SerializeField] private Transform movingObject;

    [SerializeField] private float moveTime;

    [SerializeField] private GameObject movingObjectPrefab;

    private float t;

    private void Update()
    {

        if (t <= 1)
        {
            t += Time.deltaTime / moveTime;
            Vector2 lerp1 = Vector2.Lerp(start.position, middle.position, t);
            Vector2 lerp2 = Vector2.Lerp(middle.position, end.position, t);
            Vector2 lerp3 = Vector2.Lerp(lerp1, lerp2, t);
            movingObject.transform.position = lerp3;
        }
        else
        {
            t = 0;
        }

    }

}
