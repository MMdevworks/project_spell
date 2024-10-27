using UnityEngine; //
using UnityEngine.SceneManagement; // interact and manage scenes
using System.Collections.Generic; //
using System.Collections; // 
using TMPro; //
using UnityEngine.UI; // UI interactions such as buttons


public class GameManager : MonoBehaviour
{
    private float spawnRate = .5f;
    private WordImage currentImg;

    //public List<GameObject> targets;

    public List<GameObject> wordImg;

    public TextMeshProUGUI gameOverText; // name same as in Unity editor
    public TextMeshProUGUI timerText;
    public bool stopWatchStart = false;
    private float stopWatchTime = 0;

    public TextMeshProUGUI countText;

    private int wordCount;
   
    public Button restartButton;
    public GameObject titleScreen; // ref to titlescreen game object
    public GameObject staticUI;

    public TMP_InputField playerInput; // input field **

    public bool isGameActive;


    //void Awake()
    //{
    //    playerInput = Object.FindFirstObjectByType<TMP_InputField>();
    //    if (playerInput != null)
    //    {
    //        playerInput.onSubmit.AddListener(OnSubmitPlayerInput);
    //    }
    //    else
    //    {
    //        Debug.LogError("Player Input Field not found.");
    //    }
    //}



    void Start()
    {
        wordCount = wordImg.Count + 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatchStart == true)
        {
            stopWatchTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(stopWatchTime / 60);
            int seconds = Mathf.FloorToInt(stopWatchTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    IEnumerator SpawnImage() //methods to iterate over collection, return control to Unity temporarily
    {
        HashSet<int> instantiated = new HashSet<int>();
        while (isGameActive)
        {
            if (Object.FindFirstObjectByType<WordImage>() == null)
            {
                yield return new WaitForSeconds(spawnRate); //pause for spawn rate
                int index = Random.Range(0, wordImg.Count);
                

                if (!instantiated.Contains(index))
                {
                    instantiated.Add(index);
                    Instantiate(wordImg[index]);
                    wordCount--;
                    UpdateCountText();
                }
            }
            else
            {
                // Wait a short time before checking again to avoid an infinite fast loop
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public void GameOver()
    {
        // get text, restart and show it 
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // can pass in scene name or use method
    }

    public void StartGame()
    {
        isGameActive = true;
        staticUI.gameObject.SetActive(true);
        //spawnRate /= difficulty;

        StartCoroutine(SpawnImage());

        titleScreen.gameObject.SetActive(false);
        playerInput.gameObject.SetActive(true);

        string deltaTime = Time.deltaTime.ToString();
        timerText.text = deltaTime;
        stopWatchStart = true;
    }

    public void SetCurrentWordImage(WordImage wordImage)
    {
        currentImg = wordImage;  // Set the active img obj when it spawns
    }

    public void OnSubmitPlayerInput(string input)
    {
        if (currentImg != null && input.ToLower() == currentImg.word.ToLower())
        {
            Destroy(currentImg.gameObject); 
           
            playerInput.text = "";
            wordCount--;

            UpdateCountText();
        }
    }
    private void UpdateCountText()
    {
        if (countText != null) // Ensure countText is assigned
        {
            countText.text = "Words Left: " + wordCount;
        }
        else
        {
            Debug.LogError("Count Text is not assigned.");
        }
    }

}
