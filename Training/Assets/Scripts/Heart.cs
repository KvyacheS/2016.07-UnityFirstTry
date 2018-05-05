using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

    public Sprite healthyHeart;
    public Sprite damagedHeart;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
    public void DamageHeart()
    {
        spriteRenderer.sprite = damagedHeart;
    }

    public void HealHeart()
    {
        spriteRenderer.sprite = healthyHeart;
    }

	// Update is called once per frame
	//void Update () {
	//
	//}
}
