using System.Collections;
using System.Collections.Generic;
using SoulTraders.Core;
using UnityEngine;



namespace SoulTraders.Gameplay.Enemy
{
    public class AIWander : EnemyController
    {

        [SerializeField] private float maxWanderDist;
        [SerializeField] private float wanderSpeed;

        BoxCollider2D boxCollider;
        Rigidbody2D rigidBody;


        Vector2 wayPoint;
        Vector2 direction;

        float distance;




        private bool isWalking = true;
        private bool isWandering = false;
        public bool isBusy = false;






        // Start is called before the first frame update
        void Start()
        {
            boxCollider = GetComponent<BoxCollider2D>();
            rigidBody = GetComponent<Rigidbody2D>();
        }

          void Update()
         {
            distance = Vector2.Distance(transform.position, wayPoint);
            //Debug.Log(distance);
            
            if (isWalking && !isBusy)
            {
                transform.position = Vector2.MoveTowards(transform.position, wayPoint, wanderSpeed *Time.deltaTime);
            }

            //make sure waypoint is not too far
            if (distance > maxWanderDist && !isBusy)
            {
                NewWanderPoint();
            }
            
            //start wander
            if (distance <= 0.5 && !isWandering && !isBusy)
            {
                StartCoroutine(DoWander());


            }

            //stop and wait
            if (!isWalking && distance <= 0.5 && !isBusy)
            {
                NewWanderPoint();
                direction = Vector2.zero;
            }
            
          

         }

        void NewWanderPoint()
        {
            wayPoint = new Vector2(transform.position.x + Random.Range(-maxWanderDist, maxWanderDist), transform.position.y + Random.Range(-maxWanderDist, maxWanderDist));
        }



        IEnumerator DoWander()
        {
            isWandering = true;
            isWalking = false;

            yield return new WaitForSeconds(Random.Range(1, 6));

            NewWanderPoint();
            

            isWalking = true;
            isWandering = false;
        }

        

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                NewWanderPoint();
            }

            if (collision.gameObject.layer == 7)
            {
                NewWanderPoint();
            }
        }
    }
}




