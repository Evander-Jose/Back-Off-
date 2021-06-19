using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public float movementSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //A rather simple input system:
        float x_input = Input.GetAxisRaw("Horizontal");
        float y_input = Input.GetAxisRaw("Vertical");

        Vector2 velocity = new Vector2(x_input, y_input) * movementSpeed;

        playerRigidbody.velocity = velocity;

    }
}
