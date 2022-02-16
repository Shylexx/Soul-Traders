using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SoulTraders.Gameplay
{
    // This script creates a class that handles all the necessary logic for a Rigidbody2D Physics Object.
    // All "Characters" will extend from this as it handles movement around the world

    public class KinematicObject : MonoBehaviour
    {

        /// <summary>
        /// The velocity of the entity
        /// </summary>
        public Vector2 velocity;



        protected Vector2 targetVelocity;
        protected Rigidbody2D body;
        protected const float minMoveDistance = 0.001f;

        /// <summary>
        /// Bounce The object's velocity in a direction
        /// </summary>
        /// <param name="dir"></param>
        public void Bounce(Vector2 dir)
        {
            velocity.x = dir.x;
            velocity.y = dir.y;
        }


        /// <summary>
        /// Teleports entity to a position
        /// </summary>
        /// <param name="position"></param>
        public void Teleport(Vector3 position)
        {
            body.position = position;
            velocity *= 0;
            body.velocity *= 0;
        }

        /// <summary>
        /// Enables an entity
        /// </summary>
        protected virtual void OnEnable()
        {
            body = GetComponent<Rigidbody2D>();
            body.isKinematic = true;
        }

        protected virtual void OnDisable()
        {
            body.isKinematic = false;
        }


        protected virtual void Update()
        {
            targetVelocity = Vector2.zero;
            CalcVelocity();
        }

        // Virtual Function for overriding
        protected virtual void CalcVelocity()
        {

        }

        // This is called on "Physics frames" which are fixed rate and not tied to game's graphic frame rate
        protected virtual void FixedUpdate()
        {
            // Set Body Velocity based on targetVelocity
            velocity.x = targetVelocity.x;
            velocity.y = targetVelocity.y;

            MoveEntity(velocity);
        }

        void MoveEntity(Vector2 velocity)
        {

            body.position = body.position + velocity;

        }
    }

}

