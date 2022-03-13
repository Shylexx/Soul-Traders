using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Generation
{
    public class LevelGenerator : MonoBehaviour
    {

        public List<Walker> walkerList;
        [SerializeField]
        public LevelGenConfig config;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void CreateFloors()
        {
            int iterations = 0;
            do
            {
                //Carve out wall with walkers on
                foreach (Walker i in walkerList)
                {

                }
                // Check if destroy walker
                foreach (Walker i in walkerList)
                {

                }
                // Check if change direction
                foreach (Walker i in walkerList)
                {

                }
                // Check if spawn new walker
                foreach (Walker i in walkerList)
                {

                }
                // Move Walkers to new position
                foreach (Walker i in walkerList)
                {

                }

                // Clamp Walker Position to world bounds
                foreach (Walker i in walkerList)
                {

                }

                // Check to exit loop


            } while (iterations < 1000000);
        }
    }

}