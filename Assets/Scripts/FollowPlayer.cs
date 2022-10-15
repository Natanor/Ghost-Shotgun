using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector2 offset = new(0, 2.5f);
    public Vector2 shakeOffset =  Vector2.zero;
    public SpriteRenderer mapBounds;


    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthsize;
    private float camHorizontalOrthsize;
    private Camera mainCam;
    public float shakePower;
    public int amountOfShakes;
    public float shakeDelay;

    // Start is called before the first frame update
    void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;

        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        camHorizontalOrthsize = mainCam.aspect * camOrthsize;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeOrthSize(float orthSize)
    {
        mainCam.orthographicSize = orthSize;
        camOrthsize = mainCam.orthographicSize;
        camHorizontalOrthsize = mainCam.aspect * camOrthsize;
    }

    void FixedUpdate()
    {
        camY = Mathf.Clamp(player.transform.position.y + offset.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(player.transform.position.x + offset.x, xMin + camHorizontalOrthsize, xMax - camHorizontalOrthsize);
        camY += shakeOffset.y;
        camX += shakeOffset.x;

        this.transform.position = new Vector3(camX, camY, -10);
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());

    }

    IEnumerator ShakeCoroutine()
    {
        for(int i=0; i<amountOfShakes; i++)
        {
            shakeOffset = new Vector2(Random.Range(-shakePower, shakePower), Random.Range(-shakePower, shakePower));
            yield return new WaitForSeconds(shakeDelay);
        }
    }

}
