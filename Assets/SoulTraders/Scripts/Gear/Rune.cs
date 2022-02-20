using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear.Runes
{

    public interface IRuneEffect
    {
        string EffectName { get; }
        string EffectDesc { get; }
        void Effect();
    }
    public abstract class Rune : InventoryItem, IRuneEffect
    {

        public override abstract string ItemName { get; }
        public override abstract string ItemDesc { get; }

        public override ItemType ItemType
        {
            get
            {
                return ItemType.RUNE;
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public abstract string EffectName { get; }

        public abstract string EffectDesc { get; }
        public abstract void Effect();
    }
}