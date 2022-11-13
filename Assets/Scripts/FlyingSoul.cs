using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSoul : MonoBehaviour
{
    [SerializeField] private Transform myTransform;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 midPoint;
    [SerializeField] private Vector2 endPosition;

    [SerializeField] private float moveTime;

    private float t;

    public void InitializeSoul(Vector2 _startPos, Vector2 _midPoint, Vector2 _endPos)
    {
        startPosition = _startPos;
        midPoint = _midPoint;
        endPosition = _endPos;
    }

    private void Update()
    {
        if (t <= 1)
        {
            t += Time.deltaTime / moveTime;
            Vector2 lerp1 = Vector2.Lerp(startPosition, midPoint, t);
            Vector2 lerp2 = Vector2.Lerp(midPoint, endPosition, t);
            Vector2 lerp3 = Vector2.Lerp(lerp1, lerp2, t);
            myTransform.position = lerp3;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
