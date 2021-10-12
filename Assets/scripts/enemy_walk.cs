using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_walk : StateMachineBehaviour


{
        
        private Vector2 heading;
        private float playerDist;
        public Transform player;
        Rigidbody2D rb;
        Vector2 newPos;
        Vector2 target;
        public float speed = 2.5f;
        EnemyClass enemy;
        //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            rb = animator.GetComponent<Rigidbody2D>();
            enemy = animator.GetComponent<EnemyClass>();
        }

        //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            target = new Vector2(player.position.x,rb.position.y);
            newPos= Vector2.MoveTowards(rb.position , target ,speed * Time.fixedDeltaTime );
            rb.MovePosition(newPos);
            enemy.FacePlayer();
            /*if(player == null || player.transform == null)
            {
                Debug.Log("player not found");
                player = null;
                return;
            }*/
        }
}
