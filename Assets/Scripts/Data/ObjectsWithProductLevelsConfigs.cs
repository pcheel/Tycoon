using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectWithProductLevelsConfigs", menuName = "Scriptable Objects/ObjectWithProductLevelsConfigs", order = 51), Serializable]
public class ObjectsWithProductLevelsConfigs : ScriptableObject
{
    public ObjectWithProductLevelsConfig freezerConfig;
    public ObjectWithProductLevelsConfig freezerStandingConfig;
    public ObjectWithProductLevelsConfig shelfAlcoConfig;
    public ObjectWithProductLevelsConfig shelfSauceConfig;
    public ObjectWithProductLevelsConfig shelfBagsConfig;
    public ObjectWithProductLevelsConfig shelfBoxesConfig;
    public ObjectWithProductLevelsConfig tableVegetablesConfig;
    public ObjectWithProductLevelsConfig tableFruitsConfig;
    public ObjectWithProductLevelsConfig displayBreadConfig;
    public ObjectWithProductLevelsConfig cashRegisterConfig;
}
