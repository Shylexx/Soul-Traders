using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SoulTraders.Gameplay
{
    // This script creates a class that adds useful functionality for a Rigidbody2D Physics Object.
    // All "Characters" will extend from this as it adds a lot of features to our characters as well as a way to find all our characters
    // (As children of this class)


    public class MovableActor : MonoBehaviour
    {
        protected Rigidbody2D body;

        /// <summary>
        /// Coroutine Knocks an Enemy back
        /// </summary>
        /// <param name="duration">Duration of Knockback</param>
        /// <param name="power">Power of Knocback</param>
        /// <param name="source">Source location of knockback</param>
        public IEnumerator Knockback(float duration, float power, Vector2 source)
        {
            float timer = 0;

            while (duration > timer)
            {
                timer += Time.deltaTime;
                Vector2 direction = (source - (Vector2)this.transform.position).normalized;
                body.AddForce(-direction * power);
            }

            yield return 0;
        }


        /// <summary>
        /// Teleports entity to a position
        /// </summary>
        /// <param name="position"></param>
        public void Teleport(Vector2 position)
        {
            body.position = position;
            body.velocity *= 0;
        }

        /// <summary>
        /// Enables an entity
        /// </summary>
        protected virtual void OnEnable()
        {
            body = GetComponent<Rigidbody2D>();
        }

        protected virtual void OnDisable()
        {

        }


        protected virtual void Update()
        {

        }

        // This is called on "Physics frames" which are fixed rate and not tied to game's graphic frame rate
        protected virtual void FixedUpdate()
        {
        }

    }

}

