using UnityEngine;
using UnityEngine.SceneManagement;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    //private so cant be changed in insp
    private float movementSpeed = 10.0f;
    //public float rotationSpeed = 120.0f; // Set player's rotation movementSpeed.

    public Transform cameraTransform;

    private Rigidbody playerRb; // Reference to player's Rigidbody.

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    private void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // movement direction based on the camera's forward and right directions
        Vector3 forwardMovement = cameraTransform.forward * verticalInput;
        Vector3 rightMovement = cameraTransform.right * horizontalInput;

        // Combine directions and normalize to maintain consistent speed
        Vector3 movement = (forwardMovement + rightMovement).normalized;

        // movement to the player
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Game1"))
        {
            SceneManager.LoadScene("Game_Spell");
            //SceneManager.LoadScene("Game_Spell", LoadSceneMode.Additive);
        }
    }
}