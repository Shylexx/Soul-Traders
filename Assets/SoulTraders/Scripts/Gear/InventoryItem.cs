using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear
{
    public enum ItemType
    {
        GEAR, CONSUMABLE, RUNE, MISC, NOTYPE
    }

    public interface IInventoryItem
    {
        public string ItemName { get; }
        public string ItemDesc { get; }
        public ItemType ItemType { get; }

    }

    public class InventoryItem : MonoBehaviour
    {
        public InventoryItemData itemData;
    }


}