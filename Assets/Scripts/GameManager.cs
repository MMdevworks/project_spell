using UnityEngine; //
using UnityEngine.SceneManagement; // interact and manage scenes
using System.Collections.Generic; //
using System.Collections; // 
using TMPro; //
using UnityEngine.UI; // UI interactions such as buttons

public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.0f;
    private int score;
    private WordImage currentImg;

    public List<GameObject> targets;

    public List<GameObject> wordImg;

    //public GameObjects[] targets2; // using array
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText; // name same as in Unity editor
    public Button restartButton;
    public GameObject titleScreen; // ref to titlescreen game object

    public TMP_InputField playerInput; // input field **

    public bool isGameActive;

    void Awake()
    {
        playerInput = Object.FindFirstObjectByType<TMP_InputField>();
        if (playerInput != null)
        {
            playerInput.onSubmit.AddListener(OnSubmitPlayerInput);
        }
        else
        {
            Debug.LogError("Player Input Field not found.");
        }
    }



    void Start()
    {
        //playerInput.onSubmit.AddListener(OnSubmitPlayerInput); // **
        //playerInput.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        } 
    }

    public void UpdateScore(int scoreToAdd)  // public accessible in other classes
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
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

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        //spawnRate = spawnRate / difficulty;  // 1 / easy(1) 1sec, med(2)= .5sec hard(3) = .33 sec
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }

    //**
    public void SetCurrentWordImage(WordImage wordImage)
    {
        currentImg = wordImage;  // Set the active img obj when it spawns
    }

    public void OnSubmitPlayerInput(string input)
    {
        if (currentImg != null && input.ToLower() == currentImg.word.ToLower())
        {
            Destroy(currentImg.gameObject); 
            UpdateScore(5);  
            playerInput.text = "";  
        }
    }
}
