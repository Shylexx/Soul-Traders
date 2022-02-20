using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear
{
    public enum ItemType
    {
        GEAR, CONSUMABLE, RUNE, MISC
    }
    public interface IInventoryItem
    {
        string GetName();

        string GetDesc();

        ItemType type
        {
            get;
        }
    }
}