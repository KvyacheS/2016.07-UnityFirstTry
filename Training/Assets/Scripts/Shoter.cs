using UnityEngine;
using System.Collections;

public class Shoter : MonoBehaviour {


    public Bullet bullet;
    public float fireRate;
    public float xDir;
    public float yDir;
    //public Transform par;
    private SpriteRenderer spriteRender;
	// Use this for initialization
	void Start () {
        //  par = GetComponent<Transform>();
        spriteRender = GetComponent<SpriteRenderer>();
	}


    public void Fire()
    {
      
        Bullet instance = Instantiate(bullet);
        if (spriteRender.flipX == true)
        {
            Vector3 offset = new Vector2(xDir, -yDir);
            instance.moveleft = true;
            instance.transform.position = transform.position - offset;
        }
        else
        {
            Vector3 offset = new Vector2(xDir, yDir); ;
            instance.transform.position = transform.position + offset;
        }

    }
	// Update is called once per frame
	//void Update () {
	//
	//}
}
