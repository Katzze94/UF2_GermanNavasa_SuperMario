using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;  //Parte de gamemanager sale en examen
    
    private Rigidbody2D rBody;

    private AudioSource source;

    public BoxCollider2D boxCollider;

    
    
    public AudioClip deathSound;
    
    public float enemySpeed = 5;

    public float enemyDirection = 1;

    public int contGoomba;


    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();


        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      rBody.velocity = new Vector2(enemyDirection * enemySpeed, rBody.velocity.y);  
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            if(enemyDirection == 1)
        {
            enemyDirection = -1;

        }
        else if(enemyDirection == -1)
        {
            enemyDirection = 1;
            
        }

        }
        
        if(collision.gameObject.tag == "Player")
        {
            
          PlayerMovement player=GameObject.FindObjectOfType<PlayerMovement>();
          //player.MarioDeath();
          
          if(player.isDeath == false)
          {
            player.StartCoroutine("Die");
          }
          
        }

    }

    public void GoombaDeath()
    {
        ContManager contManager = GameObject.FindObjectOfType<ContManager>();
        contManager.LoadGoombaCont();
        source.PlayOneShot(deathSound);
        boxCollider.enabled = false;
        rBody.gravityScale = 0;
        enemyDirection = 0;
        Destroy(gameObject, 0.5f);
    }


    void OnBecameVisible() //Parte de gamemanager sale en examen
    {
        gameManager.enemiesInScreen.Add(this.gameObject);
    }

    void OnBecameInvisible()
    {
        gameManager.enemiesInScreen.Remove(this.gameObject); //Parte de gamemanager sale en examen
    }

}
