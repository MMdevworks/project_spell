using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic; 
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class AbcManager : MonoBehaviour
{
    private float spawnRate = 2f;
    private AbcImg currentImg;

    public List<GameObject> abcImg;

    public TextMeshProUGUI gameOverText; 
    public TextMeshProUGUI getReadyText;

    public TextMeshProUGUI timerText;


    public TextMeshProUGUI scoreText;
    public int score = 0;

    public Button restartButton;
    public GameObject titleScreen; 
    public GameObject staticUI;

    public bool isGameActive;

    public TextMeshProUGUI textField; 
    private float timer = 0f;
    public float changeDuration = 2f; 
    private bool textChanged = false;
    private float stopWatchTime = 0;
    private bool stopWatchStart = false;

    void Start()
    {
    }

    void Update()
    {

        if (!textChanged)
        {
            timer += Time.deltaTime;

            if (timer >= changeDuration && timer < changeDuration +2)
            {
                getReadyText.text = "Go!";
            }
            if (timer >= changeDuration+2 && timer < changeDuration + 4)
            {    
                titleScreen.gameObject.SetActive(false);
                staticUI.gameObject.SetActive(true);

                textChanged = true;
                StartGame();
            }
        }

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
        stopWatchStart = true;
        isGameActive = true;
        staticUI.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);

        StartCoroutine(SpawnImage());
    }

    IEnumerator SpawnImage()
    {
        while (isGameActive)
        {
                yield return new WaitForSeconds(spawnRate); //pause for spawn rate
                int index = Random.Range(0, abcImg.Count);

                Instantiate(abcImg[index]);
 
        }
    }

    public void GameOver()
    { 
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // can pass in scene name or use method
    }

    public void SetCurrentAbcImage(AbcImg abcImage)
    {
        currentImg = abcImage;  // Set the active img obj when it spawns
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
