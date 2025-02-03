using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectWithProductLevelsConfig", menuName = "Scriptable Objects/ObjectWithProductLevelsConfig", order = 51), Serializable]
public class ObjectWithProductLevelsConfig : ScriptableObject
{
    public List<ObjectWithProductLevel> objectWithProductLevels;
}
