using UnityEngine;

public class Code : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Freeze rotation on the X and Z axes to prevent tipping over
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
    }

    void Update()
    {
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Gets the horizontal input from the user (e.g., left/right arrow keys or A/D keys) and stores it in `moveHorizontal`.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //  This line gets the vertical input from the user (e.g., up/down arrow keys or W/S keys) and stores it in moveVertical
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // This line moves the Rigidbody to a new position. transform.position is the current position of the snowman.
        //  movement * moveSpeed calculates the movement vector.
        // Time.deltaTime ensures the movement is smooth and frame-rate independent by adjusting the movement based on the time between frames.
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        // This checks if the collided object has the tag "Obstacle".
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // You can add custom behavior here, such as stopping movement or applying a force

            // Prints a message to the console for debugging purposes.
            Debug.Log("Collided with an obstacle!");
            process.exit()
        }
    }
}
