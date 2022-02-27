using System.Collections;
using System.Collections.Generic;
using SoulTraders.Gameplay.Enemy;
using UnityEngine;

namespace SoulTraders.Gear.Weapons
{
    public class MeleeWeapon : Weapon
    {

        public MeleeWeaponData data;

        public override void AttackPrimary()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, data.attackRange, 1);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("Hit " + enemy.name);
                var enemyHP = enemy.GetComponentInParent<IEnemy>();
                if (enemyHP != null)
                {
                    enemyHP.TakeDamage(2);
                }
            }
        }

        public override void AttackSecondary()
        {

        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, data.attackRange);
        }
    }
}