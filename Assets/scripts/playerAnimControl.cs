using UnityEngine;

public class playerAnimControl : MonoBehaviour
{
    public Animator anim;
    private float inputX;

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        if(inputX>0) //right
        {
            //spren.flipX=false;
            anim.SetBool("walkFront", true);
        }
        else if(inputX<0)
        {
            anim.SetBool("walkFront", true);
        }
        else if(inputX==0)
        {
            anim.SetBool("idle",true);
            anim.SetBool("walkFront", false);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("punch");
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            anim.SetTrigger("kick");
        }
        
    }
}
