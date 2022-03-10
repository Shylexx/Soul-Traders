using System.Collections;
using System.Collections.Generic;
using SoulTraders.Core;
using SoulTraders.Controller;
using UnityEngine;

namespace SoulTraders.Gameplay.Player
{

    public class PlayerController : MovableActor
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Knockback(1, 10, new Vector2(0, 0)));
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Interact();
            }
            base.Update();
        }

        protected override void FixedUpdate()
        {
            body.velocity = CalcVelocity();
            base.FixedUpdate();
        }

        /// <summary>
        /// Set Target Velocity to
        /// </summary>
        protected Vector2 CalcVelocity()
        {
            return (move.normalized * maxSpeed);
        }

        void Interact()
        {
            Interactable interactable = GetClosestInteractable(GetNearInteractableColliders());
            if (interactable != null)
            {
                interactable.OnInteract();
                interactable = null;
            }
        }

        List<Collider2D> GetNearInteractableColliders()
        {
            List<Collider2D> nearInteractables = new List<Collider2D>();
            ContactFilter2D noFilter = new ContactFilter2D();
            noFilter.NoFilter();
            int countNearInteractables = Physics2D.OverlapCircle((Vector2)transform.position, 1, noFilter, nearInteractables);
            nearInteractables.RemoveAll(item => IsInteractable(item));
            return (nearInteractables);
        }

        Interactable GetClosestInteractable(List<Collider2D> colliders)
        {
            Collider2D bestTarget = null;
            float closestDistanceSqr = Mathf.Infinity;
            Vector2 currentPosition = transform.position;
            foreach (Collider2D potentialTarget in colliders)
            {
                Vector2 dirToTarget = (Vector2)potentialTarget.transform.position - currentPosition;
                float dSqrToTarget = dirToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
            if (bestTarget != null)
            {
                Interactable closestInteractable = bestTarget.GetComponent<Interactable>();
                if (closestInteractable != null)
                {
                    return closestInteractable;
                }
                else return null;
            }
            else return null;
        }

        bool IsInteractable(Collider2D collider)
        {
            if (collider.GetComponent<Interactable>() != null)
            {
                return (false);
            }
            else return true;
        }

    }

}