using UnityEngine; 
using System.Collections.Generic;
using System.Collections; 
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private WordImage currentImg;
    private float spawnRate = .1f;

    public List<GameObject> wordImg;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countText;
    public TMP_InputField playerInput; 
    public Button restartButton;
    public GameObject titleScreen; 
    public GameObject staticUI;
    public GameObject phonicsBoard;
    public AudioSource correctSound;
    public int wordCount;
    public bool isGameActive;

    // called from TitleScreenOptions class

    public void StartGame()
    {
        wordCount = wordImg.Count;
        UpdateCountText();
        isGameActive = true;
        staticUI.gameObject.SetActive(true);

        StartCoroutine(SpawnImage());

        titleScreen.gameObject.SetActive(false);
        playerInput.gameObject.SetActive(true);     
        timerText.gameObject.SetActive(false);
    }

    public void StartGameChallenge()
    {
        isGameActive = true;
        staticUI.gameObject.SetActive(true);

        StartCoroutine(SpawnImage());

        titleScreen.gameObject.SetActive(false);
        playerInput.gameObject.SetActive(true);
    }

  
    // Coroutines - provide ability to manage things that need to happen after a delay or over time instead of instantly.
    // Controls image spawning. Instantiate a random image object with a short buffer time. HashSet to keeps track of already spawned images, so images will not be shown more than once.
    IEnumerator SpawnImage() 
    {
        HashSet<int> instantiated = new HashSet<int>();
        
        while (isGameActive)
        {
            if (Object.FindFirstObjectByType<WordImage>() == null) // Unity scripting library: find the first active object by type in scene
            {
                yield return new WaitForSeconds(spawnRate); // pause for spawn rate
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

    // Called when count = 0
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        gameOverText.gameObject.SetActive(false);
        StartGame();
    }

    // Set current to active img obj when it spawns: Called in WordImage class
    public void SetCurrentWordImage(WordImage wordImage)
    {
        currentImg = wordImage;  
    }

    // Update word count text, call game over if count reaches 0
    public void UpdateCountText()
    {
        if (countText != null) 
        {
            countText.text = "Words Left: " + wordCount;
        }

        if (wordCount == 0)
        {
            GameOver();
        }
    }
}
