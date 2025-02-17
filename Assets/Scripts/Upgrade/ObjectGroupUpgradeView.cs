using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectGroupUpgradeView : MonoBehaviour
{
    [SerializeField] private List<ObjectUpgradeView> _objectsUpgradeView;
    [SerializeField] private TMP_Text _levelUpPriceText;
    [SerializeField] private TMP_Text _productPriceText;
    [SerializeField] private TMP_Text _durationText;
    [SerializeField] private TMP_Text _amountText;

    private MarketObjectType _objectsType;
    private ObjectWithProductView _selectedObject;

    public List<ObjectUpgradeView> objectsUpgradeView => _objectsUpgradeView;
    public MarketObjectType objectsType => _objectsType;

    public bool IsSameTypes(MarketObjectType type)
    {
        if (_objectsType == type)
            return true;

        return false;
    }
    public void AddObjectUpgradeToGroup(ObjectUpgradeView objectUpgradeView)
    {
        _objectsUpgradeView.Add(objectUpgradeView);
        objectUpgradeView.OnSelected += SelectObject;
    }
    public void ShowParameters(ObjectUpgradeView objectView)
    {
        var level = objectView.RequestLevel(); 
        var objectID = objectView.RequestObjectID();
        var currentLevelData = ServiceLocator.GetService<ConfigManager>().GetObjectWithProductLevelData(objectID, level);
        var nextLevelData = ServiceLocator.GetService<ConfigManager>().GetObjectWithProductLevelData(objectID, level + 1);

        if (nextLevelData != null)
        {
            SetLevelUpPriceText(nextLevelData.levelUpPrice);
            SetProductPriceText(currentLevelData.productPrice, nextLevelData.productPrice);
            SetDurationText(currentLevelData.durationOfSelection, nextLevelData.durationOfSelection);
            SetAmountText(currentLevelData.maxProductAmount, nextLevelData.maxProductAmount);
        }
        else
        {
            SetLevelUpPriceText();
            SetProductPriceText(currentLevelData.productPrice);
            SetDurationText(currentLevelData.durationOfSelection);
            SetAmountText(currentLevelData.maxProductAmount);
        }
    }
    public void SelectObject(ObjectWithProductView selectedObject)
    {
        _selectedObject = selectedObject;
    }

    private void SetLevelUpPriceText(int levelUpPrice)
    {
        _levelUpPriceText.text = levelUpPrice.ToString();
    }
    private void SetLevelUpPriceText()
    {
        _levelUpPriceText.text = "MAX";
    }
    private void SetProductPriceText(int currentPrice, int nextPrice)
    {
        var deltaPrice = nextPrice - currentPrice;
        if (deltaPrice > 0)
        {
            _productPriceText.text = $"{currentPrice} + {deltaPrice}";
            _productPriceText.color = Color.green;
        }
        else
        {
            _productPriceText.text = currentPrice.ToString();
            _productPriceText.color = Color.black;
        }
    }
    private void SetProductPriceText(int currentPrice)
    {
        _productPriceText.text = currentPrice.ToString();
        _productPriceText.color = Color.black;
    }
    private void SetDurationText(float currentDuration, float nextDuration)
    {
        var deltaDuration = currentDuration - nextDuration;
        if (deltaDuration > 0f)
        {
            _durationText.text = $"{currentDuration} - {deltaDuration}";
            _durationText.color = Color.green;
        }
        else
        {
            _durationText.text = currentDuration.ToString();
            _durationText.color = Color.black;
        }
    }
    private void SetDurationText(float currentDuration)
    {
        _durationText.text = currentDuration.ToString();
        _durationText.color = Color.black;
    }
    private void SetAmountText(int currentAmount, int nextAmount)
    {
        var deltaAmount = nextAmount - currentAmount;
        if (deltaAmount > 0)
        {
            _amountText.text = $"{currentAmount} + {deltaAmount}";
            _amountText.color = Color.green;
        }
        else
        {
            _amountText.text = currentAmount.ToString();
            _amountText.color = Color.black;
        }
    }
    private void SetAmountText(int currentAmount)
    {
        _amountText.text = currentAmount.ToString();
        _amountText.color = Color.black;
    }
}
