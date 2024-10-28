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


    public TextMeshProUGUI countText;

    public int wordCount;

    public Button restartButton;
    public GameObject titleScreen; 
    public GameObject staticUI;

    public TMP_InputField playerInput; 

    public bool isGameActive;

    public TextMeshProUGUI textField; 
    private float timer = 0f;
    public float changeDuration = 2f; 
    private bool textChanged = false;


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
    }
    public void StartGame()
    {

        isGameActive = true;
        staticUI.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        playerInput.gameObject.SetActive(true);

        StartCoroutine(SpawnImage());
    }

    IEnumerator SpawnImage() //methods to iterate over collection, return control to Unity temporarily
    {
        //HashSet<int> instantiated = new HashSet<int>();

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
