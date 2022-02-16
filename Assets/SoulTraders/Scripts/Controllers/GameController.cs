using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulTraders.Core;

namespace SoulTraders.Controller
{
    ///<summary>
    /// The Game Controller is a singleton object that exists in all scenes.
    /// It holds the STControl Object, with the data required to play the game
    /// It also ticks the Event System, so that events are fired when needed
    ///</summary>

    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        public STControl model = STEvents.GetModel<STControl>();


        /// <summary>
        /// This function is called when the behaviour becomes enabled or active.
        /// </summary>
        void OnEnable()
        {
            Instance = this;
        }

        /// <summary>
        /// This function is called when the behaviour becomes disabled or inactive.
        /// </summary>
        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        // Update is called once per frame
        void Update()
        {
            if (Instance == this) STEvents.Tick();
        }
    }
}
