using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public int bulletAddAmount;
    public int respawnTime;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.AddBullets(bulletAddAmount);
            Invoke(nameof(Respawn), respawnTime);
            gameObject.SetActive(false);

        }
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
    }
}
