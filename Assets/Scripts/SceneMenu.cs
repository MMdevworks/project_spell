using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneMenu : MonoBehaviour
{

    public Button pauseButton;
    public Button returnButton;
    public Button unpauseButton;
    public GameObject pauseMenu;
   
    private GameManager gameManager;

    void Start()
    {

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        pauseButton.onClick.AddListener(PauseScene);
        unpauseButton.onClick.AddListener(UnPauseScene);
        returnButton.onClick.AddListener(ReturnHome);
    }

    void Update()
    {
        
    }

    public void PauseScene()
    {
        TMP_Text pauseText = pauseButton.GetComponentInChildren<TMP_Text>();

        if (pauseText.text == "Pause")
        {
            pauseMenu.SetActive(true);
            pauseText.text = "Resume";
        }

        else if (pauseText.text == "Resume")
        {
            pauseMenu.SetActive(false);
            pauseText.text = "Pause";
        }

    }

    public void UnPauseScene()
    {
        pauseMenu.SetActive(false);
        
    }

    private void ReturnHome()
    {
        //load scene
    }


}
