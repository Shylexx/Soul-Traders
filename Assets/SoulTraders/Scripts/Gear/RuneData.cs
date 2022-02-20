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
        public ItemType _itemType = ItemType.RUNE;

        public int _weight;
        public ItemQuality _quality;

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

        public ItemQuality ItemQuality
        {
            get
            {
                return _quality;
            }
        }

        [SerializeReference, SubclassSelector] public IRuneEffect[] effects;
    }
}

