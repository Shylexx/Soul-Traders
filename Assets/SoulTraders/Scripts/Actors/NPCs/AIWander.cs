using System.Collections;
using System.Collections.Generic;
using SoulTraders.Core;
using UnityEngine;



namespace SoulTraders.Gameplay.Enemy
{
    public class AIWander : KinematicObject
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

         protected override void Update()
         {
            distance = Vector2.Distance(transform.position, wayPoint);
            //Debug.Log(distance);
            
            if (distance > maxWanderDist)
            {
                NewWanderPoint();
            }
            
            //start wander
            if (distance <= 0.5 && !isWandering && !isBusy)
            {
                StartCoroutine(DoWander());


            }

            //stop and wait
            if (!isWandering && distance <= 0.5)
            {
                NewWanderPoint();
                direction = Vector2.zero;
            }
            base.Update();
          

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
            direction = (wayPoint - (Vector2)transform.position).normalized;

            isWalking = true;
            isWandering = false;
        }

        protected override void CalcVelocity()
        {
            targetVelocity = direction * wanderSpeed;
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




