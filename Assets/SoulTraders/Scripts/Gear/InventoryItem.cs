using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear
{
    public enum ItemType
    {
        GEAR, CONSUMABLE, RUNE, MISC, NOTYPE
    }

    public enum ItemQuality
    {
        COMMON, UNCOMMON, RARE, EPIC, LEGENDARY
    }

    public interface IInventoryItem
    {
        public string ItemName { get; }
        public string ItemDesc { get; }
        public ItemType ItemType { get; }

        public ItemQuality ItemQuality { get; }

    }

    public class InventoryItem : MonoBehaviour, IInventoryItem
    {
        public InventoryItemData itemData;

        public string _itemName;
        public string _itemDesc;
        public ItemType _itemType;
        public ItemQuality _itemQuality;

        public string ItemName
        {
            get
            {
                return _itemName;
            }
        }

        public string ItemDesc
        {
            get
            {
                return _itemDesc;
            }

        }

        public ItemType ItemType
        {
            get
            {
                return _itemType;
            }
        }

        public ItemQuality ItemQuality
        {
            get
            {
                return _itemQuality;
            }
        }


    }
}