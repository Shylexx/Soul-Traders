using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulTraders.Gameplay.Player
{

    public class PlayerController : KinematicObject
    {

        // Component References
        public SpriteRenderer spriteRenderer;
        public AudioSource audioSource;
        public Collider2D playerCollider;
        public Animator animator;

        public bool controlEnabled = true;

        //Movement
        Vector2 move;

        /// <summary>
        /// The maximum Speed the object can move with
        /// </summary>
        public float maxSpeed;

        // Called when object awakens
        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            audioSource = GetComponent<AudioSource>();
            playerCollider = GetComponent<Collider2D>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        protected override void Update()
        {
            // Get Player Movement input
            if (controlEnabled)
            {
                move.x = Input.GetAxis("Horizontal");
                move.y = Input.GetAxis("Vertical");
            }
            else
            {
                move.x = 0;
            }
            base.Update();
        }

        /// <summary>
        /// Calculate Velocity of the Player based on input
        /// </summary>
        protected override void CalcVelocity()
        {
            targetVelocity = move * maxSpeed;
        }
    }

}