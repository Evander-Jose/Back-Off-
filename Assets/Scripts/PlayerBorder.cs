using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour
{
    public Transform minCorner;
    public Transform maxCorner;
    [Space]
    public Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerInput>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        float clamped_x = Mathf.Clamp(playerTransform.position.x, minCorner.position.x, maxCorner.position.x);
        float clamped_y = Mathf.Clamp(playerTransform.position.y, minCorner.position.y, maxCorner.position.y);

        playerTransform.position = new Vector3(clamped_x, clamped_y, playerTransform.position.z);
    }
}
