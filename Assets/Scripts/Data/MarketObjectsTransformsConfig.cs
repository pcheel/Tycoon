using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MarketObjectsTransformsConfig", menuName = "Scriptable Objects/MarketObjectsTransformsConfig", order = 51), Serializable]
public class MarketObjectsTransformsConfig : ScriptableObject
{
    public List<TransformConfig> freezers;
    public List<TransformConfig> freezersStanding;
    public List<TransformConfig> shelfAlco;
    public List<TransformConfig> shelfSauce;
    public List<TransformConfig> shelfBags;
    public List<TransformConfig> shelfBoxes;
    public List<TransformConfig> tableVegetables;
    public List<TransformConfig> tableFruits;
    public List<TransformConfig> displayBread;
    public List<TransformConfig> cashRegister;
}
