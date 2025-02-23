using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Attached to Title Screen buttons

public class TitleScreenOptions : MonoBehaviour
{

    private GameManager gameManager;

    void Start()
    {       
        Button button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (gameObject.name == "Start Button")
        {
            button.onClick.AddListener(LoadGame);
        }
        else if (gameObject.name == "Challenge Button")
        {
            button.onClick.AddListener(LoadGameChallenge);
        }
        else if (gameObject.name == "Abc Button")
        {
            button.onClick.AddListener(LoadAbc);
        }
    }

    void LoadGame()
    {
        gameManager.StartGame();
    }

    // currently unused in demo
    void LoadGameChallenge()
    {
        gameManager.StartGameChallenge();
    }

    void LoadAbc()
    {
        SceneManager.LoadScene("Game_Abc");
    }
}
