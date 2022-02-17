using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulTraders.Gameplay.Player;

namespace SoulTraders.Controller
{

    ///<summary>
    /// This Model Holds data about the game scene.
    /// It should only hold data and methods that operate on the data
    /// It is set up and held inside the GameController
    ///</summary>
    [System.Serializable]
    public class STControl
    {

        public CameraController cameraController;

        public PlayerController playerController;

        public Transform spawnPoint;



    }
}