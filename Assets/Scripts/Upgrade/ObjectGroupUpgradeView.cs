using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGroupUpgradeView : MonoBehaviour
{
    [SerializeField] private List<ObjectUpgradeView> _objectsUpgradeView;

    private MarketObjectType _objectsType;

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
    }
}
