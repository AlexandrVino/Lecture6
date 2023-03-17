using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICounter : MonoBehaviour
{

    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private TextMeshProUGUI _text;
    // Время, в течении которого проходит анимация
    [SerializeField] private float _animationTime;
    [SerializeField] private Resources _resources;

    public void Display()
    {
        StartCoroutine(ScaleAnimation());
    }

    // Колебание масштаба счетчика
    private IEnumerator ScaleAnimation()
    {
        _text.text = _resources.Coins.ToString();
        for (float t = 0; t < 1f; t += Time.deltaTime / _animationTime)
        {
            transform.localScale = Vector3.one * _scaleCurve.Evaluate(t);
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

}
