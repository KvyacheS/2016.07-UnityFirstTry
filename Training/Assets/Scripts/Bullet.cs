using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    public string target;
    public float speed=1f;
    public bool moveleft = false;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.CompareTag(target));
        if (other.gameObject.CompareTag(target))
            Destroy(gameObject);
    }
    // Update is called once per frame
    void Update() {
        Vector2 vec = new Vector2(0.5f, 0);
        if (!moveleft)
        {
            rb2d.MovePosition(rb2d.position + vec * Time.deltaTime * speed);
        }
        else
        {
            rb2d.MovePosition(rb2d.position - vec * Time.deltaTime * speed);
            spriteRenderer.flipX = true;
        }
    }
    
}
