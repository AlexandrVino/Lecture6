using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCoinCreator : MonoBehaviour
{

    [SerializeField] private FlyingCoin _flyingCoinPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _target;
    [SerializeField] private Resources _resources;

    private void OnEnable()
    {
        _resources.OnCollectCoins += CreateFlyingCoin;
    }

    private void OnDisable()
    {
        _resources.OnCollectCoins -= CreateFlyingCoin;
    }

    public void CreateFlyingCoin(Vector3 worldPosition) {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        FlyingCoin newFlyingCoin = Instantiate(_flyingCoinPrefab, screenPosition, Quaternion.identity, _parent);
        newFlyingCoin.MoveTo(_target.position);
    }

}
