using System.Collections;
using System.Collections.Generic;
using SoulTraders.Gameplay.Player;
using UnityEngine;

namespace SoulTraders.Gear
{
    public class ItemPickup : MonoBehaviour
    {

        public InventoryItemData Pickup;
        public Collider2D collider2d;

        void Awake()
        {
            collider2d = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponentInParent<PlayerController>();
            if (player != null)
            {
                player.inventory.AddItem(Pickup);
                player.inventory.PrintInventory();
                Destroy(this.gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}