using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabsConfig", menuName = "Scriptable Objects/PrefabsConfig", order = 51), Serializable]
public class PrefabsConfig : ScriptableObject
{
    public List<PrefabData> prefabsDatas;
}
