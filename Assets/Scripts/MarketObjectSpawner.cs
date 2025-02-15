using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MarketObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private Transform _upgradeGroupParent;
    [SerializeField] private Transform _cameraTransform;

    private List<ObjectWithProductView> _objectsViews;
    private List<ObjectWithProductPresenter> _objectsPresenters;
    private List<ObjectGroupUpgradeView> _objectsGroupsUpgradeViews;

    private const string OBJECTS_GROUP_UPGRADE_ID = "objects_group_upgrade";
    private const string OBJECT_UPGRADE_ID = "object_upgrade";

    public void SpawnMarket()
    {
        var configManager = ServiceLocator.GetService<ConfigManager>();
        var marketConfig = configManager.marketConfig;
        foreach (var currentLevel in marketConfig.currentLevels)
        {
            if (currentLevel.currentLevel == 0)
                continue;

            var objectView = CreateMarketObjectView(currentLevel, configManager);
            _objectsViews.Add(objectView);
            var objectModel = new MarketObjectWithProduct(currentLevel.objectID, currentLevel.currentLevel, currentLevel.objectType);
            var objectPresenter = new ObjectWithProductPresenter(objectModel, objectView);
            _objectsPresenters.Add(objectPresenter);
            objectPresenter.CalculateProgressCanvasCorrectRotation(_cameraTransform);

            CreateObjectUpgradeGroupsViews(currentLevel, configManager, objectView);
        }

        
    }

    private void Awake()
    {
        _objectsViews = new();
        _objectsPresenters = new();
        _objectsGroupsUpgradeViews = new();
    }
    private ObjectWithProductView CreateMarketObjectView(CurrentLevel currentLevel, ConfigManager configManager)
    {
        var prefab = configManager.GetPrefab(currentLevel.objectID);
        var transformData = configManager.GetTransformConfig(currentLevel.objectID);
        var quaternion = Quaternion.Euler(transformData.rotation);
        var marketObject = Instantiate(prefab, transformData.position, quaternion, _parentTransform);
        marketObject.transform.localScale = transformData.scale;
        var objectView = marketObject.GetComponent<ObjectWithProductView>();
        return objectView;
    }
    private void CreateObjectUpgradeGroupsViews(CurrentLevel currentLevel, ConfigManager configManager, ObjectWithProductView objectView)
    {
        foreach (var objectsGroupUpgradeView in _objectsGroupsUpgradeViews)
        {
            if (!objectsGroupUpgradeView.IsSameTypes(currentLevel.objectType))
                continue;

            CreateObjectUpgradeView(configManager, objectsGroupUpgradeView, objectView);
            return;
        }

        var objectUpgradeGroup = CreateObjectsUpgradeGroupViews(configManager);
        _objectsGroupsUpgradeViews.Add(objectUpgradeGroup);
        CreateObjectUpgradeView(configManager, objectUpgradeGroup, objectView);
    }
    private ObjectGroupUpgradeView CreateObjectsUpgradeGroupViews(ConfigManager configManager)
    {
        var prefab = configManager.GetPrefab(OBJECTS_GROUP_UPGRADE_ID);
        var gameObject = Instantiate(prefab, _upgradeGroupParent);
        return gameObject.GetComponent<ObjectGroupUpgradeView>();
    }
    private void CreateObjectUpgradeView(ConfigManager configManager, ObjectGroupUpgradeView objectGroupUpgradeView, ObjectWithProductView objectView)
    {
        var prefab = configManager.GetPrefab(OBJECT_UPGRADE_ID);
        var parent = objectGroupUpgradeView.transform.GetComponentInChildren<GridLayoutGroup>().transform;
        var gameObject = Instantiate(prefab, parent);
        var objectUpgradeView = gameObject.GetComponent<ObjectUpgradeView>();
        objectGroupUpgradeView.AddObjectUpgradeToGroup(objectUpgradeView);
        objectUpgradeView.Init(objectView);
    }
}
