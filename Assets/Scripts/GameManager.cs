using UnityEngine; //
using UnityEngine.SceneManagement; // interact and manage scenes
using System.Collections.Generic; //
using System.Collections; // 
using TMPro; //
using UnityEngine.UI; // UI interactions such as buttons


public class GameManager : MonoBehaviour
{
    private float spawnRate = .1f;
    private WordImage currentImg;

    public List<GameObject> wordImg;

    public TextMeshProUGUI gameOverText; // name same as in Unity editor
    public TextMeshProUGUI timerText;
    public bool stopWatchStart = false;
    private float stopWatchTime = 0;

    public TextMeshProUGUI countText;

    public int wordCount;
   
    public Button restartButton;
    public GameObject titleScreen; // ref to titlescreen game object
    public GameObject staticUI;
    public GameObject phonicsBoard;
    public AudioSource correctSound;
    public TMP_InputField playerInput; // input field **

    public bool isGameActive;

    void Start()
    {
        wordCount = wordImg.Count;
        UpdateCountText();
    }

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
    public void StartGame()
    {
        isGameActive = true;
        staticUI.gameObject.SetActive(true);

        StartCoroutine(SpawnImage());

        titleScreen.gameObject.SetActive(false);
        playerInput.gameObject.SetActive(true);
        phonicsBoard.gameObject.SetActive(true);
        stopWatchStart = false;
        timerText.gameObject.SetActive(false);
        //string deltaTime = Time.deltaTime.ToString();
        //timerText.text = deltaTime;
        //stopWatchStart = true;
    }

    public void StartGameChallenge()
    {
        isGameActive = true;
        staticUI.gameObject.SetActive(true);

        StartCoroutine(SpawnImage());

        titleScreen.gameObject.SetActive(false);
        playerInput.gameObject.SetActive(true);

        string deltaTime = Time.deltaTime.ToString();
        timerText.text = deltaTime;
        stopWatchStart = true;
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
        stopWatchStart = false;
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    //public void RestartGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // can pass in scene name or use method
    //}

    public void SetCurrentWordImage(WordImage wordImage)
    {
        currentImg = wordImage;  // Set the active img obj when it spawns
    }

    public void UpdateCountText()
    {
        //Debug.Log("this is word count!!!!!!!!! " + wordCount);
        if (countText != null) 
        {
            countText.text = "Words Left: " + wordCount;
        }

        if (wordCount == 0)
        {
            Debug.Log("GAME END COUNTER  EQUALS WORDIMAGE COUNT WHICH SHOULD BE 4");
            GameOver();
        }
    }
}
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
