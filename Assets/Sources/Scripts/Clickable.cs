using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Clickable : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private Resources _resources;
    [SerializeField] private int _forceValue = 5;
    [SerializeField] private float _scaleTime = 0.25f;
    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private Hoverable _hoverableEffectPrefab;

    private int _coinsPerClick = 1;

    // Метод вызывается из Interaction при клике на объект
    public void Hit()
    {
        StartCoroutine(HitAnimation());
        for (int i = 0; i < Random.Range(3, 7); i++)
        {
            Hoverable hoverableEffect = Instantiate(
                _hoverableEffectPrefab, 
                transform.position + Vector3.up,
                Quaternion.identity
            );
            hoverableEffect.Init(_parent, _resources);
            hoverableEffect.Move(GetRandomDirection() * _forceValue);
        }

    }

    private Vector3 GetRandomDirection()
    {
        return new Vector3(
            Random.Range(-0.5f, 0.5f), 
            Random.Range(0.0f, 1.0f), 
            Random.Range(-0.5f, 0.5f)
        );
    }

    // Анимация колебания куба
    private IEnumerator HitAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _scaleTime)
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

    // Этот метод увеличивает количество монет, получаемой при клике
    public void AddCoinsPerClick(int value) => _coinsPerClick += value;

}
