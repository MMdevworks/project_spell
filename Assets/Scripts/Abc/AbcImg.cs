using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class AbcImg : MonoBehaviour
{
    private AbcManager abcManager;
    private Rigidbody letterRb;
    private EventSystem eventSystem; 

    public ParticleSystem burstParticle;
    public GameObject prefab;
    public string word;

    private float minSpeed = 3;
    private float maxSpeed = 6;
    private float maxTorque = 10;
    //private float xRange = 0;
    //private float ySpawnPos = 0;
    public KeyboardActions alpakey;

    void Awake()
        {
            alpakey = new KeyboardActions();
            alpakey.AlphabetActions.DestroyLetter.performed += OnSubmitPlayerInput;
        }

    void Start()
        {
            alpakey.Enable();
            letterRb = GetComponent<Rigidbody>();
            abcManager = GameObject.Find("Abc Manager").GetComponent<AbcManager>();

            abcManager.SetCurrentAbcImage(this);
            Debug.Log("Word assigned to this object: " + word);

            GameObject gameManagerObject = GameObject.Find("Abc Manager");
            if (gameManagerObject != null)
            {
                abcManager = gameManagerObject.GetComponent<AbcManager>();
                if (abcManager == null)
                {
                    Debug.LogError("abcManager component not found on Manager object.");
                }
            }
            else
            {
                Debug.LogError("Manager object not found");
            }

            letterRb.AddForce(RandomForce(), ForceMode.Impulse);
            letterRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(0,0, 24);
        //return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }



    void Update()
    {
        //letterRb.transform.Rotate(0, .3f, 0);
    }

    public void OnSubmitPlayerInput(InputAction.CallbackContext context)
    {
        // Get the key pressed as a string
        string keyPressed = context.control.displayName.ToLower();
        Debug.Log("Key Pressed: " + keyPressed);

        // Compare with the object's letter (word)
        if (keyPressed == word.ToLower()) 
        {
            Destroy(gameObject);
            Instantiate(burstParticle, transform.position, burstParticle.transform.rotation);
            Debug.Log("Correct!");
            abcManager.score += 10;
            abcManager.UpdateScoreText();
        }
    }

    private void OnDestroy()
    {
        if (alpakey != null)
        {
            alpakey.AlphabetActions.DestroyLetter.performed -= OnSubmitPlayerInput;
            alpakey.AlphabetActions.Disable();
        }
    }
}