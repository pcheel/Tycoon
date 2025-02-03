using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectWithProductView : MonoBehaviour
{
    [SerializeField] private Image _progressCircle;
    [SerializeField] private Image _progressBackground;

    private bool _inProgress;
    private float _timeAfterFillStart;
    private float _fillDuration;

    public void LevelUpped(int level)
    {

    }
    public void GettingProductStarted(float duration)
    {
        _fillDuration = duration;
        _inProgress = true;
        _progressBackground.gameObject.SetActive(true);
    }
    public void AddingProductStarted(float duration)
    {
        _fillDuration = duration;
        _inProgress = true;
        _progressBackground.gameObject.SetActive(true);
    }
    public void AmountChanged(int amount)
    {
        Debug.Log("success");
    }

    private void Update()
    {
        if (_inProgress)
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
}
