using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    [SerializeField] private ObjectsWithProductLevelsConfigs _objectsWithProductLevelsConfigs;

    private Dictionary<MarketObjectType, ObjectWithProductLevelsConfig> _objectsWithProductLevelsConfigsDict;

    private void Awake()
    {
        CreateObjectsLevelsConfigDict();
    }
    public ObjectWithProductLevel GetObjectWithProductLevelData(MarketObjectType type, int level)
    {
        ObjectWithProductLevelsConfig objectConfig = _objectsWithProductLevelsConfigsDict[type];
        int correctLevel = --level;
        ObjectWithProductLevel levelConfig;
        if (correctLevel <= objectConfig.objectWithProductLevels.Count)
            levelConfig = objectConfig.objectWithProductLevels[correctLevel];
        else
            levelConfig = objectConfig.objectWithProductLevels[objectConfig.objectWithProductLevels.Count - 1];

        return levelConfig;
    }
    private void CreateObjectsLevelsConfigDict()
    {
        _objectsWithProductLevelsConfigsDict = new Dictionary<MarketObjectType, ObjectWithProductLevelsConfig>();
        _objectsWithProductLevelsConfigsDict.Add(MarketObjectType.Freezer, _objectsWithProductLevelsConfigs.freezerConfig);
        _objectsWithProductLevelsConfigsDict.Add(MarketObjectType.FreezerStanding, _objectsWithProductLevelsConfigs.freezerStandingConfig);
        _objectsWithProductLevelsConfigsDict.Add(MarketObjectType.ShelfAlco, _objectsWithProductLevelsConfigs.shelfAlcoConfig);
        _objectsWithProductLevelsConfigsDict.Add(MarketObjectType.ShelfSauce, _objectsWithProductLevelsConfigs.shelfSauceConfig);
        _objectsWithProductLevelsConfigsDict.Add(MarketObjectType.ShelfBags, _objectsWithProductLevelsConfigs.shelfBagsConfig);
        _objectsWithProductLevelsConfigsDict.Add(MarketObjectType.ShelfBoxes, _objectsWithProductLevelsConfigs.shelfBoxesConfig);
        _objectsWithProductLevelsConfigsDict.Add(MarketObjectType.TableVegetables, _objectsWithProductLevelsConfigs.tableVegetablesConfig);
        _objectsWithProductLevelsConfigsDict.Add(MarketObjectType.TableFruits, _objectsWithProductLevelsConfigs.tableFruitsConfig);
        _objectsWithProductLevelsConfigsDict.Add(MarketObjectType.DisplayBread, _objectsWithProductLevelsConfigs.displayBreadConfig);
    }
}
