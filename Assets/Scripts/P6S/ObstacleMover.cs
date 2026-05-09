using UnityEngine;
using System;

public class ObstacleMover : MonoBehaviour
{
    private float _fallSpeed;
    private float _bottomY;
    private bool _isUI;
    private Action _onDestroyCallback;
    private RectTransform _rectTransform;

    public void Init(float speed, float killY, bool isUI, Action onDestory)
    {
        _fallSpeed = speed;
        _bottomY = killY;
        _isUI = isUI;
        _onDestroyCallback = onDestory;
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float step = _fallSpeed * Time.deltaTime;

        if (_isUI && _rectTransform != null)
        {
            Vector2 pos = _rectTransform.anchoredPosition;
            pos.y -= step;
            _rectTransform.anchoredPosition = pos;

            if (pos.y <= _bottomY) DestroySelf();
        }
        else
        {
            transform.Translate(Vector3.down * step, Space.World);

            // ¬ мировых координатах провер€ем глобальный Y
            if (transform.position.y <= _bottomY) DestroySelf();
        }
    }

    private void DestroySelf()
    {
        _onDestroyCallback?.Invoke();
        Destroy(gameObject);
    }
}