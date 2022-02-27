using System.Collections;
using System.Collections.Generic;
using SoulTraders.Gear;
using SoulTraders.Gear.GearItems;
using UnityEngine;

namespace SoulTraders.Gear.Weapons
{
    [CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObjects/Gear/Melee Weapon Data", order = 1)]
    public class MeleeWeaponData : ScriptableObject, IInventoryItem, IGearItem
    {
        public float attackRange;
        public float attackDmg;
        public float attackSpeed;
        public string itemName;
        public string itemDesc;
        public ItemQuality quality;
        public ItemType type;
        public GearSlot gearSlot;

        public string ItemName
        {
            get
            {
                return itemName;
            }
        }

        public string ItemDesc
        {
            get
            {
                return itemDesc;
            }
        }

        public ItemType ItemType
        {
            get
            {
                return type;
            }
        }

        public ItemQuality ItemQuality
        {
            get
            {
                return quality;
            }
        }

        public GearSlot Slot
        {
            get
            {
                return gearSlot;
            }
        }

    }
}