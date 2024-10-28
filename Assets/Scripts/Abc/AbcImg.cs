using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class AbcImg : MonoBehaviour
{
    private AbcManager abcManager;
    private Rigidbody letterRb;
    private EventSystem eventSystem; // reference to event system, handle input ui

    public ParticleSystem burstParticle;
    public GameObject prefab;
    public string word;

    public TMP_InputField playerInput;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    //private float xRange = 0;
    //private float ySpawnPos = 0;

        void Start()
        {
            letterRb = GetComponent<Rigidbody>();
            abcManager = GameObject.Find("Abc Manager").GetComponent<AbcManager>();

            playerInput = Object.FindFirstObjectByType<TMP_InputField>();
            if (playerInput != null)
            {
                playerInput.onSubmit.AddListener(OnSubmitPlayerInput);
            }
            else
            {
                Debug.LogError("Player Input Field not found.");
            }

            abcManager.SetCurrentAbcImage(this);
            Debug.Log("Word assigned to this object: " + word);
            playerInput.ActivateInputField(); // order matters


            //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            //a above line wasnt working, had to add below
            GameObject gameManagerObject = GameObject.Find("Abc Manager");
            if (gameManagerObject != null)
            {
                abcManager = gameManagerObject.GetComponent<AbcManager>();
                if (abcManager == null)
                {
                    Debug.LogError("abcManager component not found on Game Manager object.");
                }
            }
            else
            {
                Debug.LogError("Game Manager object not found");
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



    public void OnSubmitPlayerInput(string input)
    {
        if (input.ToLower() == word.ToLower())
        {
            Destroy(gameObject);
            Instantiate(burstParticle, transform.position, burstParticle.transform.rotation);
            Debug.Log("Correct!");
            abcManager.wordCount--;
            abcManager.UpdateCountText();
        }
        playerInput.text = "";
        playerInput.ActivateInputField();
        playerInput.Select();

    }
    private void OnDestroy()
    {
        // Remove the listener when the object is destroyed to avoid memory leaks
        playerInput.onSubmit.RemoveListener(OnSubmitPlayerInput);
    }
}