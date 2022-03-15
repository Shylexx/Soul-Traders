using System.Collections;
using System.Collections.Generic;
using SoulTraders.Core;
using UnityEngine;



namespace SoulTraders.Gameplay.Enemy
{
    public class AIChase : EnemyController
    {

        //Checks for later use
         [HideInInspector] public bool isChasing = false;
        //private bool isAttacking = false;

        public float chaseSpeed;
        public float chaseDist = 60;
        

        // Start is called before the first frame update
        void Awake()
        {
            
            
        }

        // Update is called once per frame
        new void FixedUpdate()
        {
            //checking the distance between the player and itself

            if (playerDist < 10)
            {
                Chase();
            }
            else if (playerDist > chaseDist) 
            {
                EndChase();
            } 
            else if (isChasing && playerDist > 10)
            {
                Chase();
            }
            
           

        }

       new private void Update()
        {
            

        }


        public void Chase()
        {
            // simple chase function , keeps checking the distance between and decides what to do depending.

            FindNearestEnemy();


            isBusy = true;
            isChasing = true;

            
            if (playerDist > 3)
            {
                
                rb2d.AddForce((playerTransform.position - transform.position) * chaseSpeed * Time.deltaTime, ForceMode2D.Force);

            } 
            else if (playerDist <= 3 && playerDist > 2)
            {
                rb2d.AddForce(-(playerTransform.position - transform.position) * 200f * Time.deltaTime, ForceMode2D.Force);
            } 
           
           if (playerDist <= 2)
            {
                rb2d.AddForce(-(FindNearestEnemy().transform.position - transform.position) * 200f * Time.deltaTime, ForceMode2D.Force);
            }

           

            
            
            
        }

        public void EndChase()
        {
            isChasing = false;
            isBusy = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Have enemies 
            if (collision.gameObject.tag == ("Enemy"))
            {
                //Not working vv
                
                //Debug.Log("Collision !");
            } 
            
        }

        public GameObject FindNearestEnemy()
        {
            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject closest = null;
            float enemyDist = Mathf.Infinity;
            Vector2 position = transform.position;

            if (enemies.Length == 0)
            {
                Debug.Log("No Enemies in array");
            }

            foreach(GameObject enemy in enemies)
            {
                Vector2 diff = (Vector2)enemy.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < enemyDist)
                {
                    closest = enemy;
                    enemyDist = curDistance;
                    //Debug.Log(enemyDist);
                }

                
            }
            return closest;
        }
    }
}

                
                    
            
            
        
        



