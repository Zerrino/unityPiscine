using UnityEngine;
using UnityEngine.InputSystem;

public class Player_movements : MonoBehaviour
{
    [SerializeField] float moveForce = 500f;
    [SerializeField] float jumpForce = 125f;
    [SerializeField] GameObject gameOverObject;
    public  Rigidbody rb;
    private bool      touch = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (touch == true && Keyboard.current != null && Keyboard.current.wKey.isPressed)
        {
            rb.AddForce(moveForce * Time.fixedDeltaTime, 0, 0);
        }
        if (touch == true && Keyboard.current != null && Keyboard.current.sKey.isPressed)
        {
            rb.AddForce(-(moveForce * Time.fixedDeltaTime), 0, 0);
        }
        if (touch == true && Keyboard.current != null && Keyboard.current.aKey.isPressed)
        {
            rb.AddForce(0, 0, moveForce * Time.fixedDeltaTime);
        }
        if (touch == true && Keyboard.current != null && Keyboard.current.dKey.isPressed)
        {
            rb.AddForce(0, 0, -(moveForce * Time.fixedDeltaTime));
        }
        if (touch == true && Keyboard.current != null && Keyboard.current.spaceKey.isPressed)
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        touch = true;
        if (collision.gameObject == gameOverObject)
        {
            Debug.Log("Game Over");
            Destroy(rb.gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        touch = true;
    }


    void OnCollisionExit(Collision collision)
    {
        touch = false;
    }
}
