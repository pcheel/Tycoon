using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketUpgradeView : MonoBehaviour
{
    private List<ObjectGroupUpgradeView> _objectGroupsUpgradeViews;

    public List<ObjectGroupUpgradeView> objectGroupsUpgradeViews => _objectGroupsUpgradeViews;

    public void ShowAllObjectViews()
    {
        foreach(var objectGroupUpgradeView in _objectGroupsUpgradeViews)
        {
            objectGroupUpgradeView.ShowParameters(objectGroupUpgradeView.objectsUpgradeView[0]);
        }
    }
    private void Awake()
    {
        _objectGroupsUpgradeViews = new();
    }
}
