using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Health : MonoBehaviour
{
    public int health;
    private int maxHealth;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    public AudioClip loseHealthSound;
    public AudioClip deathSound;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
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
            StartCoroutine(Die());
        }
        else
        {
            if(audioSource != null && loseHealthSound != null)
            {
               audioSource.Stop();
               audioSource.PlayOneShot(loseHealthSound);
                
            } 
            ChooseSprite();
        }
    }

    IEnumerator Die()
    {
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer.enabled = false;

        if (collider != null)
        {
            collider.enabled = false;
        }

        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
            yield return new WaitWhile(() => audioSource.isPlaying);
        }

       Destroy(gameObject);
    }

    private void ChooseSprite()
    {
        spriteRenderer.sprite = sprites[sprites.Length - 1 -  (Mathf.CeilToInt(((float)health / maxHealth) * sprites.Length) - 1)];
    }
}
