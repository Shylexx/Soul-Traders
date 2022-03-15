using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace SoulTraders.Generation
{
    [CreateAssetMenu(fileName = "Tile Set", menuName = "ScriptableObjects/Generation/Tile Set", order = 0)]
    public class TileSetData : ScriptableObject
    {
        public TileBase floorTile;
        public TileBase wallTile;
    }
}