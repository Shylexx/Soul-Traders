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

        public override string GetName()
        {
            return _runeName;
        }

        public override string GetDesc()
        {
            return _runeDesc;
        }

        public override string GetEffectName()
        {
            return _effectName;
        }

        public override string GetEffectDesc()
        {
            return _effectDesc;
        }



    }
}