using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulTraders.Gear.GearItems;

namespace SoulTraders.Gear
{
    public class PlayerInventory
    {
        private List<IInventoryItem> items;
        public InventoryItem testItem;

        public PlayerInventory()
        {
            items = new List<IInventoryItem>();
            //Debug.Log(items[0].ItemName);
        }

        public void AddItem(IInventoryItem item)
        {
            items.Add(item);
        }



    }
}