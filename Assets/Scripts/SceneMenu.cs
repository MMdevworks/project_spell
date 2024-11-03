using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneMenu : MonoBehaviour
{

    public Button pauseButton;
    public Button resumeButton;
    public Button returnButton;
    public Button titlescreenButton;
    public GameObject pauseMenu;
   
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        pauseButton.onClick.AddListener(PauseScene);
        resumeButton.onClick.AddListener(ResumeScene);
        returnButton.onClick.AddListener(ReturnHome);
        titlescreenButton.onClick.AddListener(TitleSelectionScreen);
    }

    void Update()
    {
        
    }

    public void PauseScene()
    {
            if (gameManager.gameOverText != null)
            {
                gameManager.gameOverText.gameObject.SetActive(false);
            }

            pauseMenu.SetActive(true);
            gameManager.stopWatchStart = false;
            gameManager.playerInput.gameObject.SetActive(false);
            gameManager.phonicsBoard.SetActive(false);               
    }

    private void ResumeScene()
    {
        pauseMenu.SetActive(false);
        gameManager.stopWatchStart = true;
        gameManager.playerInput.gameObject.SetActive(true);
        gameManager.playerInput.ActivateInputField();
        gameManager.phonicsBoard.SetActive(true);
    }

    private void TitleSelectionScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ReturnHome()
    {
        SceneManager.LoadScene("Game_Hub");
    }

}
