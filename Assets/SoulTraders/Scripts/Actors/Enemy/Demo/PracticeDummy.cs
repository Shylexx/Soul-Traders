using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gameplay.Enemy
{
    public interface IEnemy
    {
        public void TakeDamage(int damage);
    }
    public class PracticeDummy : MonoBehaviour, IEnemy
    {

        public int health;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TakeDamage(int damage)
        {
            health = health - damage;
            CheckAlive();
        }

        void CheckAlive()
        {
            if (health <= 0)
            {
                Debug.Log("Dummy Killed");
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}