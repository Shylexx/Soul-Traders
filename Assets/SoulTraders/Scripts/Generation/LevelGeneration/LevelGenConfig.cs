using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SoulTraders.Generation
{

    [CreateAssetMenu(fileName = "Level Generator Config", menuName = "ScriptableObjects/Generation/Level Generator Config", order = 0)]
    public class LevelGenConfig : ScriptableObject
    {
        public int maxWalkers;
        public double changeDirChance;
        public double destroyChance;
        public double spawnChance;
        public int roomHeight;
        public int roomWidth;
        public Vector2 startLocation;
        public double floorPercent;
        public float gridSize;

    }

}