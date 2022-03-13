using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Generation
{
    public enum Direction
    {
        UP, DOWN, LEFT, RIGHT
    }

    public class Walker
    {
        public Vector2 location;
        public Direction dir;

        public void SetRandomDir()
        {
            dir = (Direction)Random.Range(0, 3);
        }
    }
}