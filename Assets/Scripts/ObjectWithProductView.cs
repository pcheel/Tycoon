using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectWithProductView : MonoBehaviour
{
    [SerializeField] private Image _progressCircle;
    [SerializeField] private Image _progressBackground;

    private bool _inProgress;
    private float _timeAfterFillStart;
    private float _fillDuration;
    private const float CANVAS_PADDING_UP = 0.7f;
    private const float CANVAS_PADDING_FORWARD = 3f;

    public event Action<Action<int>> OnLevelRequest;

    private void Awake()
    {

    }
    public void LevelUpped(int level)
    {

    }
    public void CalculateProgressCanvasCorrectRotation(Transform cameraTransform)
    {
        var canvasTransform = transform.GetComponentInChildren<Canvas>().transform;
        canvasTransform.rotation = cameraTransform.rotation;
        canvasTransform.localPosition = Vector3.zero;
        var position = canvasTransform.position;
        position -= canvasTransform.forward * CANVAS_PADDING_FORWARD;
        position += canvasTransform.up * CANVAS_PADDING_UP;
        canvasTransform.position = position;
    }
    public void AmountChanged(int amount, float duration)
    {
        _fillDuration = duration;
        _inProgress = true;
        _progressBackground.gameObject.SetActive(true);
    }
    public void RequestLevel(Action<int> action)
    {
        OnLevelRequest?.Invoke(action);
    }

    private void Update()
    {
        if (_inProgress)
            ShowProgress();
    }
    private void ShowProgress()
    {
        _timeAfterFillStart += Time.deltaTime;
        var progress = _timeAfterFillStart / _fillDuration;
        _progressCircle.fillAmount = progress;
        if (progress >= 1f)
        {
            _inProgress = false;
            _timeAfterFillStart = 0f;
            _fillDuration = 0f;
            _progressCircle.fillAmount = 0f;
            _progressBackground.gameObject.SetActive(false);
        }
    }
}
