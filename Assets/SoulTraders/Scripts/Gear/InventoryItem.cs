using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear
{
    public enum ItemType
    {
        GEAR, CONSUMABLE, RUNE, MISC, NOTYPE
    }

    public abstract class InventoryItem : MonoBehaviour
    {
        public abstract string ItemName { get; }
        public abstract string ItemDesc { get; }
        public abstract ItemType ItemType { get; }

    }
}