using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenOptions : MonoBehaviour
{
    private Button startButton;
    private Button abcButton;
    private GameManager gameManager; // when importing get reference to it in start method

    void Start()
    {       
        Button button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (gameObject.name == "Start Button")
        {
            button.onClick.AddListener(LoadGame);
        }
        else if (gameObject.name == "Abc Button")
        {
            button.onClick.AddListener(LoadAbc);
        }

    }

    void Update()
    {

    }

    void LoadGame()
    {
        gameManager.StartGame();
    }

    void LoadAbc()
    {
        SceneManager.LoadScene("Game_Abc");
    }
}
