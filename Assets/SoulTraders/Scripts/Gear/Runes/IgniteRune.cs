using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear.Runes
{
    public class IgniteRune : Rune
    {

        // Update is called once per frame
        void Update()
        {

        }

        ///<summary>The Effect to be fired when the rune's activation condition is met</summary>
        public override void Effect()
        {
            Debug.Log("Ignite Effect");
        }

        private string _runeName = "Ignite Rune";
        private string _runeDesc = "Soul of a Flame Atronach";
        private string _effectName = "Ignition";
        private string _effectDesc = "Sets Enemies Aflame";

        public override string ItemName
        {
            get
            {
                return _runeName;
            }
        }

        public override string ItemDesc
        {
            get
            {
                return _runeDesc;
            }
        }

        public override string EffectName
        {
            get
            {
                return _effectName;
            }
        }

        public override string EffectDesc
        {
            get
            {
                return _effectDesc;
            }
        }



    }
}