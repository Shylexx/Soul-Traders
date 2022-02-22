using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SoulTraders.Gameplay.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        AIWander aiWander;
        Rigidbody2D rb2d;
       



        Transform playerTransform;

        //Checks for later use
        private bool isChasing = false;
        private bool isAttacking = false;

        public float chaseSpeed;
        public int chaseDist = 60;
        

        // Start is called before the first frame update
        void Awake()
        {
            aiWander = GetComponent<AIWander>();
            rb2d = GetComponent<Rigidbody2D>();
            playerTransform = GameObject.Find("PlayerCharacter").GetComponent<Transform>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            

            if (Vector2.Distance(playerTransform.position, transform.position) < 10)
            {
                Chase();
            }
            else if (Vector2.Distance(playerTransform.position, transform.position) > chaseDist) 
            {
                EndChase();
            } 
            else if (isChasing && Vector2.Distance(playerTransform.position, transform.position) > 10)
            {
                Chase();
            }
            
           

        }

        private void Update()
        {
          

        }


        void Chase()
        {
            FindNearestEnemy();


            aiWander.isBusy = true;
            isChasing = true;

            
            if (Vector2.Distance(playerTransform.position, transform.position) > 3)
            {
                
                rb2d.AddForce((playerTransform.position - transform.position) * chaseSpeed * Time.deltaTime, ForceMode2D.Force);

            } 
            else if (Vector2.Distance(playerTransform.position, transform.position) <= 3 && Vector2.Distance(playerTransform.position, transform.position) > 2)
            {
                rb2d.AddForce(-(playerTransform.position - transform.position) * 200f * Time.deltaTime, ForceMode2D.Force);
            } 
           
           if (Vector2.Distance(FindNearestEnemy().transform.position, transform.position) < 1)
            {
                rb2d.AddForce(-(FindNearestEnemy().transform.position - transform.position) * 200f * Time.deltaTime, ForceMode2D.Force);
            }

            
            
            
        }

        void EndChase()
        {
            isChasing = false;
            aiWander.isBusy = false;
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
                }

                
            }
            return closest;
        }
    }
}

                
                    
            
            
        
        



