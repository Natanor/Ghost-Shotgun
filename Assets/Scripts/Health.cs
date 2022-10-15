using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    private int maxHealth;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChooseSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealth(int hpLoss)
    {
        health -= hpLoss;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            ChooseSprite();
        }

    }

    private void ChooseSprite()
    {
        spriteRenderer.sprite = sprites[Mathf.CeilToInt(((float)health / maxHealth) * sprites.Length) - 1];
    }
}
