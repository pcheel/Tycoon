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

    private void Awake()
    {

    }
    public void LevelUpped(int level)
    {

    }
    public void CalculateProgressCanvasCorrectRotation(Transform cameraTransform)
    {
        transform.GetComponentInChildren<Canvas>().transform.rotation = cameraTransform.rotation;
    }
    public void AmountChanged(int amount, float duration)
    {
        _fillDuration = duration;
        _inProgress = true;
        _progressBackground.gameObject.SetActive(true);
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
