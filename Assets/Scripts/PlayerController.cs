using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float shotPower;
    public float spinPower;
    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerRb.AddForce(-transform.right * shotPower, ForceMode2D.Impulse);
        }


        playerRb.AddTorque(-Input.GetAxis("Horizontal") * spinPower );


    }
}
