using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;

// Assigned to image prefabs

public class WordImage : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody imageRb;
    private EventSystem eventSystem; // reference to event system, handle input ui
    public ParticleSystem burstParticle;
    public TMP_InputField playerInput;
    private TextMeshProUGUI hintText;
    public string word;
    public int missCounter = 2;
    private float pauseTime = .4f;
    private bool wait = true;

    // init all items needed on start
    void Start()
    {
        hintText = GameObject.Find("Hint Text").GetComponent<TextMeshProUGUI>();
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
        hintText.text = "";
        if (input.ToLower().Trim() == word)
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
        else if (input.ToLower() != word)
        {

            // TODO: Implement checker; display correct letters in sequence so player knows what letters were correct.
            // Word: APPLE Input: APLE => AP_LE
            //foreach (char c in input.ToLower()) { Debug.Log(c); }
            char[] letterHint = new char[word.Length];
            int i = 0;
            int w = 0;

            while (i < input.Length && w < word.Length)
            {
                //if (i == input.Length - 1)
                //{
                //    letterHint[w] = '_';
                //    w++;
                //}

                if (input[i] == word[w])
                {
                    letterHint[w] = input[i];
                    i++;
                    w++;
                }
                else
                {
                    letterHint[w] = '_';
                    w++;
                }
            }

            foreach (char c in letterHint)
            {
                hintText.text += c.ToString();
            }

            //foreach (char c in input.ToLower())
            //{
            //    if (word.Contains(c))
            //    {
            //        hintText.text += c.ToString();
            //    }
            //}
            //foreach (char c in input.ToLower()) { Debug.Log(c); }


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
