using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear.GearItems
{
    [CreateAssetMenu(fileName = "Gear Item", menuName = "ScriptableObjects/Inventory Items/Gear Item", order = 1)]
    public class GearItemData : ScriptableObject, IInventoryItem, IGearItem
    {
        public string _itemName;
        public string _itemDesc;
        public ItemType _itemType;
        public GearSlot _slot;
        public int _id;

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
                return ItemType.MISC;
            }
        }

        public GearSlot Slot
        {
            get
            {
                return _slot;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }
    }
}
