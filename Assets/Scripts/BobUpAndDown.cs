using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobUpAndDown : MonoBehaviour
{
    public float bobSpeed;
    public float bobDistance;
    public float destructiveBobSpeed;
    public float destructiveBobDistance;
    public float sideSpeed;
    public float sideDistance;

    private float totalTime = 0;
    private float baseY;
    private float baseX;


    // Start is called before the first frame update
    void Start()
    {
        baseY = transform.position.y;
        baseX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        totalTime += Time.deltaTime;
        float yPos = baseY + Mathf.Sin(bobSpeed * totalTime) * bobDistance + Mathf.Sin(destructiveBobSpeed * totalTime) * destructiveBobDistance;
        float xPos = baseX + Mathf.Sin(sideSpeed * totalTime) * sideDistance;
        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
