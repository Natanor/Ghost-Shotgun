using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    public float shotPower;
    public float spinPower;
    private Rigidbody2D playerRb;
    private Animator animator;
    public int trailAmount;
    public float spread;

    private GameManager gameManager;
    public GameObject shotPrefab;
    private GameObject muzzle;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        muzzle = transform.Find("Muzzle").gameObject;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }


        playerRb.AddTorque(-Input.GetAxis("Horizontal") * spinPower  * Time.deltaTime);

    }

    private void Shoot()
    {
        if (gameManager.TryLoseBullet())
        {
            playerRb.AddForce(-transform.right * shotPower, ForceMode2D.Impulse);
            animator.SetTrigger("Shoot");
            gameManager.PlayShotSound();
            CreateTrails();
        }
    }

    private void CreateTrails()
    {
        for(int i = 0; i < trailAmount; i++)
        {
            CreateTrail();
        }
    }

    private void CreateTrail()
    {
        Vector3 muzzleLocation = muzzle.transform.position;
        
        GameObject trail = Instantiate(shotPrefab, muzzleLocation, transform.rotation);
        trail.transform.Rotate(Vector3.forward * Random.Range(-spread, spread));

        float length = Physics2D.RaycastAll(muzzleLocation, trail.transform.right).First(x => !x.collider.gameObject.CompareTag("Player")).distance;
        trail.transform.localScale = new Vector3(length, trail.transform.localScale.y, trail.transform.localScale.z);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameManager.ResetBulletCount();
        }
    }
}
