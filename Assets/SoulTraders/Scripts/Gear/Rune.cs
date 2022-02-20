using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear.Runes
{

    public interface IRune
    {
        string EffectName { get; }
        string EffectDesc { get; }
        void Effect();
    }


    // public class Rune : InventoryItem, IInventoryItem, IRune
    // {

    // }
}