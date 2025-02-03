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
        _model.OnGettingProductStarted += GettingProductStarted;
        _model.OnAddingProductStarted += AddingProductStarted;
        _model.OnProductAmountChanged += ProductAmountChanged;
    }

    public void LevelUpped(int level)
    {
        _view.LevelUpped(level);
    }
    public void LevelUp()
    {

    }
    public void GettingProductStarted(int duration)
    {
        var newDuration = (float)duration;
        newDuration /= 1000f;
        _view.GettingProductStarted(newDuration);
    }
    public void AddingProductStarted(int duration)
    {
        var newDuration = (float)duration;
        newDuration /= 1000f;
        _view.AddingProductStarted(newDuration);
    }
    public void ProductAmountChanged(int amount)
    {
        _view.AmountChanged(amount);
    }
}
