using System;
using UnityEngine;
using SoulTraders.Gameplay.Player;
using SoulTraders.Controller;
using SoulTraders.Core;

namespace SoulTraders.Gear.Runes
{

    public interface IRuneEffect
    {
        public string EffectName { get; }
        public string EffectDesc { get; }
        public void Effect();
    }

    [Serializable]
    public class RuneEffectProps
    {
        public int damage;
        public Vector2 position;
        public int size;
        public string message;
    }

    public class Rune : MonoBehaviour, IInventoryItem
    {

        public RuneData runeData;

        public string ItemName
        {
            get
            {
                return runeData._itemName;
            }
        }

        public string ItemDesc
        {
            get
            {
                return runeData._itemDesc;
            }
        }

        public ItemType ItemType
        {
            get
            {
                return ItemType.RUNE;
            }
        }

        public ItemQuality ItemQuality
        {
            get
            {
                return runeData._quality;
            }
        }

        void UseEffects()
        {
            foreach (var effect in runeData.effects)
            {
                effect.Effect();
            }
        }

        void Awake()
        {
            UseEffects();
        }


    }

    // Rune Effects Go Below

    [Serializable]
    public class TestRuneEffect : IRuneEffect
    {
        [SerializeField]
        public RuneEffectProps props;
        public string EffectName
        {
            get
            {
                return "Test Rune Name";
            }
        }

        public string EffectDesc
        {
            get
            {
                return "Test Rune Desc";
            }
        }
        public void Effect()
        {
            Debug.Log("Default Message");
        }
    }

    [Serializable]
    public class SayRuneEffect : IRuneEffect
    {
        [SerializeField]
        public RuneEffectProps props;

        public string EffectName
        {
            get
            {
                return "Say Name Effect";
            }
        }
        public string EffectDesc
        {
            get
            {
                return "Say Name Desc";
            }
        }

        public void Effect()
        {
            Debug.Log(props.message);
        }
    }


}
