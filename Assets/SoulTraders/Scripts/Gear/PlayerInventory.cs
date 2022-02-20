using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear
{
    public class PlayerInventory
    {
        private List<InventoryItem> items;

        public PlayerInventory()
        {
            items = new List<InventoryItem>();

            Debug.Log("Inventory");
        }

    }
}