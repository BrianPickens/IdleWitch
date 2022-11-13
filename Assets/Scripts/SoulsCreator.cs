using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsCreator : MonoBehaviour
{
    [SerializeField] private FlyingSoul soulPrefab;
    [SerializeField] private float xVariance;
    [SerializeField] private float yVariance;
    private void CreateSouls(Vector2 _startPosition, Vector2 _endPosition, int _numSouls)
    {
        StartCoroutine(CreateSoulsRoutine(_startPosition, _endPosition, _numSouls));
    }

    private IEnumerator CreateSoulsRoutine(Vector2 _startPosition, Vector2 _endPosition, int _numSouls)
    {
       // for (int i = 0; i < _numSouls; i++)
        //{
          //  FlyingSoul newSoul = Instantiate(soulPrefab, _startPosition, Quaternion.identity, this.transform).GetComponent<FlyingSoul>();



      //      newSoul.InitializeSoul(_startPosition, , _endPosition);
            yield return new WaitForSeconds(0.25f);
      //  }
    }

}
