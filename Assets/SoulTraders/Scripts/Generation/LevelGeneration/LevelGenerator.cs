using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace SoulTraders.Generation
{
    public enum GridTile { empty, wall, floor, pillar };

    public class LevelGenerator : MonoBehaviour
    {

        public List<Walker> walkerList;

        [SerializeField]
        public LevelGenConfig config;
        public TileSetData tileSet;
        private LevelData generatedLevel;
        public Tilemap wallMap;
        GridTile[,] tempGrid;

        void Start()
        {
            SpawnDungeon();
        }

        public void GenDungeon()
        {
            Setup();
            CreateFloors();
            //CreateWalls();
            //ReplaceSingleWalls();
            generatedLevel.levelGrid = tempGrid;
            //return generatedLevel;
        }

        public void SpawnDungeon()
        {
            Setup();
            CreateFloors();
            for (int x = 0; x < config.roomWidth - 1; x++)
            {
                for (int y = 0; y < config.roomHeight - 1; y++)
                {

                    if (tempGrid[x, y] == GridTile.wall)
                    {
                        wallMap.SetTile(new Vector3Int(x, y, 0), tileSet.wallTile);
                    }
                }
            }
        }

        void Setup()
        {
            tempGrid = new GridTile[config.roomWidth, config.roomHeight];

            // Create Empty Grid
            for (int x = 0; x < config.roomWidth - 1; x++)
            {
                for (int y = 0; y < config.roomHeight - 1; y++)
                {
                    tempGrid[x, y] = GridTile.wall;
                }
            }

            // Setup walker list
            walkerList = new List<Walker>();

            Walker newWalker = new Walker();
            newWalker.RandomDir();

            newWalker.pos = config.startLocation;

            walkerList.Add(newWalker);

        }

        void CreateFloors()
        {
            int iterations = 0;
            do
            {
                //Carve out wall with walkers on
                foreach (Walker walker in walkerList)
                {
                    tempGrid[(int)walker.pos.x, (int)walker.pos.y] = GridTile.floor;
                }
                Debug.Log("carved");
                // Check if destroy walker
                int checks = walkerList.Count;
                for (int i = 0; i < checks; i++)
                {
                    if (Random.value < config.destroyChance && walkerList.Count > 1)
                    {
                        walkerList.RemoveAt(i);
                        break;
                    }
                }
                Debug.Log("checked for destroy");
                // Check if change direction
                for (int i = 0; i < walkerList.Count; i++)
                {
                    if (Random.value < config.changeDirChance)
                    {
                        walkerList[i].RandomDir();
                    }
                }
                Debug.Log("check for change dir");
                // Check if spawn new walker
                for (int i = 0; i < walkerList.Count; i++)
                {
                    if (Random.value < config.spawnChance && walkerList.Count < config.maxWalkers)
                    {
                        Walker newWalker = new Walker();
                        newWalker.RandomDir();
                        newWalker.pos = walkerList[i].pos;
                        walkerList.Add(newWalker);
                    }
                }
                Debug.Log("check for spawn new");
                // Move Walkers to new position
                for (int i = 0; i < walkerList.Count; i++)
                {
                    walkerList[i].pos += walkerList[i].dir;
                }
                Debug.Log("moved walkers");
                // Clamp Walker Position to world bounds
                for (int i = 0; i < walkerList.Count; i++)
                {
                    walkerList[i].pos.x = Mathf.Clamp(walkerList[i].pos.x, 1, config.roomWidth - 2);
                    walkerList[i].pos.y = Mathf.Clamp(walkerList[i].pos.y, 1, config.roomHeight - 2);
                }
                Debug.Log("clamped pos");
                // Check to exit loop
                if ((float)NumberOfFloors() / (float)tempGrid.Length > config.floorPercent)
                {
                    Debug.Log("exited loop");
                    break;
                }
                iterations++;
            } while (iterations < 1000000);
        }

        int NumberOfFloors()
        {
            int floorCount = 0;
            foreach (GridTile tile in tempGrid)
            {
                if (tile == GridTile.floor)
                {
                    floorCount++;
                }
            }
            return floorCount;
        }

        void CreateWalls()
        {

        }

        void ReplaceSingleWalls()
        {

        }
    }

}