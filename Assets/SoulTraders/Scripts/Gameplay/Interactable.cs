using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gameplay
{
    ///<summary>Creates Logic for the player to interact with a gameobject.</summary>
    public interface IInteractable
    {
        void OnInteract();
    }
}