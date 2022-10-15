using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector2 offset = new(0, 2.5f);
    public SpriteRenderer mapBounds;


    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthsize;
    private float camHorizontalOrthsize;
    private Camera mainCam;

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
        this.transform.position = new Vector3(camX, camY, -10);
    }
}
