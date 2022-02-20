using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulTraders.Gear;
using SoulTraders.Gear.GearItems;

namespace SoulTraders.Gameplay.Player
{
    public class PlayerGear
    {
        private List<GearItemData> gear;



        public PlayerGear()
        {
            gear = new List<GearItemData>();
            //Debug.Log(items[0].ItemName);
        }

        public void Equip(GearItemData item)
        {
            gear.Add(item);
        }

        public void PrintGear()
        {
            Debug.Log(gear[0].ItemName);
        }



    }
}