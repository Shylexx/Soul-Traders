using System.Collections;
using System.Collections.Generic;
using SoulTraders.Core;
using SoulTraders.Controller;
using UnityEngine;

namespace SoulTraders.Gameplay.Player
{
    public class PlayerDeathEvent : STEvents.STEvent<PlayerDeathEvent>
    {
        STControl model = STEvents.GetModel<STControl>();

        public override void Execute()
        {
            var playerController = model.playerController;
            playerController.controlEnabled = false;

        }
    }
}