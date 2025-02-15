using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithProductPresenter
{
    private ObjectWithProductView _view;
    private MarketObjectWithProduct _model;

    public ObjectWithProductPresenter(MarketObjectWithProduct model, ObjectWithProductView view)
    {
        _model = model;
        _view = view;

        _model.OnLevelUpped += LevelUpped;
        _model.OnProductAmountChanged += ProductAmountChanged;
        _view.OnLevelRequest += GetLevel;
    }

    public void AddProducts(int amount, float durationOfAdding)
    {
        _model.AddProduct(amount, durationOfAdding);
    }
    public void LevelUpped(int level)
    {
        _view.LevelUpped(level);
    }
    public void LevelUp()
    {

    }
    public void ProductAmountChanged(int amount, float duration)
    {
        _view.AmountChanged(amount, duration);
    }
    public void CalculateProgressCanvasCorrectRotation(Transform cameraTransform)
    {
        _view.CalculateProgressCanvasCorrectRotation(cameraTransform);
    }
    public string GetObjectID()
    {
        return _model.objectID;
    }
    public void GetLevel(Action<int> action)
    {
        action?.Invoke(_model.level);
    }
}
