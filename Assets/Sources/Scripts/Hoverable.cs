using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverable : MonoBehaviour
{
    private Transform _parent;
    private Resources _resources;
    [SerializeField] private HitEffect _hitEffectPrefab;

    private int _coinsPerClick = 1;

    public void Init(Transform parent, Resources resources)
    {
        _parent = parent;
        _resources = resources;
    }

    public void Hit()
    {
        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

        HitEffect hitEffect = Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity, _parent);
        hitEffect.Init(_coinsPerClick);

        _resources.CollectCoins(1, transform.position);
        Destroy(gameObject);
    }

    // Этот метод увеличивает количество монет, получаемой при клике
    public void AddCoinsPerClick(int value) => _coinsPerClick += value;

    public void Move(Vector3 force)
    {
        Debug.Log(force);
        GetComponent<Rigidbody>().AddForce(force);
    }
}
