using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Generation
{
    public class DungeonManager : MonoBehaviour
    {
        public LevelData levelData;
        [HideInInspector]
        public LevelGenerator levelGenerator;

        void Start()
        {
            levelGenerator = GetComponent<LevelGenerator>();
        }

        void MakeDungeon()
        {
            //levelData = levelGenerator.GenDungeon();
        }


    }
}