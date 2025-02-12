using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MarketObjectsTransformsConfig", menuName = "Scriptable Objects/MarketObjectsTransformsConfig", order = 51), Serializable]
public class MarketObjectsTransformsConfig : ScriptableObject
{
    public List<TransformConfig> objectsTransforms;
}
