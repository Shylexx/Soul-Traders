using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Generation
{
    [CreateAssetMenu(fileName = "Level Data", menuName = "ScriptableObjects/Generation/Level Data", order = 0)]
    public class LevelData : ScriptableObject
    {
        public GridTile[,] levelGrid;
    }
}