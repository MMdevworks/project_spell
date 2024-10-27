using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneMenu : MonoBehaviour
{

    public Button pauseButton;
    public Button returnButton;
    //public Button unpauseButton;
    public GameObject pauseMenu;
   
    private GameManager gameManager;

    void Start()
    {

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
      
        pauseButton.onClick.AddListener(PauseScene);
        //unpauseButton.onClick.AddListener(UnPauseScene);
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
            gameManager.stopWatchStart = false;
            gameManager.playerInput.gameObject.SetActive(false);

            pauseText.text = "Resume";
            //Vector3 btnpos = pauseButton.transform.position;
            // set relative to parent element; transorm.position moved relative to world space
            RectTransform buttonRect = pauseButton.GetComponent<RectTransform>();
            if (buttonRect != null)
            {
                buttonRect.anchoredPosition = new Vector2(0f, -164f);  
            }
        }

        else if (pauseText.text == "Resume")
        {
            pauseMenu.SetActive(false);
            pauseText.text = "Pause";

            gameManager.stopWatchStart = true;
            gameManager.playerInput.gameObject.SetActive(true);
            gameManager.playerInput.ActivateInputField();

            RectTransform buttonRect = pauseButton.GetComponent<RectTransform>();
            if (buttonRect != null)
            {
                buttonRect.anchoredPosition = new Vector2(462f, -164f);  
            }
        }

    }

    //public void UnPauseScene()
    //{
    //    pauseMenu.SetActive(false);
        
    //}

    private void ReturnHome()
    {
        //load scene
    }


}
