using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulTraders.Gear.GearItems;
using SoulTraders.Gear.Weapons;

namespace SoulTraders.Gear
{
    /// <summary> Player Inventory to Store IInventoryItems
    /// Holds the items the player has as well as the gear.
    /// </summary>
    [SerializeField]
    public class PlayerInventory
    {
        [SerializeReference]
        private List<IInventoryItem> items;


        public PlayerInventory()
        {
            items = new List<IInventoryItem>();
            //Debug.Log(items[0].ItemName);
        }

        public void AddItem(IInventoryItem item)
        {
            items.Add(item);
        }

        public void PrintInventory()
        {
            Debug.Log(items[0].ItemName);
        }



    }
}