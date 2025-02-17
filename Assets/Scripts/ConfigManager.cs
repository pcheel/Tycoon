using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    [SerializeField] private MarketLevelsConfig _marketLevelsConfig;
    [SerializeField] private PrefabsConfig _prefabsConfig;
    [SerializeField] private MarketObjectsTransformsConfig _transformsConfig;

    private Dictionary<string, List<ObjectWithProductLevel>> _objectsWithProductLevelsConfigsDict;
    private Dictionary<string, GameObject> _prefabsConfigDict;
    private Dictionary<string, TransformConfig> _transformsConfigDict;
    private MarketConfig _marketConfig;

    public MarketConfig marketConfig => _marketConfig;
    public PrefabsConfig prefabsConfig => _prefabsConfig;

    private void Awake()
    {
        CreateObjectsLevelsConfigDict();
        CreatePrefabsConfigDict();
        CreateTransformConfigDict();
    }
    public void SetMarketConfig(MarketConfig config)
    {
        _marketConfig = config;
    }
    public void SetMarketConfig(DefaultMarketConfig config)
    {
        _marketConfig = new();
        _marketConfig.currentLevels = config.currentLevels;
    }
    public ObjectWithProductLevel GetObjectWithProductLevelData(string objectID, int level)
    {
        Debug.Log(objectID);
        var objectConfig = _objectsWithProductLevelsConfigsDict[objectID];
        int correctLevel = --level;
        ObjectWithProductLevel levelConfig;
        if (correctLevel <= objectConfig.Count)
            levelConfig = objectConfig[correctLevel];
        else
            levelConfig = objectConfig[objectConfig.Count - 1];

        return levelConfig;
    }
    public GameObject GetPrefab(string objectID)
    {
        return _prefabsConfigDict[objectID];
    }
    public TransformConfig GetTransformConfig(string objectID)
    {
        return _transformsConfigDict[objectID];
    }
    private void CreateObjectsLevelsConfigDict()
    {
        _objectsWithProductLevelsConfigsDict = new();
        foreach (var objectLevelConfig in _marketLevelsConfig.objectsWithProductLevels)
        {
            _objectsWithProductLevelsConfigsDict.Add(objectLevelConfig.objectID, objectLevelConfig.objectWithProductLevels);
        }
    }
    private void CreatePrefabsConfigDict()
    {
        _prefabsConfigDict = new();
        foreach(var prefabData in _prefabsConfig.prefabsDatas)
        {
            _prefabsConfigDict.Add(prefabData.objectID, prefabData.prefab);
        }
    }
    private void CreateTransformConfigDict()
    {
        _transformsConfigDict = new();
        foreach(var transformData in _transformsConfig.objectsTransforms)
        {
            _transformsConfigDict.Add(transformData.objectID, transformData);
        }
    }
}
