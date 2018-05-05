using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public AudioClip shootSound1;
    public AudioClip shootSound2;
    public AudioClip moveSound1;
    public AudioClip dieSound;
    public AudioClip medpackSound;
    public Shoter shoter;
    //public RuntimeAnimatorController original;
   // public RuntimeAnimatorController overrid;
    public AnimatorOverrideController overrideController;

    private RuntimeAnimatorController original;

    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        original = animator.runtimeAnimatorController;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
    float nextFire;
    // Update is called once per frame
   
    void FixedUpdate ()
    {
        if(Input.GetButton("Fire1"))
        {
            animator.runtimeAnimatorController = overrideController;
            if (Time.time > nextFire)
            {
                nextFire = Time.time + 1f/shoter.fireRate;
                shoter.Fire();
            }
        }
        else
        {
            animator.runtimeAnimatorController = original;
        }
        float vertical = Input.GetAxis("Vertical");
        animator.SetBool("isDucking", false);
        if (vertical < 0)
        {
            animator.SetBool("isDucking", true);
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal");
            if (horizontal != 0)
            {
                if (horizontal < 0)
                    spriteRenderer.flipX = true;
                else
                    spriteRenderer.flipX = false;
                animator.SetBool("isMoving", true);
            }
            else
                animator.SetBool("isMoving", false);
            Vector2 dir = new Vector2(horizontal, vertical);
            // rb2d.AddForce(dir*20);
            if (horizontal != 0)
                rb2d.MovePosition(rb2d.position + dir * Time.fixedDeltaTime);
        }
    }
}
