using UnityEngine;
 
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioClip MeleeAttackSound;
    [SerializeField] private AudioClip JumpSound;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool jumpattack;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate=2f;
    float nextAttackTime=0f;
    private bool doublejump;
    public bool itemjump=false;

    private void Awake()
    {   
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
 
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
 
        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        itemjump = (PlayerPrefs.GetInt("DoubleJump") != 0);
        if (Input.GetKeyDown(KeyCode.Space))
            if(grounded){
                Jump();
                doublejump = true;
                grounded = false;
            }else if(doublejump && itemjump){
                Jump();
                doublejump = false;
            }

        if(Time.time>=nextAttackTime)
        {
            if (Input.GetKey(KeyCode.V))
            {
                Attack();
                nextAttackTime=Time.time+1f/attackRate;
            }
        }

        //sets animation parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("ground", grounded);
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(MeleeAttackSound);
        anim.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(1);
        }
    }
    void OnDrawGizmosSelected()
    {
        if(attackPoint==null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
 
    private void Jump()
    {
        SoundManager.instance.PlaySound(JumpSound);
        body.velocity = new Vector2(body.velocity.x, 8);
        //grounded = false;
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            grounded = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }

}