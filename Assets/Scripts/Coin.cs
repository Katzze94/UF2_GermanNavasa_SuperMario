using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public BoxCollider2D boxCollider; 
    private AudioSource source;

    public AudioClip coinSound;

    public Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();

        rBody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
    if(Collider.gameObject.tag == "Player") 
    {
        Destroy(gameObject, 0.4f);

        source.clip = coinSound;

        source.Play();

    }



    }
}
