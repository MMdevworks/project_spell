using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class AbcImg : MonoBehaviour
{
    private AbcManager abcManager;
    private Rigidbody imageRb;
    private EventSystem eventSystem; // reference to event system, handle input ui

    public ParticleSystem burstParticle;
    public GameObject prefab;
    public string word;

    public TMP_InputField playerInput;

    void Start()
    {
        imageRb = GetComponent<Rigidbody>();
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
    }


    void Update()
    {
        imageRb.transform.Rotate(0, .3f, 0);
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