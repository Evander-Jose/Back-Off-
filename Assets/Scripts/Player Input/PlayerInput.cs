using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public float movementSpeed = 5f;
    public float focusSpeed = 2f;
    [Space]
    public GameObject normalShield;
    public GameObject focusedShield;

    private Animator anim;
    private float currentSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //A rather simple input system:
        float x_input = Input.GetAxisRaw("Horizontal");
        float y_input = Input.GetAxisRaw("Vertical");

        //While pressing the left shift key:
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Make the current speed into the focused speed:
            currentSpeed = focusSpeed;

            //Turn off the normal shield:
            normalShield.SetActive(false);

            //Turn on the focused shield:
            focusedShield.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //Undo everything done above:
            currentSpeed = movementSpeed;
            normalShield.SetActive(true);
            focusedShield.SetActive(false);
        }



        Vector2 velocity = new Vector2(x_input, y_input) * currentSpeed;

        playerRigidbody.velocity = velocity;

        //Walking animation:
        bool useWalkAnimation = x_input != 0 || y_input != 0;
        anim.SetBool("isWalking", useWalkAnimation);
    }
}
