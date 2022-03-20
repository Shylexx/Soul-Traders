using System.Collections;
using System.Collections.Generic;
using SoulTraders.Core;
using UnityEngine;



namespace SoulTraders.Gameplay.Enemy
{
    public class EnemyController : MovableActor
    {
        [HideInInspector] public Transform playerTransform;
        [HideInInspector] public AIWander aiWander;
        [HideInInspector] public Rigidbody2D rb2d;
        [HideInInspector] public bool isBusy;
        [HideInInspector] public bool isAlert = false;
        [HideInInspector] public float playerDist;

        // Start is called before the first frame update
        protected virtual void Awake()
        {
            playerTransform = GameObject.Find("PlayerCharacter").GetComponent<Transform>();
            aiWander = GetComponent<AIWander>();
            rb2d = GetComponent<Rigidbody2D>();
            Debug.Log("Got Components");
        }

        // Update is called once per frame
        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        protected override void Update()
        {
            playerDist = Vector2.Distance(playerTransform.position, transform.position);
        }
    }
}
