using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gear.Weapons
{
    public interface IWeapon
    {
        void AttackPrimary();
        void AttackSecondary();
    }

    public abstract class Weapon : MonoBehaviour, IWeapon
    {

        public abstract void AttackPrimary();
        public abstract void AttackSecondary();

    }
}