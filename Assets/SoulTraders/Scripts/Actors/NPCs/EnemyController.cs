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

        private bool isChasing = false;

        public float chaseSpeed;

        // Start is called before the first frame update
        void Start()
        {
            aiWander = GetComponent<AIWander>();
            rb2d = GetComponent<Rigidbody2D>();
            playerTransform = GameObject.Find("PlayerCharacter").GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {


            if (Vector2.Distance(playerTransform.position, transform.position) < 10f)
            {
                Chase();
            }
            else if (Vector2.Distance(playerTransform.position, transform.position) > 10)
            {
                EndChase();
            }

        }

        private void FixedUpdate()
        {

        }

        void Chase()
        {
            aiWander.isBusy = true;
            isChasing = true;

            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, chaseSpeed * Time.deltaTime);
        }

        void EndChase()
        {
            isChasing = false;
            aiWander.isBusy = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {

            }
        }


    }
}
