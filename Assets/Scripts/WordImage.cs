using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using static UnityEngine.GraphicsBuffer;
using TMPro;

public class WordImage : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody imageRb;
    public ParticleSystem burstParticle;

    public GameObject prefab;
    public string word;

    public TMP_InputField playerInput;

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
            Debug.Log("Correct!");

            gameManager.UpdateScore(5);
        }
        playerInput.text = "";

    }
    private void OnDestroy()
    {
        // Remove the listener when the object is destroyed to avoid memory leaks
        playerInput.onSubmit.RemoveListener(OnSubmitPlayerInput);
    }
}
