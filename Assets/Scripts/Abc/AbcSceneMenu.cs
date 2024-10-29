using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AbcSceneMenu : MonoBehaviour
{

    public Button pauseButton;
    public Button returnButton;
    public GameObject pauseMenu;

    private AbcManager abcManager;

    void Start()
    {
        abcManager = GameObject.Find("Abc Manager").GetComponent<AbcManager>();
        abcManager = GameObject.Find("Abc Manager").GetComponent<AbcManager>();
        pauseButton.onClick.AddListener(PauseScene);
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
            if (abcManager.gameOverText != null)
            {
                abcManager.gameOverText.gameObject.SetActive(false);
            }


            pauseMenu.SetActive(true);

            pauseText.text = "Resume";

            // set relative to parent element; transorm.position moved relative to world space
            RectTransform buttonRect = pauseButton.GetComponent<RectTransform>();
            if (buttonRect != null)
            {
                buttonRect.anchoredPosition = new Vector3(138f, -61f, -13.7f);
            }
        }

        else if (pauseText.text == "Resume")
        {
            pauseMenu.SetActive(false);
            pauseText.text = "Pause";

            RectTransform buttonRect = pauseButton.GetComponent<RectTransform>();
            if (buttonRect != null)
            {
                buttonRect.anchoredPosition = new Vector2(462f, -164f);
            }
        }

    }
    private void ReturnHome()
    {
        SceneManager.LoadScene("Game_Hub");
    }

}