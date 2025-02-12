using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MarketConfig", menuName = "Scriptable Objects/MarketConfig", order = 51), Serializable]
public class DefaultMarketConfig : ScriptableObject
{
    //public List<int> freezersLevels;
    //public List<int> freezersStandingLevels;
    //public List<int> shelfAlcoLevels;
    //public List<int> shelfSauceLevels;
    //public List<int> shelfBagsLevels;
    //public List<int> shelfBoxesLevels;
    //public List<int> tableVegetablesLevels;
    //public List<int> tableFruitsLevels;
    //public List<int> displayBreadLevels;
    //public List<int> cashRegisterLevels;
    public List<CurrentLevel> currentLevels;
}
