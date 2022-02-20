using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear
{
    [CreateAssetMenu(fileName = "Inventory Item", menuName = "ScriptableObjects/Inventory Items/Inventory Item", order = 1)]
    public class InventoryItemData : ScriptableObject, IInventoryItem
    {
        public string _itemName;
        public string _itemDesc;
        public ItemType _itemType;

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
    }
}
