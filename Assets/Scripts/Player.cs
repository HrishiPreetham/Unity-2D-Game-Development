using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce=10f;

    [SerializeField]
    private float jumpForce=11f;
    
    private float movementX;

    private Rigidbody2D mybody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION="Walk";

    private bool isGrounded;

    private string GROUND_TAG="Ground";

    private string ENEMY_TAG="Enemy";

    private void Awake()
    {
        mybody=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        playerjump();
    }

    void PlayerMovementKeyboard()
    {
         movementX=Input.GetAxisRaw("Horizontal");
        transform.position+=new Vector3(movementX,0f,0f)*moveForce*Time.deltaTime;
    }

    void AnimatePlayer()
    {
        if(movementX>0)
        {
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX=false;
        }
        else if(movementX<0)
        {
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX=true;
        }
        else{
            anim.SetBool(WALK_ANIMATION,false);
        }
    }

    void playerjump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {   
            isGrounded=false;
            mybody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded=true;
        }
        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}

















