using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rBody;
   
    public Vector3 newPosition = new Vector3(50, 5, 0);

    public float movementSpeed = 5;
    public float jumpForce = 10;

    private float inputHorizontal;

    public bool jump = false;

    public GroundSensor sensor;

    public SpriteRenderer render;

    public Animator anim;

    AudioSource source;

    public AudioClip jumpSound;

    public Transform bulletSpawn;

    public GameObject bulletPrefab;

    private bool canShoot = true;

    public float timer;

    public float rateOfFire = 1;

    public Transform hitBox;

    public float hitBoxRadius = 2;

void Awake()
{
    rBody = GetComponent<Rigidbody2D>();
    render = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
    source = GetComponent<AudioSource>();
}

    // Start is called before the first frame update
    void Start()
    {
        // Teletransporta al pesonaje a la poscion de la variable newposition
        // transform.position = newPosition;

        
        
    }

    // Update is called once per frame
    void Update()
    {

        Shoot();
        inputHorizontal = Input.GetAxis("Horizontal");
        //transform.position = transform.position + new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime;
        // transform.position += new Vector3(inputHorizontal, 0, 0) * movementSpeed * Time.deltaTime;

        

       /*if(jump == true)
        {
            Debug.Log("estoy saltando");
        }
        else if (jump == false)
        {
            Debug.Log("estoy en el suelo");
 
        }
        else
        {
            Debug.Log("hi");
        }*/
       
        if(Input.GetButtonDown("Jump") && sensor.isGrounded == true)
        {   
            
            rBody.AddForce(new Vector2(0,1) * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            source.PlayOneShot (jumpSound);
         }
        
        if(inputHorizontal < 0)
        {
            render.flipX = true;
            anim.SetBool("isRunning", true);
        }
        else if(inputHorizontal > 0)
        {
            render.flipX = false;
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            //Attack();
            anim.SetTrigger("isAttacking");
        }
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(inputHorizontal * movementSpeed, rBody.velocity.y);
    
    }

   void OnCollisionEnter2D(Collision2D collision)
   {
    if(collision.gameObject.tag=="Void")
    {
        MarioDeath();
    }
    
   }

    void Shoot()
    {
        if(!canShoot)
        {
            timer += Time.deltaTime;
            if(timer>= rateOfFire)
            {
                canShoot = true;
                timer = 0;
            }

        }
        if(Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            Instantiate(bulletPrefab, bulletSpawn.position,bulletSpawn.rotation);

            canShoot = false;
        }
    }





   public void MarioDeath()
   {
    SceneManager.LoadScene("Game Over");
    Destroy(gameObject);
   }

   public void Attack()
   {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitBox.position, hitBoxRadius);

        foreach (Collider2D enemy in enemies)
        {
            if(enemy.gameObject.tag == "Goombas")
            {
                //Destroy(enemy.GameObject);
                Enemy enemyScript = enemy.GetComponent<Enemy>();

                enemyScript.GoombaDeath();
            }
        }
   }


   void OnDrawGizmos()
   {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(hitBox.position, hitBoxRadius);
   }
}
