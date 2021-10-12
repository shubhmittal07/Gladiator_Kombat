using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : StateMachineBehaviour
{
    private float inputX;
    public float moveSpeed;
    Rigidbody myBody;
    private float velocity;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        myBody = animator.GetComponent<Rigidbody>();
        //Debug.Log(animator.name);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inputX = Input.GetAxisRaw("Horizontal");
        velocity = inputX * moveSpeed;
        animator.transform.Translate(new Vector3(0,0,1)*velocity*Time.deltaTime);
        //myBody.velocity = new Vector3(myBody.velocity.y,myBody.velocity.y,velocity*Time.deltaTime);
        //Debug.Log("I am working");
    }

    public void walkStop(Animator animator) 
    {
        //Debug.Log("Exiting");
        animator.transform.Translate(new Vector3(0,0,0));
    }

   
}
