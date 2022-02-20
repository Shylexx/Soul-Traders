using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear.Runes
{

    [CreateAssetMenu(fileName = "Rune", menuName = "ScriptableObjects/Inventory Items/Rune", order = 1)]
    public class RuneData : ScriptableObject, IInventoryItem
    {
        public string _itemName;
        public string _itemDesc;
        public ItemType _itemType;

        public RuneEffectData _runeEffect;
    }
}

