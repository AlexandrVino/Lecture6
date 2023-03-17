using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCoin : MonoBehaviour
{

    [SerializeField] private AnimationCurve _moveCurve;

    public void MoveTo(Vector3 targetPosition)
    {
        StartCoroutine(MoveToPoint(transform.position, targetPosition));
    }

    // Перемещение монеты из точки a в b за 1 секунду
    private IEnumerator MoveToPoint(Vector3 a, Vector3 b)
    {
        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            float x = Mathf.Lerp(a.x, b.x, t);

            float yInterpolant = _moveCurve.Evaluate(t);
            float y = Mathf.LerpUnclamped(a.y, b.y, yInterpolant);

            Vector3 position = new Vector3(x, y, 0f);
            transform.position = position;
            yield return null;
        }
        Destroy(gameObject);
    }

}
