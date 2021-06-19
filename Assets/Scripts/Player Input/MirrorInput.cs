using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorInput : MonoBehaviour
{
    public Transform playerTransform;
    public float distanceFromPlayer;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosInRealWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 directionTowardsMouse = mousePosInRealWorld - playerTransform.position;
        directionTowardsMouse.Normalize();


        //adjusting position:
        directionTowardsMouse = new Vector3(directionTowardsMouse.x, directionTowardsMouse.y, 0f);
        transform.position = playerTransform.position + new Vector3(directionTowardsMouse.x, directionTowardsMouse.y, 0f) * distanceFromPlayer;

        //adjusting rotation:
        transform.up = directionTowardsMouse;
    }
}
