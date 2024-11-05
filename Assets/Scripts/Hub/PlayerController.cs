using UnityEngine;
using UnityEngine.SceneManagement;

// Attached to player; controles movement.
public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 10.0f;
    public Transform cameraTransform;
    private Rigidbody playerRb; // Reference to player's Rigidbody.

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    private void FixedUpdate()
    {
        // unity default horizontal/vertical; capture input from wasd or arrow keys (0 , 1, or -1)
        float horizontalInput = Input.GetAxis("Horizontal"); // left/right
        float verticalInput = Input.GetAxis("Vertical"); // up/down

        // movement direction based on the camera's orientation
        Vector3 forwardMovement = cameraTransform.forward * verticalInput;
        Vector3 rightMovement = cameraTransform.right * horizontalInput;

        // Combine directions and normalize to maintain consistent speed (smooth diagonal movement)
        Vector3 movement = (forwardMovement + rightMovement).normalized;

        // movement to the player obj
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Game1"))
        {
            SceneManager.LoadScene("Game_Spell");
        }
    }
}