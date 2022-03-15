using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Generation
{

    public class Walker
    {
        public Vector2 pos;
        public Vector2 dir;

        public void RandomDir()
        {
            switch (Mathf.FloorToInt(Random.value * 3.99f))
            {
                case 0:
                    dir = Vector2.down;
                    break;
                case 1:
                    dir = Vector2.left;
                    break;
                case 2:
                    dir = Vector2.up;
                    break;
                case 3:
                    dir = Vector2.right;
                    break;
            }
        }
    }
}