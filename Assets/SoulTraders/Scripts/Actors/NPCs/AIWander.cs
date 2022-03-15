using System.Collections;
using System.Collections.Generic;
using SoulTraders.Core;
using UnityEngine;



namespace SoulTraders.Gameplay.Enemy
{
    public class AIWander : EnemyController
    {

        [HideInInspector] public float maxWanderDist;
        [HideInInspector] public float wanderSpeed;

        [HideInInspector] public Vector2 wayPoint;
       
        [HideInInspector] public float distance;
        

        [HideInInspector] public bool isWalking = true;
        [HideInInspector] public bool isWandering = false;
        





        // Start is called before the first frame update
        void Start()
        {
            
            
        }

         new void Update()
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





        






