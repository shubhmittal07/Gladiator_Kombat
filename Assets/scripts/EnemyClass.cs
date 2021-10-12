using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyClass : MonoBehaviour
{
    private float attackDist;
    public GameObject player;
    private Vector2 heading;
    private float playerDist;
    private Vector2 playerDir;
    public player myPlayer;
    public Animator Enemy_anim;
    private bool isFlipped = false;
    public Transform hitPoint_rt;
    public Transform hitPoint_lt;
    Vector2 hitPoint;
    public float attack_range;
    public LayerMask Player;
    public SpriteRenderer spren;
    public float enemy_health=100;
    public AudioSource playSound;
    public AudioClip SwordHit;
    public Rigidbody2D rb;
    public ParticleSystem blood_splat;
    private ParticleSystem blood;
    private Material matwhite;
    private Material matDefault;
    public GameObject LoseScene;
    public GameObject goBack;
    private bool gameOver = false;

    void Start()
    {
        matwhite = Resources.Load("Whiteflash", typeof(Material)) as Material;
        matDefault = spren.material;
        
    }
    void Update()
    {
        playerDist = (player.transform.position - transform.position).magnitude;
        if(playerDist>1.0f && myPlayer.isGrounded)
        {
            Enemy_anim.SetBool("WalkRight",true);
        }
        if(playerDist<1.7f)
        {
            Enemy_anim.SetTrigger("Attack");
        }
        hitPoint = spren.flipX? (Vector2)hitPoint_lt.position:(Vector2)hitPoint_rt.position;
        if(gameOver)
        {
            Enemy_anim.SetBool("WalkRight",false);
            Enemy_anim.ResetTrigger("Attack");
        }
        if(gameOver && Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene(0);
        }
    }
    void Attack()
    {
        FacePlayer();
        Collider2D[] enemy2D = Physics2D.OverlapCircleAll(hitPoint,attack_range,Player);
        foreach(Collider2D enemy in enemy2D)
        {
            playSound.PlayOneShot(SwordHit);
            //myPlayer.player_damage(10);
            if(myPlayer.health<=0)
            {
                gameOver = true;
                LoseScene.SetActive(true);
                goBack.SetActive(true);
                //Destroy(enemy.gameObject);
                enemy.gameObject.SetActive(false);
            }
        }
    }
    public void FacePlayer()
    {
        if(transform.position.x > player.transform.position.x && isFlipped) //player is on left
        {
            transform.Rotate(0f,180f,0f);   //turn left
            isFlipped = false;
        }
        if(transform.position.x < player.transform.position.x && !isFlipped)
        {
            transform.Rotate(0f,180f,0f); //turn right
            isFlipped = true;
        } 
    }

    public void Damage(float damage)
    {
        enemy_health -= damage;
        blood = Instantiate(blood_splat,transform.position,Quaternion.identity);
        blood.Play();
        spren.material = matwhite;
        rb.AddForce(transform.right*11f,ForceMode2D.Impulse);
        Invoke("ResetMat",0.2f);
    }

    void ResetMat()
    {
        spren.material = matDefault;
    }
}
