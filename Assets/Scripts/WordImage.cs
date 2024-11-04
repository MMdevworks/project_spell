using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;

// Assigned to image prefabsgi 

public class WordImage : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody imageRb;
    private EventSystem eventSystem; // reference to event system, handle input ui
    public ParticleSystem burstParticle;
    public GameObject prefab;
    public TMP_InputField playerInput;

    public string word;
    public int missCounter = 2;
    private float pauseTime = .4f;
    private bool wait = true;

    // init all items needed on start
    void Start()
    {
        imageRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerInput = Object.FindFirstObjectByType<TMP_InputField>();

        if (playerInput != null)
        {
            playerInput.onSubmit.AddListener(OnSubmitPlayerInput);
        }
        else
        {
            Debug.LogError("Player Input Field not found.");
        }

        gameManager.SetCurrentWordImage(this);
        Debug.Log("Word assigned to this object: " + word);  
        playerInput.ActivateInputField(); // order matters
    }

    // FixedUpdate() - used for physics-related operations. Synced with Unity's physics engine
    // plays constant rotation animation and different animation on incorrect word
    void FixedUpdate()
    {
        if (wait == true)
        {
            imageRb.transform.Rotate(0, 2f, 0);
        }
        else if (wait == false)
        {
            StartCoroutine(TempMovement());
        }
    }
 
    IEnumerator TempMovement()
    {
        imageRb.transform.Rotate(0f, 30f, 0);
        yield return new WaitForSeconds(pauseTime);
        wait = true;

    }

    // Handle correct and incorrect input
    public void OnSubmitPlayerInput(string input)
    {
        if (input.ToLower() == word.ToLower())
        {
            Destroy(gameObject);
            gameManager.correctSound.Play();
            Instantiate(burstParticle, transform.position, burstParticle.transform.rotation);
            Debug.Log("Correct!");
            gameManager.wordCount--;
            gameManager.phonicsBoard.SetActive(false);
            missCounter = 2;
            gameManager.UpdateCountText();
        }
        else if (input.ToLower() != word.ToLower())
        {
           wait = false;
           missCounter--;

            if (missCounter == 0)
            {
                gameManager.phonicsBoard.SetActive(true);
            }
        }
        playerInput.text = "";
        playerInput.ActivateInputField();
        playerInput.Select();   
    }

    // Unity method, auto called on an object when its destroyed
    // removes listener associated with object destroyed
    private void OnDestroy()
    {
        playerInput.onSubmit.RemoveListener(OnSubmitPlayerInput);
    }
}
