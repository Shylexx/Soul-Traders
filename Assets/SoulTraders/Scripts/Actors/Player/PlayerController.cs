using System.Collections;
using System.Collections.Generic;
using SoulTraders.Core;
using SoulTraders.Controller;
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

        public Rigidbody2D playerBody;

        // Model Reference
        readonly STControl model = STEvents.GetModel<STControl>();

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
            playerBody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        protected override void Update()
        {
            // Get Player Movement input
            if (controlEnabled)
            {
                move.x = Input.GetAxisRaw("Horizontal");
                move.y = Input.GetAxisRaw("Vertical");
            }
            else
            {
                move.x = 0;
                move.y = 0;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                STEvents.Schedule<PlayerDeathEvent>();
            }
            base.Update();
        }

        /// <summary>
        /// Set Target Velocity to
        /// </summary>
        protected override void CalcVelocity()
        {
            targetVelocity = move.normalized * maxSpeed;
        }
    }

}