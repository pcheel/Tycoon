using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ObjectUpgradeView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text _levelText;

    private ObjectWithProductView _objectView;
    private int _level;

    public event Action<ObjectWithProductView> OnSelected;

    public void Init(ObjectWithProductView objectWithProductView)
    {
        _objectView = objectWithProductView;

        _level = RequestLevel();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelected?.Invoke(_objectView);
    }
    private int RequestLevel()
    {
        int level = 0;
        Action<int> action = (int x) => level = x;
        _objectView.RequestLevel(action);
        _levelText.text = level.ToString();
        return level;
    }
}
