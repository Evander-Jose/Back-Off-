using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorInput : MonoBehaviour
{
    public Transform playerTransform;
    public float distanceFromPlayer;
    public float mirrorSpeed = 10f;

    private void Start()
    {
        playerTransform = transform.parent;
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosInRealWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 directionTowardsMouse = mousePosInRealWorld - playerTransform.position;
        directionTowardsMouse.Normalize();

        //Making the mirror orbit around the player:
        float angleDifference = Vector3.SignedAngle(directionTowardsMouse, transform.up, Vector3.forward);
        angleDifference *= -1f;
        transform.RotateAround(playerTransform.position, Vector3.forward, angleDifference * Time.deltaTime * mirrorSpeed);

        //This one just modifies position:

        ////adjusting position:
        //directionTowardsMouse = new Vector3(directionTowardsMouse.x, directionTowardsMouse.y, 0f);

        ////Try lerping:
        //Vector3 offset = new Vector3(directionTowardsMouse.x, directionTowardsMouse.y, 0f) * distanceFromPlayer;
        //Vector3 difference = offset - oldPosition;
        //transform.Translate(difference * Time.deltaTime * 50f, playerTransform);

        ////adjusting rotation:
        //transform.up = directionTowardsMouse;
    }
}
