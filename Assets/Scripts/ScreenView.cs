using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenView : MonoBehaviour
{
    [SerializeField] private Button _showUpgradeButton;
    [SerializeField] private Button _closeUpgradeButton;
    [SerializeField] private GameObject _upgradeWindow;

    private MarketUpgradeView _marketUpgradeView;

    private void Awake()
    {
        _marketUpgradeView = GetComponent<MarketUpgradeView>();
    }
    private void OnEnable()
    {
        _showUpgradeButton.onClick.AddListener(ShowUpgradeWindow);
        _closeUpgradeButton.onClick.AddListener(CloseUpgradeWindow);
    }
    private void OnDisable()
    {
        _showUpgradeButton.onClick.RemoveListener(ShowUpgradeWindow);
        _closeUpgradeButton.onClick.RemoveListener(CloseUpgradeWindow);
    }
    private void ShowUpgradeWindow()
    {
        _upgradeWindow.SetActive(true);
        _showUpgradeButton.gameObject.SetActive(false);
        _marketUpgradeView.ShowAllObjectViews();
    }
    private void CloseUpgradeWindow()
    {
        _upgradeWindow.SetActive(false);
        _showUpgradeButton.gameObject.SetActive(true);
    }
}
