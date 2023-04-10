using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoulsCreator : MonoBehaviour
{
    [SerializeField] private FlyingSoul soulPrefab;
    [SerializeField] private float xVariance;
    [SerializeField] private float yVariance;
    [SerializeField] private float createDelay;

    public void CreateSouls(Vector2 _startPosition, Vector2 _endPosition, int _numSouls, Action _callback)
    {
        StartCoroutine(CreateSoulsRoutine(_startPosition, _endPosition, _numSouls, _callback));
    }

    private IEnumerator CreateSoulsRoutine(Vector2 _startPosition, Vector2 _endPosition, int _numSouls, Action _callback)
    {
        for (int i = 0; i < _numSouls; i++)
        {
            FlyingSoul newSoul = Instantiate(soulPrefab, _startPosition, Quaternion.identity, this.transform).GetComponent<FlyingSoul>();

            Vector2 newMidPoint = new Vector2(UnityEngine.Random.Range(_startPosition.x, _endPosition.x) + UnityEngine.Random.Range(-xVariance, xVariance),
                UnityEngine.Random.Range(_startPosition.y, _endPosition.y) + UnityEngine.Random.Range(-yVariance, yVariance));

            newSoul.InitializeSoul(_startPosition, newMidPoint, _endPosition, _callback);
            yield return new WaitForSeconds(createDelay);
        }
    }

}
