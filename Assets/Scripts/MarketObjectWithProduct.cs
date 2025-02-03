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
    private MarketObjectType _type;

    public event Action<int> OnProductAmountChanged;
    public event Action<int> OnAddingProductStarted;
    public event Action<int> OnGettingProductStarted;
    public event Action<int> OnLevelUpped;

    public MarketObjectWithProduct(MarketObjectType type, int level)
    {
        _type = type;
        _level = level;
    }
    public async void AddProduct(int amount, int durationOfAdding)
    {
        OnAddingProductStarted?.Invoke(durationOfAdding);
        await AddProductAsync(amount, durationOfAdding);
    }
    public async void GetProduct(int amount)
    {
        OnGettingProductStarted?.Invoke(_durationOfSelection);
        await GetProductAsync(amount, _durationOfSelection);
    }
    public void LevelUp()
    {
        _level++;
        var levelData = ServiceLocator.GetService<ConfigManager>().GetObjectWithProductLevelData(_type, _level);
        _maxProductAmount = levelData.maxProductAmount;
        _productPrice = levelData.productPrice;
        _durationOfSelection = levelData.durationOfSelection;
        OnLevelUpped?.Invoke(_level);
    }

    private async Task AddProductAsync(int amount, int durationOfSelection)
    {
        await Task.Delay(durationOfSelection);
        Debug.Log("startAdding");
        //int newAmount = _productAmount + amount;
        //_productAmount = newAmount < _maxProductAmount ? (newAmount + amount) : _maxProductAmount;
        OnProductAmountChanged?.Invoke(_productAmount);
    }
    private async Task GetProductAsync(int amount, int durationOfGetting)
    {
        await Task.Delay(durationOfGetting);
        _productAmount -= amount;
        OnProductAmountChanged?.Invoke(_productAmount);
    }
}
