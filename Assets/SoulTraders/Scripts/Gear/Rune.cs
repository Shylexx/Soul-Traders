using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear.Runes
{
    public abstract class Rune : MonoBehaviour, IInventoryItem
    {

        public ItemType type
        {
            get
            {
                return ItemType.RUNE;
            }
        }

        public abstract string GetName();

        public abstract string GetDesc();

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public abstract string GetEffectName();
        public abstract string GetEffectDesc();
        public abstract void Effect();
    }
}