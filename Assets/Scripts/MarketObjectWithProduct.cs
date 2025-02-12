using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MarketObjectWithProduct
{
    private int _level;
    private int _productAmount;
    private int _maxProductAmount;
    private int _durationOfSelection;
    private float _productPrice;
    private string _objectID;

    public event Action<int, float> OnProductAmountChanged;
    public event Action<int> OnLevelUpped;

    public MarketObjectWithProduct(string objectID, int level)
    {
        _objectID = objectID;
        _level = level;
    }
    public void AddProduct(int amount, float durationOfAdding)
    {
        int newAmount = _productAmount + amount;
        _productAmount = newAmount < _maxProductAmount ? (newAmount + amount) : _maxProductAmount;
        OnProductAmountChanged?.Invoke(_productAmount, durationOfAdding);
    }
    public void GetProduct(int amount)
    {
        _productAmount -= amount;
        OnProductAmountChanged?.Invoke(_productAmount, _durationOfSelection);
    }
    public void LevelUp()
    {
        _level++;
        var levelData = ServiceLocator.GetService<ConfigManager>().GetObjectWithProductLevelData(_objectID, _level);
        _maxProductAmount = levelData.maxProductAmount;
        _productPrice = levelData.productPrice;
        _durationOfSelection = levelData.durationOfSelection;
        OnLevelUpped?.Invoke(_level);
    }
}
