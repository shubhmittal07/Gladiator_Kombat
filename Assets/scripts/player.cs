using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    #region VARIABLES
    private float inputX;
    public float moveSpeed;
    private float velocity;
    public LayerMask ground;
    public LayerMask enemy;
    public Collider2D myCollider;
    public Rigidbody2D myBody;
    public float maxJump; 
    private float jumpForce;
    private float dropConst; 
    private float fpsStabilize;
    public bool isGrounded=false;
    public Animator anim;
    public SpriteRenderer spren;
    public Transform hitPoint_rt;
    public Transform hitPoint_lt;
    Vector2 hitPoint;
    public float attack_range;
    public AudioClip sword_swing;
    public AudioClip sword_hit;
    public AudioSource audioSys;
    public float health=100;
    public EnemyClass enemy_script;
    public CamerShake shakeCam;
    public ParticleSystem blood_splat;
    private ParticleSystem blood;
    public pauseGame pause;
    public GameObject WinScene;
    public GameObject goBack;
    private bool gameOver=false;
    public float gravityRay;
    

    #endregion
    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position,Vector2.down,gravityRay,ground);
        //inputX = Input.GetAxisRaw("Horizontal");
        hitPoint = spren.flipX? (Vector2)hitPoint_lt.position:(Vector2)hitPoint_rt.position;
        #region Jumping Conditions
        jumpForce = Mathf.Clamp(jumpForce,0,maxJump);
        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                jumpForce = maxJump;
                //dropConst = 0;

            }
        }
        /*else if(!isGrounded)
        {
            dropConst = 10f;
            jumpForce -= dropConst;
        }*/
        #endregion
        #region Stabilize FPS
        if(Time.frameCount/Time.time <=60)
        {
            fpsStabilize = 0.10f;
        }
        else if(Time.frameCount/Time.time >60 && Time.frameCount/Time.time <=100)
        {
            fpsStabilize = 0.30f;
        }
        else if(Time.frameCount/Time.time >100 && Time.frameCount/Time.time <=200)
        {
            fpsStabilize = 0.4f;
        }
        else if(Time.frameCount/Time.time >200)
        {
            fpsStabilize = 1.5f;
        }
        #endregion
        if(gameOver && Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene(0);
        }
        //#endregion
    }
    private void FixedUpdate()
    {
        
        
        //velocity = inputX * moveSpeed;
        //transform.Translate(Vector2.right*velocity*Time.deltaTime);
        //myBody.velocity = new Vector2(velocity*Time.deltaTime,myBody.velocity.y);
        Jump();
        
    }
    void Jump()

    {
        //We dont use time.deltatime for physics based calculations.
        myBody.AddForce(new Vector2(myBody.velocity.x, jumpForce),ForceMode2D.Impulse);
    }

    /*public void Attack()
    {
        Collider2D[] enemy2D = Physics2D.OverlapCircleAll(hitPoint,attack_range,enemy);
        foreach(Collider2D enemy in enemy2D)
        {
            audioSys.PlayOneShot(sword_hit);
            enemy_script.Damage(3);
            if(enemy_script.enemy_health<=0)
            {
                gameOver = true;
                WinScene.SetActive(true);
                Destroy(enemy.gameObject);
                goBack.SetActive(true);
            }
            StartCoroutine(shakeCam.Shake(0.1f,0.2f));
            StartCoroutine(pause.pause(0.9f));

        }
        audioSys.PlayOneShot(sword_swing);
        
    }
    public void player_damage(float damage)
    {
        health -= damage;
        blood = Instantiate(blood_splat,transform.position,Quaternion.identity);
        blood.Play();     
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position , transform.position + Vector3.down * gravityRay);
    }
    

}
