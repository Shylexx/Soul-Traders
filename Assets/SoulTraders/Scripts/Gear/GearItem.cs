using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear.GearItems
{
    public enum GearSlot
    {
        HEAD, CHEST, LEGS, FEET, WEAPON, LARGEWEAPON, ACCESSORY
    }

    public interface IGearItem
    {

        GearSlot Slot
        {
            get;
        }

        int ID
        {
            get;
        }

    }

    public class GearItem : MonoBehaviour
    {
        public GearItemData gearItem;



    }




}