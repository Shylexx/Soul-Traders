using System.Collections;
using System.Collections.Generic;
using SoulTraders.Core;
using UnityEngine;



namespace SoulTraders.Gameplay.Enemy
{
    public class AIRanger : EnemyController
    {
        // !! Issue where the ranger enemy will wander when not chasing or running from the enemy

        AIChase aiChase;




        // Start is called before the first frame update
        void Start()
        {
            aiChase = GetComponent<AIChase>();
            isBusy = false;
        }

        // Update is called once per frame
        protected override void FixedUpdate()
        {
            playerDist = Vector2.Distance(playerTransform.position, transform.position);

            if (playerDist < 15)
            {
                // Set enemy on alert

                isAlert = true;
            }



            if (playerDist < 5)
            {
                // Flee from player  

                Flee();

            }
            else if (playerDist > 5 && playerDist < 10 && isAlert)
            {
                // Shoot the player

                ShootAtPlayer();

            }
            else if (playerDist > 15 && playerDist < 60 && isAlert)
            {
                // Chase the player
                //aiChase.Chase();
                //rb2d.AddForce((playerTransform.position - transform.position) * 200f * Time.deltaTime, ForceMode2D.Force);
            }
            else if (playerDist > 60)
            {
                // End the chase

                isBusy = false;
                isAlert = false;
            }

            base.FixedUpdate();

        }

        private void Flee()
        {
            isBusy = true;
            isAlert = true;

            rb2d.AddForce(-(playerTransform.position - transform.position) * 300f * Time.deltaTime, ForceMode2D.Force);  // Simply flee from the player


        }

        private void ShootAtPlayer()
        {
            // Stop at a certain distance from the player and shoot


        }
    }

}