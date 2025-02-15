using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MarketLevelsConfig", menuName = "Scriptable Objects/MarketLevelsConfig", order = 51), Serializable]
public class MarketLevelsConfig : ScriptableObject
{
    public List<ObjectWithProductLevelsConfig> objectsWithProductLevels;
}
